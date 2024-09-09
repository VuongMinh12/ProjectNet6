Use Keyboard;

--Brand
-- SELECT
Create Proc GetBrand 
as
begin(@PageNumber int,
	@PageSize int,
	@BrandName nvarchar(255),
	@IsActive int
)
as
begin	
	Select ROW_NUMBER() Over(Order by BrandId ASC) as No, BrandName , Description , IsActive
	from Brand 
	Where (isnull(@BrandName,'') = '' or BrandName Like N'%'+@BrandName+'%') 
	AND (@IsActive is null or IsActive = @IsActive)
	order by BrandId
	OFFSET ((@PageNumber - 1) * @PageSize) ROWS FETCH NEXT @PageSize ROWS ONLY;
end



-- Insert Brand
Create Proc AddBrand (
	@BrandName nvarchar(255),
	@Description ntext
)as
begin
	Insert into Brand(BrandName, Description,IsActive) values (@BrandName , @Description , 1)
	select SCOPE_IDENTITY()
end


-- Update Brand
Create Proc UpdateBrand (
	@BrandName nvarchar(255),
	@Description ntext,
	@BrandId int
)as
begin
	Update Brand Set BrandName = @BrandName, Description = @Description where BrandId = @BrandId
end



-- Delete Brand
Create Proc DeleteBrand(
	@BrandId int
)as
begin
	Update Brand Set BrandName = BrandName , Description = Description, IsActive = 0 where BrandId = @BrandId
end

drop proc DeleteBrand




