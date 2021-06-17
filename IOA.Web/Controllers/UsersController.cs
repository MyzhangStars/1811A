using IOA.IRepository;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOA.Web.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //用户管理（视图）
        public IActionResult UsersManagement()
        {
            return View();
        }
        //显示
        public IActionResult Show()
        {
            List<UsersInfo> data = _userRepository.UserShow();
            return Ok(new { data=data,count=0,code=0});
        }
    }
}
