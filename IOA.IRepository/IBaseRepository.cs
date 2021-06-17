using System;
using System.Collections.Generic;

namespace IOA.IRepository
{
    public interface IBaseRepository<T> where T :class,new ()
    {
        //显示
        List<T> According();
        //增删改
        int ZSG_Dapper(string sql, T t);

    }
}
