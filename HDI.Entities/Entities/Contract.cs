using HDI.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Entities
{
    public class Contract : Entity
    {
        public long PartnerId { get; set; }
        public Partner Partner { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
