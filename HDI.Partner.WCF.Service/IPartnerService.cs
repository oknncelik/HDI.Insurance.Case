using HDI.Core.Results;
using HDI.Entities.DTOs;
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
        Task<Result<List<ProductModel>>> GetProducts();

        [OperationContract]
        Task<Result<List<WorkModel>>> GetWorkList(long partnerId);
    }
}
