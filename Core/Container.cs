using Castle.MicroKernel;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Core
{
   public class Container
    {
        /// <summary>
        /// 拦截器
        /// </summary>
        private XmlInterpreter interpreter;

        /// <summary>
        /// IOC容器
        /// </summary>
        private WindsorContainer winsor;

        /// <summary>
        /// IOC容器的内核
        /// </summary>
        public IKernel kernel { get; set; }

        /// <summary>
        /// IOC实例---单例模式
        /// </summary>
        public static Container Instance
        {
            get { return instance; }
        }

        private static readonly Container instance = new Container();
        ///<summary>
        ///构造方法---私有化的
        ///</summary>
        private Container()
        {
            //初始化Castle
            try
            {
                interpreter = new XmlInterpreter("Config/Service.xml");
                winsor = new WindsorContainer(interpreter);
                kernel = winsor.Kernel;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 反射方法
        /// </summary>
        public T Reslove<T>()
        {
            return (T)kernel.Resolve<T>();
        }

        /// <summary>
        /// 反射方法
        /// </summary>
        public T Reslove<T>(string key)
        {
            return (T)kernel.Resolve<T>(key);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            kernel.Dispose();
        }
    }
}
