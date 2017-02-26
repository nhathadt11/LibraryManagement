drop database LibraryManagementV2
create database LibraryManagementV2
use [LibraryManagementV2]
select * from Books
select * from Categories


create table Roles(
RoleId int primary key IDENTITY(1,1),
Name nvarchar(300) not null
)

--* procedure accept 1 param as Role name and return role ID if insert transaction successfully*--
--* else return -1 if this role already existed *--
--param @Name required--
drop procedure InsertRole
create procedure InsertRole(
@Name nvarchar(300)
) as
begin
	SET NOCOUNT OFF;
	if not exists (select * from Roles Where Name = @Name)
		begin
			insert into Roles values(@Name)
			return SCOPE_IDENTITY();
		end
	else
		begin
			return -1;
		end
end
--* test InsertRole procedure *---
DECLARE @Id int
EXEC InsertRole @Name=N'admin', @RoleId=@Id output;
print @Id
select * from Roles
--*procedure DeleteRoleByID return 1 if transaction successfull*--
--*else return 0*--
--param @RoleID, @Status required --
drop procedure DeleteRoleByID
create procedure DeleteRoleByID(
@RoleID int
) as
begin
	SET NOCOUNT OFF;
	if not exists (select * from Users where  RoleId= @RoleID)
		begin
			if exists (select * from Roles where RoleId = @RoleID)
				begin
					delete from Roles where RoleId = @RoleID;
					return @@ROWCOUNT;
				end
			else 
				begin
					return 0;
				end
		end
	else
		begin
			return -1;
		end
	
end
--*test DeleteRoleByID procedure*--
DECLARE @st int
EXEC DeleteRoleByID @RoleID='8', @Status = @st output;
print @st
--*procedure DeleteRoleByName return 1 if transaction successfullly*--
--params @Name, @Status required--
drop procedure DeleteRoleByName;
create procedure DeleteRoleByName(
@Name nvarchar(300),
@Status int output 
) as
begin
	set nocount off;
	if  not exists (select * from Users where RoleId in (select RoleId from Roles where Name = @Name))
	begin
	delete from Roles where Name = @Name;
	end
	set @Status = @@ROWCOUNT;
	return @Status;
end
--*test DeleteRoleByName procedure*--
declare @st int
exec DeleteRoleByName @Name = N'admin', @Status = @st output;
print @st
select * from Users
select * from Roles
------------------------------------------------
create table Users(
UserId int primary key IDENTITY(1,1),
Username nvarchar(300) not null,
Password nvarchar(60) not null,
PhoneNumber nvarchar(11) default N'N/A',
Address nvarchar(600) default N'N/A',
Email nvarchar(50) default N'N/A',
RoleId int foreign key references Roles(RoleId),
)
--*procedure InsertUser return ID > 0 if insert successfully else return -1*--
--params @UserId, @Username, @Password, @RoleId are required--
--params @PhoneNumber, @Address, @Email are optional--
drop procedure InsertUser
create procedure InsertUser(
@Username nvarchar(300),
@Password nvarchar(60),
@RoleId int,

@PhoneNumber nvarchar(11) = null,
@Address nvarchar(600) = null,
@Email nvarchar(50) = null
) as
begin
	set nocount off;
	if not exists (select * from Users where Username = @Username)
		begin
			insert into Users values (@Username, @Password, @PhoneNumber, @Address, @Email, @RoleId);
			return SCOPE_IDENTITY();
		end
	else
		begin
			return -1;
		end
end
--*test InserUser procedure*--
--**--
declare @id int
exec InsertUser @Username =N'test2', @Password = N'test2', @UserId = @id output, @RoleId = 8, @PhoneNumber = N'01648741511';
print @id
select * from Roles
select * from Users
------------------------------------------------
create table Categories(
CategoryId int primary key IDENTITY(1,1),
Name nvarchar(300) not null
)
--*procedure InsertCategory*--
--return CategoryID if insert successfully and -1 in the opposite
drop procedure InsertCategory
create procedure InsertCategory(
@Name nvarchar(300)
) as
begin
	if not exists (select * from Categories where Name = @Name)
		begin
			insert into Categories values (@Name);
			return SCOPE_IDENTITY();
		end
	else
		begin
			return -1;
		end
