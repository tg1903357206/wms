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
    ///  实体类：用户
    /// </summary>
    [ActiveRecord]
    public class SysUser : BaseEntity<SysUser>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Property(NotNull = true, Length = 20)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        [Property(NotNull = true, Length = 20)]
        [Display(Name = "登录账号")]
        public string LoginAccount { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [Property(NotNull = true, Length = 64)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        /// <summary>
        /// 状态
        ///     0：正常
        ///     1：禁用
        /// </summary>
        [Property(NotNull = true)]
        [Display(Name = "状态")]
        public int Status { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [HasAndBelongsToMany(Table = "Role_User", ColumnKey = "UserId", ColumnRef = "RoleId")]
        [Display(Name = "角色列表")]
        public IList<SysRole> RoleList { get; set; }
    }
}
