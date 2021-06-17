--创建数据库
create database OADB
go
use OADB
----创建表（组织部门表）
--create table Department
--(
--    DeptID            int primary key identity(10000,1),--部门ID
--    DeptName          nvarchar(50),--名称
--    ParentID          int,--上级ID
--    FullID            nvarchar(200),--所有上级ID
--    Manger            nvarchar(20),--负责任
--    Phone             nvarchar(20),--负责人电话
--    Sort              int,--显示顺序
--    Status            int,--状态(0停用 1启用 默认1)
--)
--创建表（用户表）
go
create table Users
(
     UserID           int primary key identity(1000,1),--用户ID
    -- DeptID           int foreign key references Department(DeptID),--用户部门ID
     LoginName        nvarchar(50),--登录名
     Pwd              nvarchar(40),--密码
     DeleteMark       int,--删除标记(0正常 1删除 默认0)
     IsAdmin          int,--超级管理员标记(0否 1是 默认1)
     [Status]           int,--状态(0停用 1启用 默认1)
  
)
go
--创建表（角色表）
create table Roles
(
      RolesID      int primary key identity,--角色ID
	  RolesName    nvarchar(50),--角色名称
	  Sort         int,--显示顺序
	  Remark       nvarchar(200),--备注
	  CreateName   nvarchar(20),--创建人
	  CreateDate   datetime,--创建时间
)
go
--创建表（菜单表）
create table Menu
(
     MenuID        int primary key identity,--菜单ID
	 MenuParentID  int,--                     上级菜单ID
	 MenuName      nvarchar(50),--            菜单名称
	 MenuLink      nvarchar(50),--            菜单链接地址
	 MenuIcon      nvarchar(50),--            图标
	 MenuStatus    int,--                     状态（0停用 1启用 默认1）
	 Sort          int,--                     显示顺序
)
go
--创建表（角色菜单表）
create table RoleMenu
(
       RoleID    int foreign key references Roles(RolesID),--角色ID
	   MenuID    int foreign key references Menu(MenuID),--菜单ID
)
go
--创建表（用户角色表）
create table UsersRole
(
      UserID    int foreign key references Users(UserID),--用户ID
	  RoleID    int foreign key references Roles(RolesID),--角色ID
)
go
select Roles.RolesID,Menu.MenuName,Menu.MenuID from RoleMenu join Roles on Roles.RolesID=RoleMenu.RoleID join Menu on Menu.MenuID=RoleMenu.MenuID
select Roles.RolesName,Menu.MenuName from Roles join RoleMenu on Roles.RolesID=RoleMenu.RoleID join Menu on Menu.MenuID=RoleMenu.MenuID
select * from Users where LoginName='张健'and pwd='789'
--用户   用户角色   角色   角色权限   权限(菜单)
select * from Users
select * from Menu
select MenuID,MenuName,MenuParentID  from menu
select * from Roles
select * from RoleMenu
select * from UsersRole
--用户角色权限查询
select e.MenuID,e.MenuLink,e.MenuIcon,e.Sort,e.MenuStatus,e.MenuParentID,e.MenuName from Users a inner join 
UsersRole b on a.UserID=b.UserID 
inner join Roles c on b.RoleID=c.RolesID
inner join RoleMenu d on c.RolesID=d.RoleID
inner join Menu e on d.MenuID=e.MenuID where a.UserID=1000 and e.MenuParentID=0 order by e.Sort



--根据用户找权限
select RoleMenu.MenuID,Menu.MenuName,Menu.MenuLink,Menu.MenuIcon,Menu.Sort from RoleMenu join Menu on Menu.MenuID=RoleMenu.MenuID join UsersRole on RoleMenu.RoleID=UsersRole.RoleID join Users on Users.UserID=UsersRole.UserID where Menu.MenuParentID=4  and Users.UserID=1000

--update Menu set MenuLink='/Users/UsersManagement' where MenuID=17
insert  into  Users values
('张健','YksLnsjymIB4SBEBQVoLTA==','0','1','1'),
('郭天威','YksLnsjymIB4SBEBQVoLTA==',0,1,1)
go
insert into Roles values
('超级管理员','1','管理所有','张健','2021-6-2'),
('普通员工','2','普通增删改查','张健','2021-6-2'),
('管理员','2','普通增删改查','张健','2021-6-2'),
('审核人员','2','系统设置','张健','2021-6-2'),
('只阅人员','2','百度地图','张健','2021-6-2')
go
insert into Menu values
(0,'系统设置','','',1,''),(0,'办公通用','','',1,''),(0,'常用功能','','',1,''),
(1,'组织人员','','',1,''),(1,'基础数据','','',1,''),(1,'字体图标','','',1,''),(1,'系统日志','','',1,''),(1,'权限管理','','',1,''),
(2,'申请管理','','',1,''),
(3,'通知共告','','',1,''),(3,'导出Excel','','',1,''),(3,'导入Excel','','',1,''),(3,'批量删除','','',1,''),(3,'文件上传','','',1,''),(3,'主存表示列','','',1,''),(3,'百度地图','','',1,''),
(4,'用户管理','','',1,''),(4,'组织管理','','',1,''),(4,'角色管理','','',1,''),(4,'菜单管理','','',1,''),
(5,'基础数据','','',1,''),
(9,'车辆申请','','',1,''),(9,'请假管理','','',1,''),
(5,'字典管理','','',1,'')
go
insert into RoleMenu values
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),(1,14),(1,15),(1,16),(1,17),(1,18),(1,19),(1,20),(1,21),(1,22),(1,23),
(4,16),(4,1),(4,4),(4,17),(4,18),(4,4),(4,24),(4,19),(4,20),(4,3),(4,5),
(5,16)
go
select * from Users
select * from Roles
go
insert into UsersRole values
(1000,1),(1000,2),(1001,2),(1001,4),(1001,3)

select * from Menu where MenuParentID=0





