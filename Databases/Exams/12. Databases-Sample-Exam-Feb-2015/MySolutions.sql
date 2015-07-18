--04.

SELECT * FROM Ads a
WHERE a.ImageDataURL IS NULL OR a.TownId IS NULL OR a.CategoryId IS NULL
ORDER BY a.Id

--05.

SELECT a.Title, t.Name as Town FROM Ads a
LEFT JOIN Towns t ON t.Id = a.TownId
ORDER BY a.Id

--06.

SELECT a.Title,c.Name as CategoryName, t.Name as TownName, as1.Status FROM Ads a
LEFT JOIN Towns t ON t.Id = a.TownId
LEFT JOIN Categories c ON c.Id = a.CategoryId
LEFT JOIN AdStatuses as1 ON as1.Id = a.StatusId
WHERE t.Name IN ('Blagoevgrad ','Stara Zagora','Sofia') AND as1.Status = 'Published'
ORDER BY a.Title


--07.

SELECT MIN(a.Date) AS MinDate, MAX(a.Date) AS MaxDate FROM Ads a

--08.

SELECT TOP 10 a.Title,a.Date, as1.Status FROM Ads a
LEFT JOIN Towns t ON t.Id = a.TownId
LEFT JOIN Categories c ON c.Id = a.CategoryId
LEFT JOIN AdStatuses as1 ON as1.Id = a.StatusId

ORDER BY a.Date DESC

--09.

SELECT a.Id, a.Title,a.Date, as1.Status FROM Ads a
LEFT JOIN Towns t ON t.Id = a.TownId
LEFT JOIN Categories c ON c.Id = a.CategoryId
LEFT JOIN AdStatuses as1 ON as1.Id = a.StatusId
WHERE DATEPART(yy,a.Date) = DATEPART(YY,(SELECT MIN(a1.Date) FROM Ads a1))
AND DATEPART(mm,a.Date) = DATEPART(mm,(SELECT MIN(a1.Date) FROM Ads a1))
AND as1.Status != 'Published'
ORDER BY a.Id



--10.
SELECT as1.Status, COUNT(*) FROM Ads a
LEFT JOIN Towns t ON t.Id = a.TownId
LEFT JOIN Categories c ON c.Id = a.CategoryId
LEFT JOIN AdStatuses as1 ON as1.Id = a.StatusId
GROUP BY as1.Status

--11.


--12.
SELECT t.Name AS [Town Name],as1.Status, COUNT(*) FROM Ads a
JOIN Towns t ON t.Id = a.TownId
JOIN Categories c ON c.Id = a.CategoryId
JOIN AdStatuses as1 ON as1.Id = a.StatusId
GROUP BY as1.Status, t.Name
ORDER BY t.Name, as1.Status


--13.
SELECT  distinct anu.UserName as UserName,COUNT(a.Id) AS AdsCount, 

CASE 
	WHEN anr.Name = 'Administrator' THEN 'yes'
	ELSE 'no'
END AS IsAdministrator

 FROM AspNetUsers anu
LEFT JOIN Ads a ON anu.Id = a.OwnerId
left JOIN AspNetUserRoles anur ON anur.UserId = anu.Id
left JOIN AspNetRoles anr ON anr.Id = anur.RoleId
GROUP BY anu.UserName, anr.Name
ORDER BY anu.UserName




SELECT 
  MIN(u.UserName) as UserName, 
  COUNT(a.Id) as AdsCount,
  (CASE WHEN admins.UserName IS NULL THEN 'no' ELSE 'yes' END) AS IsAdministrator
FROM 
  AspNetUsers u
  LEFT JOIN Ads a ON u.Id = a.OwnerId
  LEFT JOIN (
    SELECT DISTINCT u.UserName
	FROM AspNetUsers u
	  LEFT JOIN AspNetUserRoles ur ON ur.UserId = u.Id
	  LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
	WHERE r.Name = 'Administrator'
  ) AS admins ON u.UserName = admins.UserName
GROUP BY OwnerId, u.UserName, admins.UserName
ORDER BY u.UserName








