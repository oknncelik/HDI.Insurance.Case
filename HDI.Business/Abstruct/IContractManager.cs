using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Business.Abstruct
{
    public interface IContractManager
    {
        Task<Result<ContractModel>> AddAsync(ContractModel contract);
        Task<Result> DeleteAsync(long id);
        Task<Result<List<ContractModel>>> GetListAsync();
    }
}
