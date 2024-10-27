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
    public class ContractManager : IContractManager
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;

        public ContractManager(IMapper mapper,
                               IContractRepository contractRepository)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<Result<ContractModel>> AddAsync(ContractModel contract)
        {
            var result = new Result<ContractModel>();

            try
            {
                var entity = _mapper.Map<Contract>(contract);
                entity = await _contractRepository.AddAsync(entity);

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<ContractModel>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<ContractModel>>> GetListAsync()
        {
            var result = new Result<List<ContractModel>>();

            try
            {
                var entity = await _contractRepository.GetListAsync();

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<ContractModel>>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<ContractModel>>> GetPartnerContractsAsync(long partnerId)
        {
            var result = new Result<List<ContractModel>>();

            try
            {
                var entity = await _contractRepository.GetListAsync(x=> x.PartnerId == partnerId);

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<ContractModel>>(entity);
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
                result.IsSuccess = await _contractRepository.DeleteAsync(id);

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
