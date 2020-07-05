CREATE PROCEDURE sp_AddNewEmployee
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@ContactNumber varchar(50),
@City varchar(50),
@Salary varchar(50),
@ModifiedDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO EmployeeData(FirstName, LastName, Email, ContactNumber, City, Salary, CreatedDate, ModifiedDate)
		VALUES(@FirstName, @LastName, @Email, @ContactNumber, @City, @Salary, GETDATE(), @ModifiedDate);
	select * from EmployeeData where Email = @Email;
END