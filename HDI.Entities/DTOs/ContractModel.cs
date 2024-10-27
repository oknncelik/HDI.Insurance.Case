using HDI.Entities.Abstruct;
using HDI.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.DTOs
{
    public class ContractModel : Model
    {
        public long PartnerId { get; set; }
        public PartnerModel Partner { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public long Count { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ExpireDesc => EndDate < DateTime.Now ? "Sonlandı" : "Aktif";
    }
}