end
--test InsertCategory procedure--
declare @id int
exec InsertCategory @Name = N'sss', @CategoryID = @id output;
print @id
select * from Categories
--*procedure DeleteCategoryByID return > 0 if deletesuccessfully*--
-- return -1 if this category already reference by the other--
-- return 0 if this category does not exist
-- param @CategoryID, @Status --
drop procedure DeleteCategoryByID
create procedure DeleteCategoryByID(
@CategoryID int
) as
begin
	if not exists (select * from Categories where CategoryId = @CategoryID)
		begin
			return 0;
		end
	else
		begin
			if exists (select * from Books where Books.CategoryId = @CategoryID)
				begin
					return -1;
				end
			else
				begin
					delete from Categories where Categories.CategoryId = @CategoryID;
					return @@ROWCOUNT;
				end
		end
end
--*procedure DeleteCategoryByName*--
-- param @Name--
-- return > 0 if delete successfully--
-- return 0 if that category does not exist--
-- return -1 if that category has already reference by the other books--
delete from Authors
delete from Publishers
delete from Books
select * from Authors
select * from Publishers
select * from Books

drop procedure DeleteCategoryByName
create procedure DeleteCategoryByName(
@Name nvarchar(300),
@Status int output
) as
begin
	if not exists (select * from Categories where Name = @Name)
		begin
			set @Status = 0;
			
		end
	else 
		begin
			if not exists (select * from Books where CategoryId in (select * from Categories where Name = @Name))
				begin
					delete from Categories where Name = @Name;
					set @Status = @@ROWCOUNT;
				end
			else 
				begin
					set @Status = -1;
				end
		end
	return @Status;
end
------------------------------------------------
create table Authors(
AuthorId int primary key IDENTITY(1,1),
FullName nvarchar(300) not null,
Contact nvarchar(1000) default N'N/A',
Address nvarchar(300) default N'N/A',
Bio nvarchar(MAX) default N'N/A',
)
--*procedure InsertAuthor*--
--param @FullName required--
--params @Contact, @address, @Bio are optional--
--return @AuthorID --
drop procedure InsertAuthor 
create procedure InsertAuthor(
@FullName nvarchar(300),
@Contact nvarchar(1000) = null,
@Address nvarchar(300) = null,
@Bio nvarchar(MAX) = null
) as
begin
	set nocount off;
	insert into Authors values(@FullName, @Contact, @Address, @Bio);
	return SCOPE_IDENTITY();
end
--procedure DeleteAuthorByID--
--param @AuthorID required --
--return > 0 if DeleteSuccessFully--
--return 0 if this ID not exist--
--return -1 if this Author has already reference by the other (Books)--
drop procedure DeleteAuthorByID
create procedure DeleteAuthorByID(
@AuthorId int
) as
begin
	if not exists (select * from Authors Where AuthorId = @AuthorId)
		begin
			return 0;
		end
	else
		begin
			if exists (select * from Books where AuthorId = @AuthorId)
				begin
					return -1;
				end
			else 
				begin
					delete from Authors where AuthorId = @AuthorId;
					return @@ROWCOUNT;
				end
		end
end

------------------------------------------------
create table Publishers(
PublisherId int primary key IDENTITY(1,1),
Name nvarchar(300) not null,
Contact nvarchar(1000) default N'N/A',
Address nvarchar(300) default N'N/A',
Description nvarchar(MAX) default N'N/A'
)
--*procedure InserPublisher*--
--param @Name, @PublisherId required--
--params @Contact, @Address, @Description are optional--
--return @PublisherId
drop procedure InserPublisher
create procedure InserPublisher(
@Name nvarchar(300),
@Contact nvarchar(1000) = null,
@Address nvarchar(300) = null,
@Description nvarchar(MAX) = null
) as
begin
	insert into Publishers values(@Name, @Contact, @Address, @Description);
	return SCOPE_IDENTITY();
end
--*procedure DeletePublisherByID*--
drop procedure DeletePublisherByID
create procedure DeletePublisherByID(
@PublisherId int
) as
begin
	if not exists (select * from Publishers where PublisherId = @PublisherId) return 0;
	if exists (select * from Books where PublisherId = @PublisherId) return -1;
	else
		begin
			delete from Publishers where PublisherId = @PublisherId;
			return @@Rowcount;
		end
