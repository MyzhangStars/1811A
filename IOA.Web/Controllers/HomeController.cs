using System.Data;
using IOA.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IOA.IRepository;
using Model;
using HN.Utility;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Server.HttpSys;
using HN.Model;

namespace HN.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //主题页
        public ActionResult Theme()
        {
            return View();

        }                       

        //获取菜单的方法
        public List<MenuInfo> GetMenu(int prentId)
        {
            string sql = "select RoleMenu.MenuID,Menu.MenuName,Menu.MenuLink,Menu.MenuIcon,Menu.Sort from RoleMenu join Menu on Menu.MenuID=RoleMenu.MenuID join UsersRole on RoleMenu.RoleID=UsersRole.RoleID join Users on Users.UserID=UsersRole.UserID where Menu.MenuParentID=@ParentId  and Users.UserID=@UserId";
            List<MenuInfo> menus = DapperHelper<MenuInfo>.Query(sql, new { @UserId = HttpContext.Session.GetString("UserID"), @ParentId = prentId });
            return menus;
        }

        //首页（视图）
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpGet]
        public ActionResult Default(int menuParentID = 0)
        {
            var auth = HttpContext.AuthenticateAsync();//获取对象
            auth.Result.Principal.Claims.Where(p => p.Type == ClaimTypes.Sid);
            auth.Result.Principal.Claims.Where(p => p.Type == ClaimTypes.GivenName);

            ViewBag.UserName = HttpContext.Session.GetString("UserName");
            string topMenu = "";
            string theme = "theme-black";
            ViewBag.Theme = theme;
            if (menuParentID == 0)
            {
                //获取顶级菜单栏
                List<MenuInfo> list = GetMenu(menuParentID);
                foreach (var item in list)
                {
                    if (item.MenuLink == null || item.MenuLink == "")
                    {
                        item.MenuLink = "javascript:; ";

                    }
                    topMenu += "<li class='layui-nav-item' lay-unselect><a onclick='DisPlayMEnu(" + item.MenuID + ")' lay-key='" + item.MenuID + "'><i class='" + item.MenuIcon + "'></i>" + item.MenuName + "</a></li>";

                    ViewBag.TopMenu = topMenu;
                }
            }
            return View();
        }
        //左侧菜单
        public string  GetLeftMenu(int parentID)
        {
            string topMenu = "";
            //获取左侧菜单栏
            List<MenuInfo> left = GetMenu(parentID);
            topMenu += "<li class='layui-nav-item'><a href='/Home/Default'><i class='layui-icon layui-icon-app'></i><cite>&nbsp;&nbsp;控制台</cite></a></li>";
            foreach (var litem in left)
            {
                if (litem.MenuLink == null || litem.MenuLink == "")
                {
                    litem.MenuLink = "javascript:;";
                }
                
                topMenu += "<li class='layui-nav-item layui-nav-itemed'><a class='' href=" + litem.MenuLink + " lay-key='" + litem.MenuID + "><i class='" + litem.MenuIcon + "'></i>" + litem.MenuName + "</a>";
                //判断是否有子级菜单
                List<MenuInfo> child = GetMenu(litem.MenuID);
                if (child.Count > 0)
                {
                    topMenu += "<dl class='layui-nav-child'>";
                    foreach (var a in child)
                    {
                        if (a.MenuLink == null || a.MenuLink == "")
                        {
                            a.MenuLink = "javascript:;";

                        }
                        topMenu += "<dd><a href =" + a.MenuLink + " target='ifrs'>" + a.MenuName + "<i class='" + a.MenuIcon + "'></i></a></ dd>";
                    }
                    topMenu += "</dl>";
                }
                topMenu += "</li>";
            }
           
            return topMenu;
        }

        //登录页面(视图)
        public ActionResult Login()
        {
            return View();
        }

        //生成验证码
        public ActionResult VerifyCode()
        {
            string code = ValidateCodeHelper.GetCode(4);
            HttpContext.Session.SetString("code", code);
            var file = ValidateCodeHelper.ValidateCode(code);
            return File(file, @"image/Png");
        }
        //登录
        [HttpPost]
        public string Login(string loginName = null, string pwd = null, string code = null)
        {
            var strReturn = "";
            if (HttpContext.Session.GetString("code") != null && code.ToLower() == HttpContext.Session.GetString("code").ToString().ToLower())
            {
                UsersInfo usersinfo = _userRepository.Login(loginName, DESEncrypt.DESEncrypts(pwd));
                if (usersinfo != null && usersinfo.DeleteMark == 0)
                {
                    if (usersinfo.Status == 1)
                    {
                        //清空验证码
                        HttpContext.Session.SetString("code", "");

                        //保存用户登录信息
                        HttpContext.Session.SetString("UserID", usersinfo.UserID.ToString());
                        HttpContext.Session.SetString("UserName", usersinfo.LoginName);
                        HttpContext.Session.SetInt32("IsAdmin", usersinfo.IsAdmin == 1 ? 1 : 0);

                        //存cokie 
                        var cslaim = new List<Claim>()
                        {
                            new Claim(ClaimTypes.Sid,usersinfo.UserID.ToString()),
                            new Claim(ClaimTypes.GivenName,usersinfo.LoginName),
                        };
                        //返回当前windows用户的windowsIdentity对象  获取用于标识用户身份验证的类型（覆盖ClaimsIdtity.AuthenticationType）
                        string token = System.Security.Principal.WindowsIdentity.GetCurrent().AuthenticationType;
                        var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(cslaim, token));
                        AuthenticationHttpContextExtensions.SignInAsync(HttpContext, userPrincipal);
                    }
                    else
                    {
                        strReturn = "3";
                    }
                }
                else
                {
                    strReturn = "2";
                }
            }
            else
            {
                strReturn = "1";
            }
            return strReturn;
        }
        //退出登录
        public ActionResult Logout()
        {
            HttpContext.Session.SetString("UserID", "");
            HttpContext.Session.SetString("LoginName", "");
            return RedirectToAction("Login", "Home");
        }


    }
}
