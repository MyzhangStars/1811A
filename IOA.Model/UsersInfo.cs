using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
	/// <summary>
	/// 用户表
	/// Author 2020-05-13
	/// </summary>  
    public class UsersInfo
	{
   		private int _userid;
		private string _loginname;
		private string _pwd;
		private int _deletemark=0;
		private int _isadmin=0;
		private int _status=1;

        /// <summary>
        /// 主键ID
        /// </summary>
        /// 
        [Key]
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get{ return _loginname; }
            set{ _loginname = value; }
        }
        /// <summary>
		/// 密码
        /// </summary>
        public string Pwd
        {
            get{ return _pwd; }
            set{ _pwd = value; }
        }
     
        /// <summary>
		/// 删除标记 0正常 1删除
        /// </summary>
        public int DeleteMark
        {
            get{ return _deletemark; }
            set{ _deletemark = value; }
        }
        /// <summary>
		/// 是否系统管理员 
        /// </summary>
        public int IsAdmin
        {
            get{ return _isadmin; }
            set{ _isadmin = value; }
        }
        /// <summary>
		/// 状态 0 停用 1启用
        /// </summary>
        public int Status
        {
            get{ return _status; }
            set{ _status = value; }
        }
        		
    }
}