using HDI.Core.Results;
using HDI.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using HDI.Partner.Integration.Abstruct;

namespace HDI.Partner.UI.Controllers
{
    public class PartnerController : ApiController
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<Result<List<WorkModel>>> GetWorkList(long id)
        {
            return await _partnerService.GetWorkList(id);
        }

        [HttpGet]
        public async Task<Result<List<PartnerModel>>> GetPartners()
        {
            return await _partnerService.GetPartners();
        }


        [HttpGet]
        public async Task<Result<List<ProductModel>>> GetProducts(long id)
        {
            return await _partnerService.GetProducts(id);
        }

        [HttpPost]
        public async Task<Result<WorkModel>> AddWork(WorkModel id)
        {
            return await _partnerService.AddWork(id);
        }

        [HttpGet]
        public async Task<Result<List<ContractModel>>> GetPartnerContracts(long id)
        {
            return await _partnerService.GetPartnerContracts(id);
        }
    }
}