end
--param @PublisherId, @Status --
------------------------------------------------
drop table Books
create table Books(
BookId int primary key IDENTITY(1,1),
Isbn nvarchar(MAX),
Title nvarchar(MAX) not null,
Description nvarchar(MAX) default N'N/A',
CoverImageUrl nvarchar(MAX) default N'DefaultCover.jpg',
PageNumber int,
PublishedDate date,
AuthorId int foreign key references Authors(AuthorId),
CategoryId int foreign key references Categories(CategoryId),
PublisherId int foreign key references Publishers(PublisherId),
Discontinued bit default 0
)
drop procedure InsertBook
create procedure InsertBook(
@Isbn nvarchar(MAX) = N'N/A',
@Title nvarchar(MAX),
@Description nvarchar(MAX) = N'N/A',
@CoverImageUrl nvarchar(MAX) = N'DefaultCover.jpg',
@PageNumber int = 300,
@PublishedDate date = getdate,
@AuthorId int,
@CategoryId int,
@PublisherId int,
@Discontinued bit = 0
)as
begin
	if not exists (select * from Authors where AuthorId = @AuthorId) return -1;
	if not exists (select * from Publishers where PublisherId = @PublisherId ) return -2;
	if not exists (select * from Categories where CategoryId = @CategoryId) return -3;
	else
		begin
			insert into Books values (@Isbn, @Title, @Description, @CoverImageUrl, @PageNumber, @PublishedDate, @AuthorId, @CategoryId, @PublisherId, @Discontinued);
			return SCOPE_IDENTITY();
		end
end
drop procedure DeleteBookById
create procedure DeleteBookById(
@BookId int
) as
begin
	if exists (select * from Copies where BookId = @BookId) return -1;
	if not exists (select * from Books where BookId = @BookId) return 0;
	begin
		delete from Books where BookId = @BookId;
		return @@ROWCOUNT;
	end
end
drop view vBooks
create view vBooks as
select 
	b.BookId as Id, b.Title as Title, b.Isbn as ISBN, (select count(CopyId) from Copies) as Copies,b.PageNumber as NumOfPage, b.PublishedDate as PublishDate, 
	c.Name as Category, a.FullName as Author, p.Name as Publisher,
	b.Discontinued as Discontinued, b.Description as Description, b.CoverImageUrl as Cover
from
	Books b,
	Categories c,
	Authors a,
	Publishers p
where
	b.CategoryId = c.CategoryId and
	b.AuthorId = a.AuthorId and
	b.PublisherId = p.PublisherId
select * from vBooks

------------------------------------------------
drop table Copies
create table Copies(
CopyId int primary key Identity(1,1),
BookId int foreign key references Books(BookId),
IsAvalable bit default 1
)
drop procedure InsertCopy
create procedure InsertCopy(
@BookId int
) as
begin
	if not exists (select * from Books where BookId = @BookId) return -1;
	insert into Copies values(@BookId, 1);
	return @@ROWCOUNT;
end


create procedure DeleteCopiesById(
@CopyId int
) as
begin
	if not exists (select * from Copies where CopyId = @CopyId) return 0;
	if exists (select * from LoanDetails where CopyId = @CopyId) return -1;
	delete from Copies  where CopyId = @CopyId;
	return @@ROWCOUNT;
end

create view vCopies as
select * 
from Copies c, vBooks b
where c.BookId = b.Id

select * from vCopies
------------------------------------------------
drop table Loans
create table Loans(
LoanId int primary key IDENTITY(1,1),
IssueDate datetime DEFAULT GETDATE(),
Limit int DEFAULT 5,
MemberId int foreign key references Users(UserId) not null,
LibrarianId int foreign key references Users(UserId) not null,
)
create procedure InsertLoan(
@IssueDate datetime = getdate,
@Limit int = 5,
@MemberId int,
@LibrarianId int
) as
begin
	if not exists (select * from Users where UserId = @MemberId) return -1;
	if not exists (select * from Users where UserId = @LibrarianId) return -2;
	insert into Loans values(@IssueDate, @Limit, @MemberId, @LibrarianId);
	return @@ROWCOUNT;
end

drop procedure DeleteLoanById
create procedure DeleteLoanById(
@LoanId int
) as
begin
	if exists (select * from LoanDetails where LoanId = @LoanId) return -1;
	if not exists (select * from Loans) return 0;
	delete from Loans where LoanId = @LoanId;
	return @@ROWCOUNT;
end
------------------------------------------------
drop table LoanDetails
create table LoanDetails(
LoanDetailId int primary key,
CopyId int foreign key references Copies(CopyId),
LoanId int foreign key references Loans(LoanId),
ReturnDate date DEFAULT null
)
use [LibraryManagementV2]

drop procedure InsertLoanDetail

create procedure InsertLoanDetail(
@CopyId int,
@LoanId int,
@ReturnDate date
) as
begin
	if not exists (select * from Copies where CopyId = @LoanId ) return -1;
	if not exists (select * from Loans where LoanId = @LoanId) return -2;

	insert into LoanDetails values(@CopyId, @LoanId, @ReturnDate);
	update Copies set IsAvalable = 0 where CopyId = @CopyId;

	return SCOPE_IDENTITY();
end
------------------------------------------------