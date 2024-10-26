using HDI.Data.Abstruct.Repositories;
using HDI.Data.Contexts;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Concreate.Repositories
{
    public class ContractRepository : BaseContext<Contract, HDIContext>, IContractRepository
    {
        public async Task<List<Contract>> ContractList()
        {
            return await _context.Contract
                .Where(x=> x.ActiveFlg == true)
                .Include(x=> x.Partner)
                .Include(x=> x.Product)
                .ToListAsync();
        }
    }
}
