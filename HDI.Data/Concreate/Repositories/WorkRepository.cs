using HDI.Data.Abstruct.Repositories;
using HDI.Data.Contexts;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Concreate.Repositories
{
    public class WorkRepository : BaseContext<Work, HDIContext>, IWorkRepository
    {
        public async override Task<IList<Work>> GetListAsync(Expression<Func<Work, bool>> filter = null)
        {
            var quer = _context.Work.Where(x => x.ActiveFlg == true);

            if (filter != null)
                quer = _context.Work.Where(filter);

            return await quer
                        .Include(x => x.Partner)
                        .Include(x => x.Product)
                        .ToListAsync();
        }


        public async Task<IList<WorkResult>> GetWorkResultsAsync()
        {
            return await _context.Database
                 .SqlQuery<WorkResult>("SELECT * FROM GetContractResults()")
                 .ToListAsync();
        }
    }
}
