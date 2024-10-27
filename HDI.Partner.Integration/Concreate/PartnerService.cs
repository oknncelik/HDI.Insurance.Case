using HDI.Core.Results;
using HDI.Entities.DTOs;
using HDI.Partner.WCF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Partner.Integration.Concreate
{
    public class PartnerService : HDI.Partner.Integration.Abstruct.IPartnerService
    {
        private HDI.Partner.WCF.Service.IPartnerService _service;

        public PartnerService(HDI.Partner.WCF.Service.IPartnerService service)
        {
            _service = service;
        }

        public async Task<Result<WorkModel>> AddWork(WorkModel work)
        {
            return await _service.AddWork(work);
        }

        public async Task<Result<List<WorkModel>>> GetWorkList(long partnerId)
        {
            return await _service.GetWorkList(partnerId);
        }

        public async Task<Result<List<PartnerModel>>> GetPartners()
        {
            return await _service.GetPartners();
        }

        public async Task<Result<List<ProductModel>>> GetProducts(long partnerId)
        {
            return await _service.GetProducts(partnerId);
        }

        public async Task<Result<List<ContractModel>>> GetPartnerContracts(long partnerId)
        {
            return await _service.GetPartnerContracts(partnerId);
        }
    }
}
