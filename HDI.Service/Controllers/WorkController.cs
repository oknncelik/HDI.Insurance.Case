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
    public class WorkController : ApiController
    {
        private readonly IWorkManager _workManager;
        public WorkController(IWorkManager workManager)
        {
            _workManager = workManager;
        }

        [HttpPost]
        public async Task<Result<WorkModel>> Add(WorkModel work)
        {
            return await _workManager.AddAsync(work);
        }

        [HttpGet]
        public async Task<Result<List<WorkModel>>> GetList()
        {
            return await _workManager.GetListAsync();
        }

        [HttpDelete]
        public async Task<Result> Delete(long id)
        {
            return await _workManager.DeleteAsync(id);
        }


        [HttpGet]
        public async Task<Result<List<WorkResultModel>>> GetWorkResults()
        {
            return await _workManager.GetWorkResultsAsync();
        }
    }
}
