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
    /// 出库记录表
    /// </summary>
    [ActiveRecord]
   public class S_putsStorage:BaseEntity<S_putsStorage>
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "流水号")]
        public string SwiftNumber { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        [BelongsTo(Column = "warehouseId")]
        [Display(Name = "仓库")]
        public T_warehouse warehouseList { get; set; }
        /// <summary>
        /// 货物
        /// </summary>
        [BelongsTo(Column = "goodsId")]
        [Display(Name = "货物")]
        public T_goods goodsList { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        [BelongsTo(Column = "WorkerId")]
        [Display(Name = "管理员")]
        public T_worker workerList { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "日期")]
        public string Date { get; set; }
        /// <summary>
        /// 类型
        /// 0：出库，1：入库
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "类型")]
        public string Type { get; set; }
    }
}
