using HDI.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Entities
{
    public class WorkResult : Entity
    {
        public string PartnerName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long Count { get; set; }
        public long WorkCount { get; set; }
        public decimal WorkPercent { get; set; }
        public bool Expire { get; set; }
        

    }
}
