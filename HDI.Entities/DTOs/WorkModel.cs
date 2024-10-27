using HDI.Entities.Concreate;
using HDI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.DTOs
{
    public class WorkModel : Model
    {
        public long PartnerId { get; set; }
        public PartnerModel Partner { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public DateTime Date { get; set; }
    }
}
