using HN.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOA.IRepository
{
   public  interface IUserRepository:IBaseRepository<UsersInfo>
    {
        //登录
        UsersInfo Login(string loginName = null, string pwd = null);

        //获取菜单栏
        List<UsersInfo> UserShow();
       
    }
}
