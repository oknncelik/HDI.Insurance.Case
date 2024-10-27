using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Data.Abstruct.Repositories;
using HDI.Entities.DTOs;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Business.Concreate
{
    public class ProductManager : IProductManager
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository  _productRepository;
        private readonly IContractRepository _contractRepository;

        public ProductManager(IMapper mapper,
                              IContractRepository contractRepository,
                              IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _contractRepository = contractRepository;
        }

        public async Task<Result<ProductModel>> AddAsync(ProductModel product)
        {
            var result = new Result<ProductModel>();

            try
            {
                var entity = await _productRepository.AddAsync(_mapper.Map<Product>(product));

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<ProductModel>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<ProductModel>>> GetListAsync()
        {
            var result = new Result<List<ProductModel>>();

            try
            {
                var entity = await _productRepository.GetListAsync();

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<ProductModel>>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<ProductModel>>> GetPartnerProductListAsync(long partnerId)
        {
            var result = new Result<List<ProductModel>>();

            try
            {
                //Partnere ait güncel anlaşmalar...
                var contract = await  _contractRepository.GetListAsync(x=> x.PartnerId == partnerId && 
                                                                            x.StartDate <= DateTime.Now &&
                                                                            x.EndDate >= DateTime.Now);

                //Partnerin ürün anlaşmalar...
                var products = contract.Select(x => x.ProductId);

                //anlaşmalı olduğu ürün hizmetler...
                var entity = await _productRepository.GetListAsync(x=> products.Contains(x.Id));

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<ProductModel>>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result> DeleteAsync(long id)
        {
            var result = new Result();
            try
            {
                result.IsSuccess = await _productRepository.DeleteAsync(id);

                result.Code = result.IsSuccess ? 1 : -1;
                if (result.IsSuccess)
                    result.Message = $"#{id} ID'li kayıt silindi.";
                else
                    result.Message = $"#{id} ID'li kayıt silinemedi !";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }
    }
}
