using HDI.Entities.Abstruct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Concreate
{
    public abstract class Entity : IEntity
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Oluşturulma Tarihi
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Güncelleme Tarihi
        /// </summary>
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Default olarak True atandı. Bu değer silme işleminde False olarak setlenecek...
        /// </summary>
        public bool ActiveFlg { get; set; } = true;
    }
}
