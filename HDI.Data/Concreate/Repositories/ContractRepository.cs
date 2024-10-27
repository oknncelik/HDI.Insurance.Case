using HDI.Data.Abstruct.Repositories;
using HDI.Data.Contexts;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Concreate.Repositories
{
    public class ContractRepository : BaseContext<Contract, HDIContext>, IContractRepository
    {
        /// <summary>
        /// Bağlı tablolarıda getirebilmek için override edildi...
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public override async Task<IList<Contract>> GetListAsync(Expression<Func<Contract, bool>> filter = null)
        {
            var quer = _context.Contract.Where(x => x.ActiveFlg == true);

            if(filter != null)
                quer =  _context.Contract.Where(filter);

            return await quer
                        .Include(x => x.Partner)
                        .Include(x => x.Product)
                        .ToListAsync();
        }
    }
}
