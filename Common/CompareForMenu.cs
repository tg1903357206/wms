using com.tg.WMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Common
{
    public class CompareForMenu : IEqualityComparer<SysMenu>
    {
        /// <summary>
        /// 菜单比较器
        /// </summary>

        public int GetHashCode(SysMenu obj)
        {
            return obj.ID.GetHashCode();
        }

        public bool Equals(SysMenu x, SysMenu y)
        {
            return x.ID == y.ID;
        }
    }
}
