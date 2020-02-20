create procedure [dbo].[sp_InsertUser]
	@Name nvarchar(50),
	@DateOfBirth date,
	@UserImage nvarchar(MAX)
as
	insert into users (Name, DateOfBirth, UserImage) 
	output inserted.Id
	values (@Name, @DateOfBirth, @UserImage)
go

create procedure [dbo].[sp_GetAllUsers]
as
	select Id, Name, DateOfBirth, UserImage from users
go

create procedure [dbo].[sp_GetUserById]
	@Id int
as
	select Id, Name, DateOfBirth, UserImage 
	from users where Id=@Id
go

create procedure [dbo].[sp_UpdateUser]
	@Id int,
	@Name nvarchar(50),
	@DateOfBirth date,
	@UserImage nvarchar(MAX)
as
	update users
	set Name = @Name, DateOfBirth = @DateOfBirth,
		UserImage = @UserImage
	where Id = @Id
go

create procedure [dbo].[sp_GiveAward]
	@UserId int,
	@AwardId int
as
	insert into users_awards
	(UserId, AwardId) values (@UserId, @AwardId)
go

create procedure [dbo].[sp_RemoveUserById]
	@Id int
as
	delete from users where Id = @Id
go

create procedure [dbo].[sp_TakeAward]
	@UserId int,
	@AwardId int
as
	delete from users_awards
	where UserId = @UserId and AwardId = @AwardId
go

create procedure [dbo].[sp_RemoveAllUsers]
as
	delete from users
go


--Stored procedures for Awards
create procedure [dbo].[sp_InsertAward]
	@Title nvarchar(50),
	@AwardImage nvarchar(MAX)
as
	insert into awards(Title, AwardImage) 
	output inserted.Id
	values (@Title, @AwardImage)
go

create procedure [dbo].[sp_GetAllAwards]
as
	select Id, Title, AwardImage from awards
go

create procedure [dbo].[sp_UpdateAward]
	@Id int,
	@Title nvarchar(50),
	@AwardImage nvarchar(MAX)
as
	update awards
	set Title = @Title, AwardImage = @AwardImage
	where Id = @Id
go

create procedure [dbo].[sp_GetAwardById]
	@Id int
as
	select Id, Title, AwardImage 
	from awards where Id=@Id
go

create procedure [dbo].[sp_RemoveAllAwards]
as
	delete from awards
go

create procedure [dbo].[sp_RemoveAwardById]
	@Id int
as
	delete from awards where Id = @Id
go

create procedure [dbo].[sp_GetAwardsByUserId]
	@Id int
as
	select Id, Title, AwardImage from users_awards 
	join awards on AwardId = Id 
	where UserId = @Id
go

--Stored procedures for AuthUsers
create procedure [dbo].[sp_GiveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	insert into auth_users_roles
	(AuthUserId, RoleId)
	values((select Id from auth_users where Login = @Login),
	(select Id from roles where Name = @RoleName))
go

create procedure [dbo].[sp_RemoveRole]
	@Login nvarchar(50),
	@RoleName nvarchar(50)
as
	delete from auth_users_roles
	where 
	AuthUserId = 
	(select Id from auth_users where Login = @Login) and
	RoleId = 
	(select Id from roles where Name = @RoleName)
go

create procedure [dbo].[sp_InsertAuthUser]
	@Login nvarchar(50),
	@Password nvarchar(50)
as
	insert into auth_users 
	(Login, Password)
	values (@Login, @Password)
go

create procedure [dbo].[sp_GetAuthUserByLogin]
	@Login nvarchar(50)
as
	select Login, Password, Name from auth_users 
	join auth_users_roles on AuthUserId = Id
	join roles on RoleId = roles.Id
	where Login = @Login 
go

create procedure [dbo].[sp_GetAllAuthUser]
as
	select Login, Password, Name from auth_users 
	join auth_users_roles on AuthUserId = Id
	join roles on RoleId = roles.Id
go