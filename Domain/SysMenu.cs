using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace com.tg.WMS.Domain
{
    /// <summary>
    /// 实体类：菜单
    /// </summary>
    [ActiveRecord]
    public class SysMenu : BaseEntity<SysMenu>
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "菜单名称")]
        public string Name { get; set; }

        /// <summary>
        /// 类名
        /// </summary>
        [Property(NotNull = true, Length = 100)]
        [Display(Name = "类名")]
        public string ClassName { get; set; }

        /// <summary>
        /// 控制器名
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "控制器名")]
        public string ControllerName { get; set; }

        /// <summary>
        /// 动作名
        /// </summary>
        [Property(NotNull = true, Length = 50)]
        [Display(Name = "动作名")]
        public string ActionName { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "排序码")]
        public int SortCode { get; set; }

        /// <summary>
        /// 上级菜单
        ///     多对一关系
        /// </summary>
        [BelongsTo(Column = "ParentId")]
        [Display(Name = "上级菜单")]
        public SysMenu ParentMenu { get; set; }
    }
}
