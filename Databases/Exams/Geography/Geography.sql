USE Geography

--Problem 1.All Mountain Peaks
SELECT p.PeakName FROM Peaks p
ORDER BY p.PeakName

--Problem 2.Biggest Countries by Population
SELECT TOP 30 c.CountryName, c.Population FROM Countries c
JOIN Continents c1 ON c.ContinentCode = c1.ContinentCode
WHERE c1.ContinentName = 'Europe'
ORDER BY c.Population DESC, c.CountryName

--Problem 3.Countries and Currency (Euro / Not Euro)
SELECT c.CountryName, c.CountryCode, CASE 
            WHEN c.CurrencyCode = 'EUR' 
               THEN 'Euro' 
               ELSE 'Not Euro'
       END as Currency
FROM Countries c
ORDER BY c.CountryName

--Problem 4.Countries Holding 'A' 3 or More Times
SELECT c.CountryName AS [Country Name],c.IsoCode AS [ISO Code] FROM Countries c
WHERE LOWER(c.CountryName) LIKE '%a%a%a%'
ORDER BY c.IsoCode

--Problem 5.Peaks and Mountains
SELECT p.PeakName,m.MountainRange,p.Elevation FROM Mountains m
JOIN Peaks p ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, m.MountainRange

--Problem 6.Peaks with Their Mountain, Country and Continent
SELECT p.PeakName,m.MountainRange AS Mountain, c1.CountryName,c.ContinentName FROM Continents c
JOIN Countries c1 ON c.ContinentCode = c1.ContinentCode
JOIN MountainsCountries mc ON c1.CountryCode = mc.CountryCode
JOIN Mountains m ON m.Id = mc.MountainId
JOIN Peaks p ON p.MountainId = m.Id
ORDER BY p.PeakName, c1.CountryName

--Problem 7.* Rivers Passing through 3 or More Countries
SELECT r.RiverName AS River, COUNT(c.CountryName) AS [Countries Count] FROM Countries c
JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
JOIN Rivers r ON r.Id = cr.RiverId
GROUP BY r.RiverName
HAVING COUNT(c.CountryName)>=3

--Problem 8.Highest, Lowest and Average Peak Elevation
SELECT MAX(p.Elevation) AS MaxElevation, MIN(p.Elevation) AS MinElevation, AVG(p.Elevation) AS AverageElevation FROM Peaks p

--Problem 9.Rivers by Country
SELECT  c1.CountryName,c.ContinentName, ISNULL(COUNT(r.RiverName),0) AS RiversCount, ISNULL(SUM(r.Length),0) AS TotalLength FROM Continents c
full JOIN Countries c1 ON c.ContinentCode = c1.ContinentCode
full JOIN CountriesRivers cr ON c1.CountryCode = CR.CountryCode
full JOIN Rivers r ON R.Id = CR.RiverId
group by c1.CountryName,c.ContinentName
ORDER BY COUNT(r.RiverName) desc, SUM(r.Length) DESC, c1.CountryName

--Problem 10.Count of Countries by Currency
SELECT c1.CurrencyCode, c1.Description as Currency, COUNT(c.CountryName) AS NumberOfCountries FROM Countries c
RIGHT JOIN Currencies c1 ON c.CurrencyCode = c1.CurrencyCode
GROUP BY c1.CurrencyCode,c1.Description
ORDER BY COUNT(c.CountryName) desc, c1.Description

--11.Population and Area by Continent

SELECT c.ContinentName,SUM( CAST(c1.AreaInSqKm as BIGINT)) AS CountriesArea, SUM(CAST(c1.Population as BIGINT)) AS CountriesPopulation FROM Continents c
JOIN Countries c1 ON c1.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName
ORDER BY SUM(CAST(c1.Population as BIGINT)) DESC

--Problem 12.Highest Peak and Longest River by Country

SELECT c.CountryName, MAX(p.Elevation) AS HighestPeakElevation , MAX(r.Length) AS LongestRiverLength FROM Countries c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m ON m.Id = mc.MountainId
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON r.Id = cr.RiverId
LEFT JOIN Peaks p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName

--Problem 13.Mix of Peak and River Names

SELECT p.PeakName, r.RiverName, LOWER(SUBSTRING(p.PeakName,0,LEN( p.PeakName)))+LOWER(r.RiverName) AS Mix FROM 
Peaks p, Rivers r
WHERE LOWER(SUBSTRING(p.PeakName,LEN(p.PeakName),1)) = LOWER(SUBSTRING(r.RiverName,1,1))
ORDER BY Mix

--14.


