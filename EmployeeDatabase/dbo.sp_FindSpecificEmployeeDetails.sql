CREATE PROCEDURE sp_FindSpecificEmployeeDetails
	@Id int
AS
	SELECT * FROM Employee Where Id = @Id;

