Use Test;

drop database Keyboard;

create database Keyboard

Use Keyboard;

Create table Role (
	RoleId int primary key Identity(1,1),
	RoleName varchar(255) not null,
	isActive bit not null,
);

Create table Users (
	UserId int primary key IDENTITY(1,1),
	UserName varchar(255) not null,
	Password varchar(255) not null,
	Phone varchar(10) null,
	Email varchar (255)not null,
	Address varchar (255) null,
	IsActive bit not null,
	CreateDate datetime not null,
);

Create table UserRole(
	UserRoleId int primary key IDENTITY(1,1),
	RoleId int foreign key references Role(RoleId) ,
	UserId int foreign key references Users(UserId)
);


Create table Permission (
	PermissionId int primary key Identity(1,1),
	GET bit not null,
	POST bit not null,
	PUT bit not null,
	DEL bit not null,
	IsActive bit not null
);


Create table PermissionRole(
	PermissionRoleId int primary key Identity(1,1),
	RoleId int foreign key references Role(RoleId),
	PermissionId int foreign key references Permission(PermissionId)
);

Create table Color(
	ColorId int primary key Identity(1,1),
	ColorName Nvarchar(255) not null,
	IsActive bit not null
);


Create table Brand(
	BrandId int primary key IDENTITY(1,1),
	BrandName Nvarchar(255) not null,
	Description ntext not null,
	IsActive bit not null
);

Create table Category(
	CategoryId int primary key Identity(1,1),
	CategoryName Nvarchar(255) not null,
	IsActive bit not null
);

Create table Product(
	ProductId int primary key Identity(1,1),
	ProductName Nvarchar(255) not null,
	ProductCode varchar (50) not null,
	ProductWeigt decimal(7,3),
	IsActive bit not null,
	CategoryId int foreign key references Category(CategoryId) ,
	BrandId int foreign key references Brand(BrandId)
);

Create table Quanlity(
	QuanlityId int primary key Identity(1,1),
	QuanlityName Nvarchar(255),
	IsActive bit
);

Create table ProductDetail(
	ProductDetailId int primary key Identity(1,1),
	ProductId int foreign key references Product(ProductId),
	ColorId int foreign key references Color (ColorId),
	Price money,
	QuanlityId int foreign key references Quanlity(QuanlityId),
	Image varchar(255),
	Description ntext
);


Create table ShopCart(
	ShopCartId int primary key Identity(1,1),
	UserId int Foreign key references Users(UserId),
	ProductId int foreign key references Product(ProductId)
);


Create table Logs(
	LogId int primary key Identity(1,1),
	Content varchar (255) not null,
	Type varchar(255) not null,
	Time datetime not null
);


