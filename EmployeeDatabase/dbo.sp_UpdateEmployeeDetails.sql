CREATE PROCEDURE sp_UpdateEmployeeDetails
@Id int,
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@ContactNumber varchar(50),
@City varchar(50),
@Salary varchar(50),
@JoiningDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Email = @Email, ContactNumber = @ContactNumber, City = @City, Salary = @Salary, JoiningDate = @JoiningDate  WHERE Id = @Id;
END

