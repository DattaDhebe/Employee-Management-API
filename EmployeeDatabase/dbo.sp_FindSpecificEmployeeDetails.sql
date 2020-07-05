CREATE PROCEDURE sp_FindSpecificEmployeeDetails
	@Id int
AS
BEGIN
	SET NOCOUNT ON

	SELECT * FROM EmployeeData Where Id = @Id;
	RETURN
END