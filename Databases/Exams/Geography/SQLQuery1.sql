SELECT P.PeakName AS PeakName FROM Peaks p
ORDER BY P.PeakName

--For each country, find the name and elevation of the highest peak,
--along with its mountain. When no peaks are available in some country,
--display elevation 0, "(no highest peak)" as peak name and "(no mountain)"
--as mountain name. When multiple peaks in some country have
--the same elevation, display all of them. Sort the results by country
--name alphabetically, then by highest peak name alphabetically. 
--Submit for evaluation the result grid with headers.

drop table #Temp1
CREATE TABLE #Temp1 ( Country NVarChar( 100 ),[Highest Peak Name] nvarchar(100), [Highest Peak Elevation] int,Mountain nvarchar(100) );

insert into #Temp1
SELECT c.CountryName,p.PeakName,P.Elevation,m.MountainRange FROM Countries c
left JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
left JOIN Mountains m ON mc.MountainId = m.Id
left JOIN Peaks p ON p.MountainId = m.Id

select p.Country AS [Country],
  p.[Highest Peak Name] AS [Highest Peak Name],
  p.[Highest Peak Elevation] AS [Highest Peak Elevation],
  p.Mountain AS [Mountain]from #temp1 p
where p.[Highest Peak Elevation] = (select max(c.[Highest Peak Elevation]) from #Temp1 c where c.Country = p.Country) 

union 
select  q.Country AS [Country],
  '(no highest peak)' AS [Highest Peak Name],
  0 AS [Highest Peak Elevation],
  '(no mountain)' AS [Mountain]
  from  #Temp1 q
  where q.[Highest Peak Name] is null
order by p.Country,p.[Highest Peak Name]

select 


SELECT c.CountryName,isnull(p.PeakName,'(no highest peak)'),(isnull(P.Elevation,0)),isnull(m.MountainRange,'(no mountain)') FROM Countries c
left JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
left JOIN Mountains m ON mc.MountainId = m.Id
left JOIN Peaks p ON p.MountainId = m.Id
WHERE P.Elevation = (SELECT MAX(isnull(P1.Elevation,0)) FROM Countries c1
left JOIN MountainsCountries mc1 ON mc1.CountryCode = c1.CountryCode
left JOIN Mountains m1 ON mc1.MountainId = m1.Id
left JOIN Peaks p1 ON p1.MountainId = m1.Id WHERE C1.CountryCode=c.CountryCode) or (P.Elevation IS NULL)
GROUP BY C.CountryName,P.PeakName,M.MountainRange,p.Elevation
order by c.CountryName


SELECT
  c.CountryName AS [Country],
  p.PeakName AS [Highest Peak Name],
  p.Elevation AS [Highest Peak Elevation],
  m.MountainRange AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE p.Elevation =
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode)
UNION
SELECT
  c.CountryName AS [Country],
  '(no highest peak)' AS [Highest Peak Name],
  0 AS [Highest Peak Elevation],
  '(no mountain)' AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE 
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode) IS NULL
ORDER BY c.CountryName, [Highest Peak Name]