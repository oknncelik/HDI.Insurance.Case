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
    public class ProductController : ApiController
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpPost]
        public async Task<Result<ProductModel>> Add(ProductModel product)
        {
            return await _productManager.AddAsync(product);
        }

        [HttpGet]
        public async Task<Result<List<ProductModel>>> GetList()
        {
            return await _productManager.GetListAsync();
        }

        [HttpDelete]
        public async Task<Result> Delete(long id)
        {
            return await _productManager.DeleteAsync(id);
        }
    }
}
