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
    /// 实体类：仓库
    /// </summary>
    [ActiveRecord]
   public class T_warehouse:BaseEntity<T_warehouse>
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "货物名称")]
        public string Name { get; set; }

        /// <summary>
        /// 仓库地址
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "仓库地址")]
        public string Address { get; set; }

        /// <summary>
        /// 建成日期
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "建成日期")]
        public string CompletionDate { get; set; }

     
        /// <summary>
        /// 管理员
        /// </summary>
        [BelongsTo(Column = "WorkerId")]
        [Display(Name = "管理员")]
        public T_worker workerList { get; set; }

    }
}
