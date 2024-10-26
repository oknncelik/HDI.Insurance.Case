using AutoMapper;
using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Data.Abstruct.Repositories;
using HDI.Entities.DTOs;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HDI.Business.Concreate
{
    public class WorkManager : IWorkManager
    {
        private readonly IMapper _mapper;
        private readonly IWorkRepository _workRepository;

        public WorkManager(IMapper mapper,
                           IWorkRepository workRepository)
        {
            _mapper = mapper;
            _workRepository = workRepository;
        }

        public async Task<Result<WorkModel>> AddAsync(WorkModel work)
        {
            var result = new Result<WorkModel>();

            try
            {
                var entity = await _workRepository.AddAsync(_mapper.Map<Work>(work));

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<WorkModel>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Code = 0;
                result.Message = $"Hata : {ex.Message}";
            }

            return result;
        }

        public async Task<Result<List<WorkModel>>> GetListAsync()
        {
            var result = new Result<List<WorkModel>>();

            try
            {
                var entity = await _workRepository.GetListAsync();

                result.Code = 1;
                result.Message = "İşlem Başarılı";
                result.Data = _mapper.Map<List<WorkModel>>(entity);
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
                result.IsSuccess = await _workRepository.DeleteAsync(id);

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
