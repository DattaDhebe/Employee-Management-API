CREATE PROCEDURE [dbo].[sp_DeleteSpecificEmployeeDetails]
	@Id int
AS
	DELETE FROM Employee WHERE Id = @Id;
RETURN 0
