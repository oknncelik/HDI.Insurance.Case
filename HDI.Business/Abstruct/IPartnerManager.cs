using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Business.Abstruct
{
    public interface IPartnerManager
    {
        Task<Result<PartnerModel>> AddAsync(PartnerModel partner);
        Task<Result> DeleteAsync(long id);
        Task<Result<List<PartnerModel>>> GetListAsync();
    }
}
