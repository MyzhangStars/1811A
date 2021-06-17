using System; 

namespace HN.Model
{
	/// <summary>
	/// 角色节点权限
	/// Author 2020-08-07
	/// </summary>  
    public class RoleMenuInfo
	{
   		private int _roleid;
		private int _menuid;
				
      	/// <summary>
		/// 角色ID
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }
        /// <summary>
		/// 模块主键ID
        /// </summary>
        public int MenuID
        {
            get{ return _menuid; }
            set{ _menuid = value; }
        }
        		
    }
}