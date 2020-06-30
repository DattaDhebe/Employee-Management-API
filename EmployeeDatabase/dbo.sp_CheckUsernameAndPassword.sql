CREATE PROCEDURE sp_CheckUsernameAndPassword
@Username varchar(50),
@Password varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 
	
	if exists (select * from UserRegistration where Username = @Username AND Password = @Password)
		select 1
	else
		select 0
END