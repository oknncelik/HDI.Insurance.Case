using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Business.Abstruct
{
    public interface IWorkManager
    {
        Task<Result<WorkModel>> AddAsync(WorkModel work);
        Task<Result> DeleteAsync(long id);
        Task<Result<List<WorkModel>>> GetListAsync();
        Task<Result<List<WorkModel>>> GetPartnerWorkListAsync(long partnerId);
    }
}
