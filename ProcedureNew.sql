Use Keyboard;

-- Permission
-- Show all Permission
Create Proc GetAllPermission as
begin
	Select * from Permission
end

-- Select Permission theo ten

Create Proc GetPermissionById
(
	@PermissionId int
)as
begin
	Select * from Permission where PermissionId = @PermissionId
end

-- Insert Permission

Create Proc AddPermission
(
	@GET bit,
	@POST bit,
	@PUT BIT,
	@DEL BIT

)as
begin 
	Insert into Permission(GET,POST,PUT,DEL,IsActive) values (@GET, @POST, @PUT, @DEL,1)
end

-- Update Permission
Create Proc UpdatePermission
(
	@GET bit,
	@POST bit,
	@PUT BIT,
	@DEL BIT,
	@IsActive bit,
	@PermissionId int
)as
begin 
	Update Permission Set GET = @GET , POST = @POST, PUT = @PUT,DEL = @DEL , IsActive = @IsActive Where PermissionId = @PermissionId
end

-- Delete Permission
create proc DeletePermission 
( 
	@PermissionId int
)as
begin
	Update Permission set GET = GET , POST = POST , PUT = PUT, DEL = DEL, IsActive = 0 Where PermissionId = @PermissionId
end





-- Role
-- Select Role
Create Proc GetAllRole
as
begin
 Select * from Role
end

-- Insert Role
Create Proc AddRole
(
	@RoleName nvarchar(255)
)as
begin
	Insert into Role (RoleName,IsActive) values ( @RoleName , 1)
end

--Update Role
Create Proc UpdateRole
( @RoleName nvarchar(255),
@IsActive bit,
@RoleId int
)as
begin
	Update Role Set RoleName = @RoleName , isActive = @IsActive Where RoleId = @RoleId
end

-- Delete Role
Create Proc DeleteRole
(
	@RoleId int
)as
begin
	Update Role Set RoleName = RoleName, isActive = 0 Where RoleId = @RoleId
end








-- PermissionRole
-- Select PermissionRole
Create Proc GetPermissionRole
as
begin
	Select * from PermissionRole
end

-- Insert PermissionRole
Create Proc AddPermissionRole
(
	@RoleId int,
	@PermissionId int
)as
begin
	Insert into PermissionRole (RoleId, PermissionId) values (  @RoleId ,  @PermissionID)
end

-- Update PermissionRole
Create Proc UpdatePermissionRole
(
	@RoleId int,
	@PermissionId int,
	@PermissionRoleId int
)as
begin 
	Update PermissionRole set RoleId = @RoleId , PermissionId = @PermissionId where PermissionRoleId = @PermissionRoleId
end

-- Delete PermissionRole
Create Proc DeletePermissionRole
(
	@PermissionRoleId int
)as
begin
	Delete from PermissionRole where PermissionRoleId = @PermissionRoleId
end








-- Users
-- Select Users
Create Proc GetAllUsers 
as
begin 
	Select * from Users
end


-- Insert Users
Create Proc AddUsers
( @UserName varchar(255),
 @Password varchar(255),
 @Phone varchar(10),
 @Email varchar(255),
 @Address varchar(255)
 )as
 begin
	insert into Users (UserName,Password,Phone,Email,Address,IsActive,CreateDate) values ( @UserName, @Password , @Phone, @Email,  @Address, 1 , getdate() )
end


-- Update Users
Create Proc UpdateUsers
(
@UserId int,
@UserName varchar(255),
 @Password varchar(255),
 @Phone varchar(10),
 @Email varchar(255),
 @Address varchar(255),
 @IsActive bit
)as
begin
	Update Users Set UserName = @UserName, Password = @Password , Phone = @Phone , Email = @Email , Address = @Address , IsActive = @IsActive Where UserId = @UserId
end

-- Delete Users
Create Proc DeleteUser
(
	@UserId int
)as
begin 
	Update Users Set UserName = UserName, Password = Password, Phone = Phone, Email = Email, Address = Address,  IsActive = 0 Where UserId = @UserId
end






-- UserRole
-- Select UserRole
Create  Proc GetAllUserRole
as begin 
 Select * from UserRole
end

-- Insert UserRole
Create Proc AddUserRole
(
	@UserId int,
	@RoleId int
)as
Begin  
	Insert into UserRole( UserId, RoleId) values ( @UserId , @RoleId)
end


-- Update UserRole
Create proc UpdateUserRole
(
	@UserId int,
	@RoleId int,
	@UserRoleId int

)as
begin 
	Update UserRole Set UserId = @UserId , RoleId = @RoleId Where UserRoleId = @UserRoleId
END

--Delete UserRole
Create Proc DeleteUserRole
(
	@UserRoleId int
)as
begin
	Delete FROM UserRole where UserRoleId = @UserRoleId
end






--Brand
-- SELECT
Create Proc GetAllBrand 
as
begin
	Select * from Brand
end


-- Insert Brand
Create Proc AddBrand (
	@BrandName Nvarchar(255),
	@Description ntext
)as
begin
	Insert into Brand (BrandName, Description, IsActive) values (@BrandName, @Description, 1)
	Select SCOPE_IDENTITY()  
end

-- Update Brand
Create Proc UpdateBrand (
	@BrandName nvarchar(255),
	@Description ntext,
	@IsActive bit,
	@BrandId int
) as
begin
	Update Brand Set BrandName = @BrandName, Description = @Description , IsActive = @IsActive where BrandId = @BrandId
