using HDI.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Entities
{
    public class Work : Entity
    {
        public long PartnerId { get; set; }
        public Partner Partner { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
    }
}
