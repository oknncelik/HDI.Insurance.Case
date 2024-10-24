using HDI.Data.Abstruct.Repositories;
using HDI.Data.Contexts;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Concreate.Repositories
{
    public class ProductRepository : BaseContext<Product, HDIContext>, IProductRepository
    {
    }
}
