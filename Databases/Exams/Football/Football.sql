--01.

SELECT t.TeamName  FROM Teams t
ORDER BY t.TeamName

--02.
SELECT TOP 50 c.CountryName, c.Population FROM Countries c
ORDER BY c.Population DESC,c.CountryName

--03.
SELECT c.CountryName, c.CountryCode,
	(CASE 
		WHEN c.CurrencyCode='EUR' THEN 'Inside'
		ELSE 'Outside'
	END)
		AS Eurozone
FROM Countries c
ORDER BY c.CountryName

--04.
SELECT t.TeamName AS [Team Name], t.CountryCode AS [Country Code] FROM Teams t
WHERE t.TeamName LIKE '%[0-9]%'
ORDER BY t.CountryCode


--05.

SELECT c.CountryName AS [Home Team], c1.CountryName AS [Away Team],im.MatchDate AS [Match Date] FROM InternationalMatches im
JOIN Countries c ON c.CountryCode = im.HomeCountryCode
JOIN Countries c1 ON c1.CountryCode = im.AwayCountryCode
ORDER BY im.MatchDate DESC

--06.
SELECT t.TeamName AS [Team Name], 
l.LeagueName AS [League],
CASE 
	WHEN l.CountryCode IS NULL THEN 'International'
	ELSE c.CountryName
END AS [League Country]
 FROM Teams t
JOIN Leagues_Teams lt ON lt.TeamId = t.Id
JOIN Leagues l ON l.Id = lt.LeagueId
JOIN Countries c ON c.CountryCode = t.CountryCode
ORDER BY t.TeamName, League


--07.
SELECT p.TeamName AS Team, COUNT(p.Id) AS [Matches Count] FROM(
SELECT t.TeamName, t.Id FROM Teams t
JOIN TeamMatches tm ON t.Id = tm.HomeTeamId
UNION ALL
SELECT t1.TeamName, t1.Id FROM Teams t1
JOIN TeamMatches tm1 ON t1.Id = tm1.AwayTeamId) p

GROUP BY p.TeamName
HAVING COUNT(p.id)>1
ORDER BY p.TeamName

--08.
SELECT
	l.LeagueName as [League Name],
	COUNT(DISTINCT lt.TeamId) AS [Teams],
	COUNT(DISTINCT tm.Id) AS [Matches],
	ISNULL(AVG(tm.HomeGoals+tm.AwayGoals),0) AS [Average Goals]

 FROM Leagues l
LEFT JOIN Leagues_Teams lt ON lt.LeagueId = l.Id
LEFT JOIN TeamMatches tm ON tm.LeagueId = l.Id
GROUP BY l.LeagueName
ORDER BY Teams DESC, Matches DESC

--09.
SELECT
Teams.TeamName AS [TeamName],
ISNULL(
SUM(
CASE
WHEN tm1.HomeTeamId = Teams.Id
THEN tm1.HomeGoals
ELSE tm1.AwayGoals
END
), 0) AS [Total Goals]
FROM Teams
LEFT JOIN TeamMatches tm1
ON tm1.HomeTeamId = Teams.Id
OR tm1.AwayTeamId = Teams.Id
GROUP BY Teams.TeamName
ORDER BY [Total Goals] DESC, [TeamName] ASC


--10.
SELECT tm.MatchDate AS [First Date], tm1.MatchDate AS [Second Date] FROM TeamMatches tm
CROSS JOIN TeamMatches tm1
WHERE tm1.MatchDate>tm.MatchDate AND CONVERT(VARCHAR(19),tm1.MatchDate,104)=CONVERT(VARCHAR(19),tm.MatchDate,104)
ORDER BY [First Date] DESC, [Second Date] DESC

--11.
SELECT SUBSTRING(LOWER(t.TeamName),1,LEN(t.TeamName)-1) + LOWER(REVERSE(t1.TeamName)) AS Mix FROM Teams t, Teams t1
WHERE LOWER(SUBSTRING(t.TeamName,LEN(t.TeamName),1)) = LOWER(SUBSTRING(REVERSE(t1.TeamName),1,1))
ORDER BY Mix


--12.

