using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDI.Entities.Abstruct
{
    public interface IEntity
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Oluşturulma Tarihi
        /// </summary>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Güncelleme Tarihi
        /// </summary>
        DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Silme gerçekleştirilmeyecek False olarak setlenecek...
        /// </summary>
        bool ActiveFlg { get; set; } 
    }
}
