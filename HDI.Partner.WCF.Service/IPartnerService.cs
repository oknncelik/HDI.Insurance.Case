using HDI.Core.Results;
using HDI.Entities.DTOs;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Partner.WCF.Service
{
    [ServiceContract]
    public interface IPartnerService
    {
        [OperationContract]
        Task<Result<WorkModel>> AddWork(WorkModel work);

        [OperationContract]
        Task<Result<List<PartnerModel>>> GetPartners();

        [OperationContract]
        Task<Result<List<ContractModel>>> GetPartnerContracts(long partnerId);

        [OperationContract]
        Task<Result<List<ProductModel>>> GetProducts(long partnerId);

        [OperationContract]
        Task<Result<List<WorkModel>>> GetWorkList(long partnerId);
    }
}
