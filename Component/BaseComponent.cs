using com.tg.WMS.Manager;
using com.tg.WMS.Service;
using com.tg.WMS.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Component
{
    public class BaseComponent<T, M> : BaseService<T>
        where T : BaseEntity<T>, new()
        where M : BaseManager<T>, new()
    {
        protected M manager = (M)typeof(M).GetConstructor(Type.EmptyTypes).Invoke(null);

        /// <summary>
        /// 新增
        /// </summary>
        public void Create(T t)
        {
            manager.Create(t);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void Update(T t)
        {
            manager.Update(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(int id)
        {
            manager.Delete(id);
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        public IList<T> GetAll()
        {
            return manager.GetAll();
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        public T GetEntity(int id)
        {
            return manager.GetEntity(id);
        }

        /// <summary>
        /// 查询符合条件的实体
        /// </summary>
        public IList<T> Query(IList<ICriterion> condition)
        {
            return manager.Query(condition);
        }
    }
}
