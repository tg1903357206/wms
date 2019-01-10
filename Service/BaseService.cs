using com.tg.WMS.Domain;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Service
{
    public interface BaseService<T> where T : BaseEntity<T>, new()
    {
        /// <summary>
        /// 新增
        /// </summary>
        void Create(T t);

        /// <summary>
        /// 修改
        /// </summary>
        void Update(T t);

        /// <summary>
        /// 删除
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// 获取全部实体
        /// </summary>
        IList<T> GetAll();

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        T GetEntity(int id);

        /// <summary>
        /// 查询符合条件的实体
        /// </summary>
        IList<T> Query(IList<ICriterion> condition);
    }
}