SELECT c.CountryName as Country
	,CASE 
    	WHEN p.Elevation IS NULL THEN '(no highest peak)'
    	ELSE p.PeakName
    END AS [Highest Peak Name]
	--,ISNULL(CAST(p.Elevation as NVARCHAR(50)),'(no highest peak)') AS [Highest Peak Name]
	,ISNULL(p.Elevation,0) AS [Highest Peak Elevation]
	,CASE 
    	WHEN p.Elevation IS NULL THEN '(no mountain)' 
    	ELSE  m.MountainRange
    END AS Mountain
	--,ISNULL(CAST(p.Elevation as NVARCHAR(50)),'(no mountain)') AS Mountain
FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = m.Id

WHERE p.Elevation =
		(SELECT
			MAX(p.Elevation)
			FROM Countries c1
				LEFT JOIN MountainsCountries mc ON mc.CountryCode = c1.CountryCode
				LEFT JOIN Mountains m ON m.Id = mc.MountainId
				LEFT JOIN Peaks p ON p.MountainId = m.Id
			WHERE c1.CountryName = c.CountryName					) 
	OR 
		(SELECT
			MAX(p.Elevation)
			FROM Countries c1
				LEFT JOIN MountainsCountries mc ON mc.CountryCode = c1.CountryCode
				LEFT JOIN Mountains m ON m.Id = mc.MountainId
				LEFT JOIN Peaks p ON p.MountainId = m.Id
			WHERE c1.CountryName = c.CountryName)
			IS NULL

ORDER BY Country, [Highest Peak Name]

--15.

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--DELETED COUNTRIES
UPDATE Countries
SET IsDeleted = 1
WHERE CountryName IN (SELECT  c1.CountryName FROM Continents c
JOIN Countries c1 ON c.ContinentCode = c1.ContinentCode
JOIN CountriesRivers cr ON c1.CountryCode = CR.CountryCode
JOIN Rivers r ON R.Id = CR.RiverId
GROUP BY c1.CountryName
HAVING COUNT(r.RiverName) >3)

--SELECT MONASTERIES
SELECT m.Name AS Monastery,c.CountryName AS Country FROM Countries c
JOIN Monasteries m ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY m.Name


--16.
--ИЗЛИШНА СМЯНА НА ИМЕНАТА
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

SELECT c.ContinentName, c1.CountryName, COUNT(m.Name) AS MonasteriesCount FROM Continents c
FULL JOIN Countries c1 ON c.ContinentCode = c1.ContinentCode
FULL JOIN Monasteries m ON m.CountryCode = c1.CountryCode
WHERE c1.IsDeleted = 0
GROUP BY c.ContinentName, c1.CountryName
ORDER BY COUNT(m.Name) DESC, c1.CountryName


--17.



IF OBJECT_ID('fn_MountainsPeaksJSON') IS NOT NULL
  DROP FUNCTION fn_MountainsPeaksJSON
GO


CREATE FUNCTION fn_MountainsPeaksJSON()
-- WITH ENCRYPTION, SCHEMABINDING, EXECUTE AS CALLER|SELF|OWNER|USER
RETURNS NVARCHAR(MAX)
AS BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"mountains":['
	DECLARE mountainsCursor CURSOR FOR SELECT m.MountainRange
				FROM Mountains m
				
				--ORDER BY m.MountainRange
                        
                        OPEN mountainsCursor

						DECLARE @mountainName NVARCHAR(MAX)
						

                        
                        FETCH NEXT FROM mountainsCursor INTO @mountainName
                        
                        WHILE @@FETCH_STATUS = 0 BEGIN
                        
                        SET @json= @json+'{"name":"'+@mountainName +'","peaks":['


								
                                
                                DECLARE peaksCursor CURSOR FOR
                                	SELECT p.PeakName, p.Elevation
                                	FROM Mountains m
									JOIN Peaks p ON m.Id = p.MountainId
									WHERE m.MountainRange = @mountainName
									
									--ORDER BY p.PeakName DESC
                                
                                OPEN peaksCursor
									DECLARE @peak NVARCHAR(MAX)
									DECLARE @elevation int
									                                
                                FETCH NEXT FROM peaksCursor INTO
								@peak, @elevation
                                
                                WHILE @@FETCH_STATUS = 0 BEGIN
									SET @json =@json+'{"name":"'+@peak+'","elevation":'+CONVERT(NVARCHAR(MAX), @elevation)+'}'
                                	
                                
                                	FETCH NEXT FROM peaksCursor INTO 
									@peak, @elevation
									IF  @@FETCH_STATUS = 0 BEGIN  
                                    	SET @json = @json+','
                                    END
                                    
                                
                                END
                                
                                CLOSE peaksCursor
                                DEALLOCATE peaksCursor
							SET @json = @json+']}'
                        
                        FETCH NEXT FROM mountainsCursor INTO @mountainName
						IF  @@FETCH_STATUS = 0 BEGIN  
                        	SET @json = @json+','
                        END
                        
                        
                        END
                        
                        CLOSE mountainsCursor
                        DEALLOCATE mountainsCursor
	SET @json = @json+']}'
	RETURN @json
END
GO

SELECT dbo.fn_MountainsPeaksJSON()