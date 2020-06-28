CREATE PROCEDURE sp_EmployeeRegister
@FirstName varchar(50),
@LastName varchar(50),
@ContactNumber varchar(50),
@City varchar(50),
@Salary varchar(50),
@JoiningDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO Employee(FirstName, LastName, ContactNumber, City, Salary, JoiningDate)
		VALUES(@FirstName, @LastName, @ContactNumber, @City, @Salary, @JoiningDate);
END