using Castle.ActiveRecord;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Manager
{
   public class BaseManager<T> : ActiveRecordBase<T>
        where T : class
    {
        /// <summary>
        /// 新增
        /// </summary>
        public new void Create(T t)
        {
            ActiveRecordBase.Create(t);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public new void Update(T t)
        {
            ActiveRecordBase.Update(t);
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(int id)
        {
            T t = GetEntity(id);
            if (t != null)
            {
                ActiveRecordBase.Delete(t);
            }
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        public IList<T> GetAll()
        {
            return (IList<T>)ActiveRecordBase.FindAll(typeof(T));
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        public T GetEntity(int id)
        {
            return (T)ActiveRecordBase.FindByPrimaryKey(typeof(T), id);
        }

        /// <summary>
        /// 查询符合条件的实体
        /// </summary>
        public IList<T> Query(IList<ICriterion> condition)
        {
            return (IList<T>)ActiveRecordBase.FindAll(typeof(T), condition.ToArray());
        }
    }
}
