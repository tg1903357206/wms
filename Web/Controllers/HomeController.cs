using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using com.tg.WMS.Common;
using com.tg.WMS.Core;
using com.tg.WMS.Domain;
using com.tg.WMS.Service;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
        //    if (Session["userInfo"] == null)
        //    {
        //        Response.Redirect("/SysUser/Login");
        //    }
            SysUser loginUser = Container.Instance.Reslove<IServiceSysUser>().GetEntity(1);
            if (loginUser.RoleList == null) loginUser.RoleList = new List<SysRole>();
            IList<SysMenu> menuAuth = new List<SysMenu>();
            foreach (var role in loginUser.RoleList)
            {
                if (role.MenuList == null) role.MenuList = new List<SysMenu>();
                foreach (var item in role.MenuList)
                {
                    menuAuth.Add(item);
                }
            }
            //去重
            menuAuth = menuAuth.Distinct(new CompareForMenu()).ToList();

            ViewBag.menuAuth = menuAuth;
            return View();
        }

        public ActionResult InitDB()
        {
            return View();
        }

        public ActionResult StartInitDB()
        {
            //1.创建数据库
            CreateSchema();
            InitMenu();
            InitRole();
            return View("InitDB");
        }

        #region 初始化菜单
        private void InitMenu()
        {
            try
            {
                Response.Write("开始初始化菜单=========<br/>");
                #region 初始化一级菜单
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "系统管理",
                    ActionName = "",
                    ClassName = "",
                    ControllerName = "",
                    ParentMenu = null,
                    SortCode = 10,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "基础数据管理",
                    ActionName = "",
                    ClassName = "",
                    ControllerName = "",
                    ParentMenu = null,
                    SortCode = 20,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "库存管理",
                    ClassName = "Web.Controllers.FreeVideoController",
                    ControllerName = "FreeVideo",
                    ActionName = "Index",
                    ParentMenu = null,
                    SortCode = 30,

                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "仓库管理",
                    ClassName = "Web.Controllers. TrainClassController",
                    ControllerName = "TrainClass",
                    ActionName = "Index",
                    ParentMenu = null,
                    SortCode = 40,

                });
      
             #endregion

                #region 系统管理的子菜单
                SysMenu parent = Container.Instance.Reslove<IServiceSysMenu>().GetEntity(1);
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "菜单管理",
                    ClassName = "Web.Controllers.SysMenuController",
                    ControllerName = "SysMenu",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 10,

                });

                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "角色管理",
                    ClassName = "Web.Controllers.SysRoleController",
                    ControllerName = "SysRole",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 20,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "用户管理",
                    ClassName = "Web.Controllers.SysUserController",
                    ControllerName = "SysUser",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 30,
                });
              
                #endregion

                #region 基础数据管理的子菜单
                parent = Container.Instance.Reslove<IServiceSysMenu>().GetEntity(2);
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "仓库管理",
                    ClassName = "Web.Controllers.WarehouseController",
                    ControllerName = "Clazz",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 10,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "货物管理",
                    ClassName = "Web.Controllers.GoodsController",
                    ControllerName = "Course",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 20,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "职工管理",
                    ClassName = "Web.Controllers.WorkerController",
                    ControllerName = "Courseware",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 30,
                });
                Container.Instance.Reslove<IServiceSysMenu>().Create(new SysMenu()
                {
                    Name = "组织管理",
                    ClassName = "Web.Controllers.OrganizationController",
                    ControllerName = "Student",
                    ActionName = "Index",
                    ParentMenu = parent,
                    SortCode = 40,
                });
               
                #endregion

                Response.Write("初始化菜单成功<br/>");

            }
            catch (Exception exp)
            {

                Response.Write("出错了，位置：InitMenu()<br/>" + exp.Message);
            }
        }
        #endregion
        #region 初始化角色
        private void InitRole()
        {
            try
            {
                Response.Write("开始初始化角色<br/>");
                IList<int> param = new List<int>();
                for (int i = 3; i <= 11; i++)
                {

                    param.Add(i);

                }
                param.Add(1);
                param.Add(2);
                Container.Instance.Reslove<IServiceSysRole>().Create(new SysRole()
                {
                    Name = "系统管理员",
                    MenuList = Container.Instance.Reslove<IServiceSysMenu>().Query(new List<ICriterion>()
                    {
                        Expression.In("ID",param.ToArray())
                    }),

                });
                param.Clear();
                param.Add(3);
                param.Add(4);
                param.Add(9);
                Container.Instance.Reslove<IServiceSysRole>().Create(new SysRole()
                {
                    Name = "仓库管理员",
                    MenuList = Container.Instance.Reslove<IServiceSysMenu>().Query(
                        new List<ICriterion>() { 
                                Expression.In("ID",param.ToArray())
                        }),
                });

                param.Clear();
                param.Add(9);
                Container.Instance.Reslove<IServiceSysRole>().Create(new SysRole()
                {
                    Name = "采购员",
                    MenuList = Container.Instance.Reslove<IServiceSysMenu>().Query(
                        new List<ICriterion>() { 
                                Expression.In("ID",param.ToArray())
                        }),
                });
                Response.Write("初始化角色完成<br/>");
            }
            catch (Exception exp)
            {

                Response.Write("出错了，位置：InitRole()<br/>" + exp.Message);
            }
        }
        #endregion
        private void CreateSchema()
        {
            try
            {
                if (!ActiveRecordStarter.IsInitialized)
                {
                    Response.Write("开始................初始化Castle<br/>");
                    IConfigurationSource source = System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
                    ActiveRecordStarter.Initialize(typeof(SysUser).Assembly, source);
                    Response.Write("成功................初始化Castle<br/>");
                }
                Response.Write("开始................CreateSchema<br/>");
                ActiveRecordStarter.CreateSchema();

                Response.Write("成功................CreateSchema<br/>");
            }
            catch (Exception e)
            {
                Response.Write(string.Format("异常位置：{0}<br/>{1}", "CreateSchema", e.Message));
            }
        }


    }
}
