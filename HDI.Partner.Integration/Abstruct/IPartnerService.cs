using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Partner.Integration.Abstruct
{
    public interface IPartnerService
    {
        Task<Result<WorkModel>> AddWork(WorkModel work);
        Task<Result<List<ContractModel>>> GetPartnerContracts(long partnerId);
        Task<Result<List<PartnerModel>>> GetPartners();
        Task<Result<List<ProductModel>>> GetProducts(long partnerId);
        Task<Result<List<WorkModel>>> GetWorkList(long partnerId);
    }
}
