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
    /// 实体类:角色
    /// </summary>
    [ActiveRecord]
    public class SysRole : BaseEntity<SysRole>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Property(NotNull = true, Length = 20)]
        [Display(Name = "用户名")]
        public string Name { get; set; }

        /// <summary>
        /// 用户列表
        /// </summary>
        [HasAndBelongsToMany(Table = "Role_User", ColumnKey = "RoleId", ColumnRef = "UserId")]
        [Display(Name = "用户列表")]
        public IList<SysUser> UserList { get; set; }

        /// <summary>
        /// 菜单权限
        /// </summary>
        [HasAndBelongsToMany(Table = "Role_Menu", ColumnKey = "RoleId", ColumnRef = "MenuId")]
        [Display(Name = "菜单权限")]
        public IList<SysMenu> MenuList { get; set; }
    }
}
