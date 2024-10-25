using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HDI.Service.Controllers
{
    public class ContractController : ApiController
    {
        private readonly IContractManager _contractManager;
        public ContractController(IContractManager contractManager)
        {
            _contractManager = contractManager;
        }

        [HttpPost]
        public async Task<Result<ContractModel>> Add(ContractModel contract)
        {
            return await _contractManager.AddAsync(contract);
        }

        [HttpGet]
        public async Task<Result<List<ContractModel>>> GetList()
        {
            return await _contractManager.GetListAsync();
        }

        [HttpDelete]
        public async Task<Result> Delete(long id)
        {
            return await _contractManager.DeleteAsync(id);
        }
    }
}
