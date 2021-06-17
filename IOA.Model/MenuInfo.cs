using System; 

namespace HN.Model
{
	/// <summary>
	/// 菜单表
	/// Author 2020-07-08
	/// </summary>  
    public class MenuInfo
	{
   		private int _menuid;
		private int _parentid;
		private string _menuname;
		private string _link;
		private string _icon;
		private int _status=1;
		private int _sort;
				
      	/// <summary>
		/// 主键
        /// </summary>
        public int MenuID
        {
            get{ return _menuid; }
            set{ _menuid = value; }
        }
        
        /// <summary>
		/// 上级模块
        /// </summary>
        public int MenuParentID
        {
            get{ return _parentid; }
            set{ _parentid = value; }
        }
        /// <summary>
		/// 菜单名称
        /// </summary>
        public string MenuName
        {
            get{ return _menuname; }
            set{ _menuname = value; }
        }
        /// <summary>
		/// 链接地址
        /// </summary>
        public string MenuLink
        {
            get{ return _link; }
            set{ _link = value; }
        }
        /// <summary>
		/// 图标
        /// </summary>
        public string MenuIcon
        {
            get{ return _icon; }
            set{ _icon = value; }
        }
        /// <summary>
		/// 状态 0 禁用 1启用
        /// </summary>
        public int MenuStatus
        {
            get{ return _status; }
            set{ _status = value; }
        }
 
        /// <summary>
		/// 排序
        /// </summary>
        public int Sort
        {
            get{ return _sort; }
            set{ _sort = value; }
        }
        		
    }
}