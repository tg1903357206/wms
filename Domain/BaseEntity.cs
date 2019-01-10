using Castle.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.tg.WMS.Domain
{
  public  class BaseEntity<T>: ActiveRecordBase
        where T:class
    {
        /// <summary>
        /// 主键
        /// </summary>
        [PrimaryKey(Generator = PrimaryKeyType.Native)]
        public int ID { get; set; }
    }
}
