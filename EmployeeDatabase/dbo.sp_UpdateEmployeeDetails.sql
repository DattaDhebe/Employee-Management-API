CREATE PROCEDURE sp_UpdateEmployeeDetails
@Id int,
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

	if exists (SELECT * FROM UserData WHERE Email = @Email)
		UPDATE EmployeeData SET FirstName = @FirstName, LastName = @LastName, ContactNumber = @ContactNumber, City = @City, Salary = @Salary, ModifiedDate = @ModifiedDate  WHERE Id = @Id;
	else
		UPDATE EmployeeData SET FirstName = @FirstName, LastName = @LastName, Email = @Email, ContactNumber = @ContactNumber, City = @City, Salary = @Salary, ModifiedDate = @ModifiedDate  WHERE Id = @Id;
	select * from EmployeeData where Id = @Id;
END