CREATE PROCEDURE sp_CheckUsernameAndPassword
@Username varchar(50),
@Password varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 
	
	select Id, FirstName, LastName, Email, Username, Gender, City, CreatedDate from UserData where Username = @Username AND Password = @Password;
	
END