SELECT c.CountryName AS [Country Name], COUNT(DISTINCT im.Id) AS [International Matches], COUNT(DISTINCT tm.Id) AS [Team Matches] FROM Countries c
LEFT JOIN InternationalMatches im ON im.HomeCountryCode = c.CountryCode
OR im.AwayCountryCode = c.CountryCode
LEFT JOIN Leagues l ON l.CountryCode = c.CountryCode
LEFT JOIN TeamMatches tm ON tm.LeagueId = l.Id
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im.Id)>=1 OR COUNT(DISTINCT tm.Id)>=1
ORDER BY [International Matches] DESC, [Team Matches] DESC, c.CountryName



--15.

SELECT t.TeamName, t1.TeamName, tm.HomeGoals, tm.AwayGoals, CONVERT(NVARCHAR(20),tm.MatchDate,103) FROM Teams t 
FULL JOIN TeamMatches tm ON tm.HomeTeamId = t.Id
FULL JOIN Teams t1 ON t1.Id = tm.AwayTeamId
WHERE t.CountryCode = 'BG'
ORDER BY T.TeamName






IF OBJECT_ID('fn_TeamsJSON') IS NOT NULL
  DROP FUNCTION fn_TeamsJSON
GO


CREATE FUNCTION fn_TeamsJSON ()
-- WITH ENCRYPTION, SCHEMABINDING, EXECUTE AS CALLER|SELF|OWNER|USER
RETURNS NVARCHAR(MAX)
AS BEGIN
	DECLARE @json NVARCHAR(MAX) = '{"teams":['
	DECLARE teamCursor CURSOR FOR SELECT t.Id, t.TeamName
				FROM Teams t
				WHERE t.CountryCode = 'BG'
				ORDER BY t.TeamName
                        
                        OPEN teamCursor

						DECLARE @teamName NVARCHAR(MAX)
						DECLARE @teamId INT

                        
                        FETCH NEXT FROM teamCursor INTO @teamId, @teamName
                        
                        WHILE @@FETCH_STATUS = 0 BEGIN
                        
                        SET @json= @json+'{"name":"'+@teamName +'","matches":['


								
                                
                                DECLARE matchesCursor CURSOR  FOR
                                	SELECT t.TeamName, t1.TeamName, tm.HomeGoals, tm.AwayGoals, tm.MatchDate
                                	FROM TeamMatches tm
									LEFT JOIN Teams t ON t.Id = tm.HomeTeamId
									LEFT JOIN Teams t1 ON t1.Id = tm.AwayTeamId
									WHERE tm.HomeTeamId = @teamId OR tm.AwayTeamId = @teamId
									ORDER BY tm.MatchDate DESC
                                
                                OPEN matchesCursor
									DECLARE @homeTeam NVARCHAR(MAX)
									DECLARE @awayTeam NVARCHAR(MAX)
									DECLARE @homeTeamGoals int
									DECLARE @awayTeamGoals int
									DECLARE @matchDate DATE



                                
                                FETCH NEXT FROM matchesCursor INTO
								@homeTeam, @awayTeam, @homeTeamGoals, @awayTeamGoals, @matchDate
                                
                                WHILE @@FETCH_STATUS = 0 BEGIN
									SET @json =@json+'{"'+@homeTeam+'":'+CONVERT(NVARCHAR(MAX), @homeTeamGoals)+',"'+@awayTeam+'":'+CONVERT(NVARCHAR(MAX), @awayTeamGoals)+',"date":'+CONVERT(NVARCHAR(MAX),@matchDate, 103)+'}'
                                	
                                
                                	FETCH NEXT FROM matchesCursor INTO 
									@homeTeam, @awayTeam, @homeTeamGoals, @awayTeamGoals, @matchDate
									IF  @@FETCH_STATUS = 0 BEGIN  
                                    	SET @json = @json+','
                                    END
                                    
                                
                                END
                                
                                CLOSE matchesCursor
                                DEALLOCATE matchesCursor
							SET @json = @json+']}'
                        
                        FETCH NEXT FROM teamCursor INTO @teamId, @teamName
						IF  @@FETCH_STATUS = 0 BEGIN  
                        	SET @json = @json+','
                        END
                        
                        
                        END
                        
                        CLOSE teamCursor
                        DEALLOCATE teamCursor
	SET @json = @json+']}'
	RETURN @json
END
GO

SELECT dbo.fn_TeamsJSON()