using System; 

namespace HN.Model
{
	/// <summary>
	/// 用户角色表
	/// Author 2020-08-07
	/// </summary>  
    public class RoleUsersInfo
	{
   		private int _roleid;
		private int _userid;
				
      	/// <summary>
		/// 角色ID
        /// </summary>
        public int RoleID
        {
            get{ return _roleid; }
            set{ _roleid = value; }
        }
        /// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
        		
    }
}