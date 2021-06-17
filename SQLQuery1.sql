--�������ݿ�
create database OADB
go
use OADB
----��������֯���ű�
--create table Department
--(
--    DeptID            int primary key identity(10000,1),--����ID
--    DeptName          nvarchar(50),--����
--    ParentID          int,--�ϼ�ID
--    FullID            nvarchar(200),--�����ϼ�ID
--    Manger            nvarchar(20),--������
--    Phone             nvarchar(20),--�����˵绰
--    Sort              int,--��ʾ˳��
--    Status            int,--״̬(0ͣ�� 1���� Ĭ��1)
--)
--�������û���
go
create table Users
(
     UserID           int primary key identity(1000,1),--�û�ID
    -- DeptID           int foreign key references Department(DeptID),--�û�����ID
     LoginName        nvarchar(50),--��¼��
     Pwd              nvarchar(40),--����
     DeleteMark       int,--ɾ�����(0���� 1ɾ�� Ĭ��0)
     IsAdmin          int,--��������Ա���(0�� 1�� Ĭ��1)
     [Status]           int,--״̬(0ͣ�� 1���� Ĭ��1)
  
)
go
--��������ɫ��
create table Roles
(
      RolesID      int primary key identity,--��ɫID
	  RolesName    nvarchar(50),--��ɫ����
	  Sort         int,--��ʾ˳��
	  Remark       nvarchar(200),--��ע
	  CreateName   nvarchar(20),--������
	  CreateDate   datetime,--����ʱ��
)
go
--�������˵���
create table Menu
(
     MenuID        int primary key identity,--�˵�ID
	 MenuParentID  int,--                     �ϼ��˵�ID
	 MenuName      nvarchar(50),--            �˵�����
	 MenuLink      nvarchar(50),--            �˵����ӵ�ַ
	 MenuIcon      nvarchar(50),--            ͼ��
	 MenuStatus    int,--                     ״̬��0ͣ�� 1���� Ĭ��1��
	 Sort          int,--                     ��ʾ˳��
)
go
--��������ɫ�˵���
create table RoleMenu
(
       RoleID    int foreign key references Roles(RolesID),--��ɫID
	   MenuID    int foreign key references Menu(MenuID),--�˵�ID
)
go
--�������û���ɫ��
create table UsersRole
(
      UserID    int foreign key references Users(UserID),--�û�ID
	  RoleID    int foreign key references Roles(RolesID),--��ɫID
)
go
select Roles.RolesID,Menu.MenuName,Menu.MenuID from RoleMenu join Roles on Roles.RolesID=RoleMenu.RoleID join Menu on Menu.MenuID=RoleMenu.MenuID
select Roles.RolesName,Menu.MenuName from Roles join RoleMenu on Roles.RolesID=RoleMenu.RoleID join Menu on Menu.MenuID=RoleMenu.MenuID
select * from Users where LoginName='�Ž�'and pwd='789'
--�û�   �û���ɫ   ��ɫ   ��ɫȨ��   Ȩ��(�˵�)
select * from Users
select * from Menu
select MenuID,MenuName,MenuParentID  from menu
select * from Roles
select * from RoleMenu
select * from UsersRole
--�û���ɫȨ�޲�ѯ
select e.MenuID,e.MenuLink,e.MenuIcon,e.Sort,e.MenuStatus,e.MenuParentID,e.MenuName from Users a inner join 
UsersRole b on a.UserID=b.UserID 
inner join Roles c on b.RoleID=c.RolesID
inner join RoleMenu d on c.RolesID=d.RoleID
inner join Menu e on d.MenuID=e.MenuID where a.UserID=1000 and e.MenuParentID=0 order by e.Sort



--�����û���Ȩ��
select RoleMenu.MenuID,Menu.MenuName,Menu.MenuLink,Menu.MenuIcon,Menu.Sort from RoleMenu join Menu on Menu.MenuID=RoleMenu.MenuID join UsersRole on RoleMenu.RoleID=UsersRole.RoleID join Users on Users.UserID=UsersRole.UserID where Menu.MenuParentID=4  and Users.UserID=1000

--update Menu set MenuLink='/Users/UsersManagement' where MenuID=17
insert  into  Users values
('�Ž�','YksLnsjymIB4SBEBQVoLTA==','0','1','1'),
('������','YksLnsjymIB4SBEBQVoLTA==',0,1,1)
go
insert into Roles values
('��������Ա','1','��������','�Ž�','2021-6-2'),
('��ͨԱ��','2','��ͨ��ɾ�Ĳ�','�Ž�','2021-6-2'),
('����Ա','2','��ͨ��ɾ�Ĳ�','�Ž�','2021-6-2'),
('�����Ա','2','ϵͳ����','�Ž�','2021-6-2'),
('ֻ����Ա','2','�ٶȵ�ͼ','�Ž�','2021-6-2')
go
insert into Menu values
(0,'ϵͳ����','','',1,''),(0,'�칫ͨ��','','',1,''),(0,'���ù���','','',1,''),
(1,'��֯��Ա','','',1,''),(1,'��������','','',1,''),(1,'����ͼ��','','',1,''),(1,'ϵͳ��־','','',1,''),(1,'Ȩ�޹���','','',1,''),
(2,'�������','','',1,''),
(3,'֪ͨ����','','',1,''),(3,'����Excel','','',1,''),(3,'����Excel','','',1,''),(3,'����ɾ��','','',1,''),(3,'�ļ��ϴ�','','',1,''),(3,'�����ʾ��','','',1,''),(3,'�ٶȵ�ͼ','','',1,''),
(4,'�û�����','','',1,''),(4,'��֯����','','',1,''),(4,'��ɫ����','','',1,''),(4,'�˵�����','','',1,''),
(5,'��������','','',1,''),
(9,'��������','','',1,''),(9,'��ٹ���','','',1,''),
(5,'�ֵ����','','',1,'')
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





