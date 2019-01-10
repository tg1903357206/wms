using com.tg.WMS.Core;
using com.tg.WMS.Domain;
using com.tg.WMS.Service;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Web.Controllers
{
    public class SysMenuController : Controller
    {
        //
        // GET: /SysMenu/

        public ActionResult Index(int pageIndex = 1)
        {
            int pageSize = 2;//每页行数
            //1.查询条件
            IList<ICriterion> condition = new List<ICriterion>();
            //1.1按用户名模糊查询
            //string qrySysMenuName = "";
            //if (Request["qrySysMenuName"] == null)
            //{
            //    qrySysMenuName = (string)Session["qrySysMenuName"];
            //}
            //else
            //{
            //    qrySysMenuName = Request["qrySysMenuName"];
            //    Session["qrySysMenuName"] = qrySysMenuName;
            //}
            //if (qrySysMenuName != null && qrySysMenuName.Length > 0)
            //{
                condition.Add(Expression.Like("Name", "", MatchMode.Anywhere));
            //}
            //2.获取数据
            IList<SysMenu> list = Container.Instance.Reslove<IServiceSysMenu>().Query(condition);
            //3.返回视图前预处理
            //ViewBag.qrySysMenuName = qrySysMenuName;
            //4.实现分页,送入强类型视图
            return View(list.ToPagedList(pageIndex, pageSize));
        }

    }
}
