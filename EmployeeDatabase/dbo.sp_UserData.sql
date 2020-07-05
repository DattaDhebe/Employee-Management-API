CREATE PROCEDURE sp_UserData
@FirstName varchar(50),
@LastName varchar(50),
@Email varchar(50),
@Username varchar(50),
@Password varchar(50),
@Gender varchar(50),
@City varchar(50),
@ModifiedDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO UserData(FirstName, LastName, Email, Username, Password, Gender, City, CreatedDate, ModifiedDate)
		VALUES(@FirstName, @LastName, @Email, @Username, @Password, @Gender, @City, GETDATE(), @ModifiedDate)
	select Id, FirstName, LastName, Email, Username, Gender, City, CreatedDate, ModifiedDate from UserData where Email = @Email;
END