end

-- Delete Brand
Create Proc DeleteBrand(
	@BrandId int
)as
begin
	Update Brand Set BrandName = BrandName , Description = Description, IsActive = 0 where BrandId = @BrandId
end

drop proc DeleteBrand





-- Color
-- Select
Create Proc GetAllColor 
as
begin
	Select * from Color 
end

-- Insert Color
Create Proc AddColor
(
	@ColorName nvarchar(255),
)as
begin 
	Insert into Color ( ColorName, IsActive) values ( @ColorName, 1)
end

--Update Color
Create Proc UpdateColor (
	@ColorName nvarchar (255),
	@IsActive bit,
	@ColorId int
)as
begin
	Update Color Set ColorName = @ColorName, IsActive = @IsActive Where ColorId = @ColorId
end

-- Delete Color
Create Proc DeleteColor(
	@ColorId
)as
begin
	Update Color Set ColorName = ColorName,  IsActive = 0 where ColorId = @ColorId
end






-- Category
-- Select
Create Proc GetAllCategory as
begin 
	Select * from Category
end

-- Insert
Create Proc AddCategory (
	@CategoryName nvarchar(255)
)as
begin
	 Insert into Category (CategoryName, IsActive) values ( @Category , 1)
end





-- Update Category
Create Proc UpdateCategory(
	@CategoryName nvarchar(255),
	@IsActive bit,
	@CategoryId
)as
begin
	Update Category Set CategoryName = @CategoryName , IsActive = @IsActive where CategoryId = @CategoryId
end

-- Delete Category
Create Proc DeleteCategory
(
	@CategoryId
)as
begin
	Update Category Set CategoryName = CategoryName, IsActive = 0 where CategoryId = @CategoryId
end





-- Quanlity
-- Select 
Create Proc GetAllQuanlity 
as
begin 
	Select * from Quanlity
end

--Insert Quanlity
Create Proc AddQuanlity 
(
	@QuanlityName Nvarchar(255)
)as
begin
	Insert into Quanlity (QuanlityName , IsActive ) values ( @QuanlityName , 1)
end

-- Update Quanlity
Create Proc UpdateQuanlity
(
	@QuanlityName nvarchar(255),
	@IsActive bit,
	@QuanlityId int

)as
begin
	Update Quanlity Set QuanlityName = @QuanlityName , IsActive = @IsActive where QuanlityId = @QuanlityId
end

-- Delete Quantuty
Create Proc DeleteQuanlity
(
	@QuanlityId int 
) as
begin
	Update Quanlity SET QuanlityName = QuanlityName, IsActive = 0 where Quanlity =  @QuanlityId
end






-- Product
-- Select
Create Proc GetAllProduct as
begin
	Select * from Product
end

-- Insert Product
Create Proc AddProduct
(
	@ProductName nvarchar(255),
	@ProductCode varchar(255),
	@ProductWeight decimal(6,2),
	@CategoryId int,
	@BrandId int
)as
begin
	Insert into Product (ProductName, ProductCode, ProductWeight , IsActive, CategoryId, BrandId) values (@ProductName, @ProductCode, @ProductWeight , 1, @CategoryId , @BrandId)
end

-- Update Proc Product
Create Proc UpdateBrand 
(
	@ProductName nvarchar(255),
	@ProductCode varchar(255),
	@ProductWeight decimal(6,2),
	@IsActive bit,
	@CategoryId int,
	@BrandId int,
	@ProductId int
)as
begin
	Update Product Set ProductName = @ProductName, ProductCode = @ProductCode, ProductWeight = @ProductWeight , IsActive = @IsActive , CategoryId = @CategoryId,
		BrandId = @BrandId where ProductId = @ProductId
end

-- Delete Product
Create Proc DeleteProduct
(
	@ProductId int
)as
begin
	Update Product Set ProductName = ProductName , ProductCode = ProductCode , ProductWeight = ProductWeight , IsActive = 0 , CategoryId = CategoryId , BrandId = BrandId where ProductId = @ProductId
end




-- ProductDetail
-- Select 
Create Proc GetAllProductDetail
as
begin 
	Select * from ProductDetail
end

-- Insert
Create Proc AddProductDetail 
(
	@ProductId int,
	@ColorId int,
	@Price DECIMAL(10,2),
	@QuanlityId int,
	@Image varchar(255),
	@Description ntext 
)as
begin
	Insert into ProductDetail ( ProductId, ColorId, Price , QuanlityId , Image, Description ) values ( @ProductId, @ColorId, @Price, @QuanlityId , @Image, @Description)
end

-- Update ProductDetail
Create Proc UpdateProductDetail
(
	@ProductId int,
	@ColorId int,
	@Price DECIMAL(10,2),
	@QuanlityId int,
	@Image varchar(255),
	@Description ntext ,
	@ProductDetailId int
)as
begin
	Update ProductDetail Set ProductId = @ProductId , ColorId = @ColorId , Price = @Price, QuanlityId = @QuanlityId , Image = @Image , Description = @Description,
		where ProductDetaiId  = @ProductDetailId
end

-- Delete ProductDetail
Create Proc DeleteProductDetail
(
	@ProductDetailId int
)as
begin 
	Delete From ProductDetail where ProductDetailId = @ProductDetailId
end


