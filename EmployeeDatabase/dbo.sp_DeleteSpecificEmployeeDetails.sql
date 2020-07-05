CREATE PROCEDURE sp_DeleteSpecificEmployeeDetails
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM EmployeeData WHERE Id = @Id;
	RETURN
END