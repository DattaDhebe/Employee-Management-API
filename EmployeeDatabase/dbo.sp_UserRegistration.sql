CREATE PROCEDURE sp_UserRegistration
@EmployeeName varchar(50),
@UserName varchar(50),
@Password varchar(50),
@Gender varchar(50),
@City varchar(50),
@Email varchar(50),
@Designation varchar(50),
@CreatedDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO UserRegistration(EmployeeName, Username, Password, Gender, City, Email, Designation, CreatedDate)
		VALUES(@EmployeeName, @Username, @Password, @Gender, @City, @Email, @Designation, @CreatedDate)
END