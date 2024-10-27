using HDI.Business.Abstruct;
using HDI.Core.Results;
using HDI.Entities.DTOs;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Partner.WCF.Service
{
    public class PartnerService : IPartnerService
    {
        private readonly IWorkManager _workManager;
        private readonly IPartnerManager _partnerManager;
        private readonly IProductManager _productManager;
        public PartnerService(IWorkManager workManager,
                              IPartnerManager partnerManager,
                              IProductManager productManager)
        {
            _workManager = workManager;
            _partnerManager = partnerManager;
            _productManager = productManager;
        }

        public async Task<Result<List<PartnerModel>>> GetPartners()
        {
            return await _partnerManager.GetListAsync();
        }

        public async Task<Result<List<ProductModel>>> GetProducts()
        {
            return await _productManager.GetListAsync();
        }

        public async Task<Result<List<WorkModel>>> GetWorkList(long partnerId)
        {
            return await _workManager.GetListAsync(partnerId);
        }

        public async Task<Result<WorkModel>> AddWork(WorkModel work)
        {
            return await _workManager.AddAsync(work);
        }
    }
}
