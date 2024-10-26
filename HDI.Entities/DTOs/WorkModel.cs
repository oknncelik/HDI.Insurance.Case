using HDI.Entities.Concreate;
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
        public long ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
