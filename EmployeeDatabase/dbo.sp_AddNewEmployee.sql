CREATE PROCEDURE sp_UpdateEmployeeDetails
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@ContactNumber varchar(50),
@City varchar(50),
@Salary varchar(50),
@JoiningDate varchar(50)
AS
BEGIN
	INSERT INTO Employee(FirstName, LastName, Email, ContactNumber, City, Salary, JoiningDate)
		VALUES(@FirstName, @LastName, @Email, @ContactNumber, @City, @Salary, @JoiningDate);
END