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
    /// 事务申请
    /// </summary>
    [ActiveRecord]
    public class S_application:BaseEntity<S_application>
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "流水号")]
        public string SwiftNumber { get; set; }
        /// <summary>
        /// 货物
        /// </summary>
        [BelongsTo(Column = "GoodsId")]
        [Display(Name = "仓库")]
        public T_goods GoodsList { get; set; }
        /// <summary>
        ///仓库
        /// </summary>
        [BelongsTo(Column = "WarehouseId")]
        [Display(Name = "货物")]
        public T_warehouse WarehouseList { get; set; }
        /// <summary>
        /// 管理员
        /// </summary>
        [BelongsTo(Column = "WorkerId")]
        [Display(Name = "管理员")]
        public T_worker WorkerList { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "日期")]
        public string Date { get; set; }
        /// <summary>
        /// 类型
        /// 0：出库，1：入库,3:退货，4：报损，5：购买，6：移库
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "类型")]
        public string Type { get; set; }
        /// <summary>
        /// 状态
        /// 0：失败，1：通过,3:审核中
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "状态")]
        public string State { get; set; }
    }
}
