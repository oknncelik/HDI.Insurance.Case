using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HDI.Service.Controllers
{
    public class PartnerController : ApiController
    {
        private readonly IPartnerManager _partnerManager;
        public PartnerController(IPartnerManager partnerManager)
        {
            _partnerManager = partnerManager;
        }

        [HttpPost]
        public async Task<Result<PartnerModel>> Add(PartnerModel partner)
        {
            return await _partnerManager.AddAsync(partner);
        }

        [HttpGet]
        public async Task<Result<List<PartnerModel>>> GetList()
        {
            return await _partnerManager.GetListAsync();
        }

        [HttpDelete]
        public async Task<Result> Delete(long id)
        {
            return await _partnerManager.DeleteAsync(id);
        }
    }
}
