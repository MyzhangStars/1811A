using HN.Model;
using IOA.Common;
using IOA.Common.Context;
using IOA.IRepository;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.Repository
{
    public class UserRepository : BaseRepository<UsersInfo>, IUserRepository
    {

        //登录
        public UsersInfo Login(string loginName = null, string pwd = null)
        {
            string sql = "select * from Users where LoginName=@loginName and pwd=@pwd";
            UsersInfo list = DapperHelper<UsersInfo>.QuerySingle(sql, new { @loginName = loginName, @pwd = pwd });
            return list;
        }
        //显示
        public List<UsersInfo> UserShow()
        {
            string sql = "select * from Users";
            List<UsersInfo> data = DapperHelper<UsersInfo>.Query(sql, "");
            return data;
        }



    }
}
