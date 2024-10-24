using HDI.Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Concreate
{
    public abstract class Model : IModel
    {
        public long Id { get; set; }
    }
}
