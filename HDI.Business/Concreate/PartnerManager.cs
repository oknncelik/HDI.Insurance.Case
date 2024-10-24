using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Data.Abstruct.Repositories;
using HDI.Entities.Concreate;
using HDI.Entities.DTOs;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Business.Concreate
{
    public class PartnerManager : IPartnerManager
    {
        private readonly IMapper _mapper;
        private readonly IPartnerRepository _partnerRepository;

        public PartnerManager(IMapper mapper, 
                              IPartnerRepository partnerRepository)
        {
            _mapper = mapper;
            _partnerRepository = partnerRepository;
        }

        public async Task<Result<PartnerModel>> AddAsync(PartnerModel partner)
        {
            var result = new Result<PartnerModel>();

            try
            {
                var entity = await _partnerRepository.AddAsync(_mapper.Map<Partner>(partner));

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<PartnerModel>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<PartnerModel>>> GetListAsync()
        {
            var result = new Result<List<PartnerModel>>();

            try
            {
                var entity = await _partnerRepository.GetListAsync();

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<PartnerModel>>(entity);
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
                result.IsSuccess = await _partnerRepository.DeleteAsync(id);

                result.Code = 1;
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
