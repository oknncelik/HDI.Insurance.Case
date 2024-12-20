﻿using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Data.Abstruct.Repositories
{
    public interface IWorkRepository : IContext<Work>
    {
        Task<IList<WorkResult>> GetWorkResultsAsync();
    }
}
