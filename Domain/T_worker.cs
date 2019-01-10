using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace com.tg.WMS.Domain
{
    /// <summary>
    /// 实体类：职工
    /// </summary>
    [ActiveRecord]
   public class T_worker:BaseEntity<T_worker>
    {
        /// <summary>
        /// 职工名
        /// </summary>
        [Property(NotNull = true, Length = 20)]
        [Display(Name = "职工名")]
        public string WorkerName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Property(NotNull = true, Length = 20)]
        [Display(Name = "性别")]
        public string Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Property(NotNull = true, Length = 64)]
        [Display(Name = "年龄")]
        public string Age { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Property(NotNull = true, Length = 64)]
        [Display(Name = "民族")]
        public string Race { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "电话")]
        public int Phone { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "住址")]
        public int Adress { get; set; } 
        /// <summary>
        ///部门
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "部门")]
        public int Department { get; set; } 
        /// <summary>
        ///职务
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "职务")]
        public int Position { get; set; }

     
    }
}
