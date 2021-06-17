using IOA.Common;
using IOA.Common.Context;
using IOA.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IOA.Repository
{
    //base表

    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {

        public   readonly OnContext _onContext;
        public BaseRepository()
        {
            _onContext = new OnContext();
        }


        /// <summary>
        /// Dapper增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="all">参数</param>
        /// <returns></returns>
        public int ZSG_Dapper(string sql, T t)
        {
            int i = DapperHelper<T>.Execute(sql, t);
            return i;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<T> According()
        {
            List<T> list = _onContext.Set<T>().ToList();
            return list;
        }

       
    }

}
