using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Domain
{
    /// <summary>
    /// 实体类：货物
    /// </summary>
    [ActiveRecord]
   public class T_goods:BaseEntity<T_goods>
    {
        /// <summary>
        /// 货物名称
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "货物名称")]
        public string Name { get; set; }
        /// <summary>
        /// 货物类型
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "货物类型")]
        public string GoodsType { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [Property(NotNull = true, Length = 100)]
        [Display(Name = "生产厂家")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "生产日期")]
        public string ProductionDate { get; set; }
        /// <summary>
        /// 保质期
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "保质期")]
        public string ExpirationDate { get; set; }

       /// <summary>
        /// 货物单价
       /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "货物单价")]
        public int Price { get; set; }

        
    }
}
