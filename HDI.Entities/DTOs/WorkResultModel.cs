using HDI.Entities.Concreate;
using System;

namespace HDI.Entities.DTOs
{
    public class WorkResultModel : Model
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
        public string ExpireDesc => Expire ?  "Sonlandı" : "Aktif";
    }
}
