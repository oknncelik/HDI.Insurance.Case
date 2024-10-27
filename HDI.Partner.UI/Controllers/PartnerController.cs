using HDI.Core.Results;
using HDI.Entities.DTOs;
using HDI.Partner.Integration.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
        public async Task<Result<List<ProductModel>>> GetProducts()
        {
            return await _partnerService.GetProducts();
        }

        [HttpPost]
        public async Task<Result<WorkModel>> GetProducts(WorkModel id)
        {
            return await _partnerService.AddWork(id);
        }
    }
}
