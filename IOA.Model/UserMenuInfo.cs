using System; 

namespace HN.Model
{
	/// <summary>
	/// 用户菜单表
	/// Author 2020-07-22
	/// </summary>  
    public class UserMenuInfo
	{
   		private int _userid;
		private int _menuid;
				
      	/// <summary>
		/// 用户ID
        /// </summary>
        public int UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }
        /// <summary>
		/// 菜单ID
        /// </summary>
        public int MenuID
        {
            get{ return _menuid; }
            set{ _menuid = value; }
        }
        		
    }
}