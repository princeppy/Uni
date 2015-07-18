IF OBJECT_ID('dbo.usp_FindProjectsForEmployee') IS NOT NULL
	DROP PROCEDURE dbo.usp_FindProjectsForEmployee;
GO
CREATE PROCEDURE dbo.usp_FindProjectsForEmployee
@firstName NVARCHAR(MAX), @lastName NVARCHAR(MAX)
AS 
	SELECT p.* FROM Employees e
	LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
	WHERE e.FirstName = @firstName AND e.LastName = @lastName
GO