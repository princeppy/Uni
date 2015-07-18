--01.
SELECT c.Name FROM Characters c
ORDER BY c.Name

--02.
SELECT TOP 50 g.Name as Game, LEFT(CONVERT(VARCHAR, g.Start, 120), 10) AS Start FROM Games g
WHERE DATEPART(yy, g.Start) = '2011' OR DATEPART(yy, g.Start) = '2012'
ORDER BY Start, g.Name


--03.

SELECT u.Username, (SUBSTRING(u.Email, CHARINDEX('@', u.Email)+1, LEN(u.Email)-CHARINDEX('@', u.Email)+1))  AS [Email Provider]  FROM Users u
ORDER BY [Email Provider], u.Username	

--04.
SELECT u.Username, u.IpAddress AS [Ip Address] FROM Users u
WHERE u.IpAddress LIKE '___.1%.%.___'


ORDER BY  u.Username

--05.
SELECT g.Name AS Game, 

CASE 
	WHEN DATEPART(hh, g.Start)>=0 AND DATEPART(hh, g.Start)<12  THEN 'Morning'
	WHEN DATEPART(hh, g.Start)>=12 AND DATEPART(hh, g.Start)<18  THEN 'Afternoon'
	WHEN DATEPART(hh, g.Start)>=18 AND DATEPART(hh, g.Start)<24  THEN 'Evening'
	
	-- ELSE
END

AS [Part of the Day]

,

CASE 
	WHEN g.Duration <=3 THEN 'Extra Short'
	WHEN g.Duration >=4 AND g.Duration<=6 THEN 'Short'
	WHEN g.Duration >6 THEN 'Long'
	WHEN g.Duration IS NULL THEN 'Extra Long'


	-- ELSE
END
AS Duration
FROM Games g
ORDER BY g.Name, Duration, [Part of the Day]


--06.
SELECT (SUBSTRING(u.Email, CHARINDEX('@', u.Email)+1, LEN(u.Email)-CHARINDEX('@', u.Email)+1)) AS [Email Provider]  , COUNT(u.Username) AS [Number Of Users] FROM Users u
GROUP BY (SUBSTRING(u.Email, CHARINDEX('@', u.Email)+1, LEN(u.Email)-CHARINDEX('@', u.Email)+1))
ORDER BY [Number Of Users] DESC, [Email Provider] asc


--07.
SELECT 
g.Name AS Game
, gt.Name AS [Game Type]
, u.Username
,ug.Level
,ug.Cash
, c.Name as Character
 FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
JOIN Games g ON ug.GameId = g.Id
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN Characters c ON c.Id = ug.CharacterId
ORDER BY ug.Level DESC, u.Username,Game

--08.

SELECT 
u.Username,
g.Name AS Game,
COUNT(i.Id) AS [Items Count],
SUM(i.Price) AS [Items Price]

 FROM Users u
JOIN UsersGames ug ON u.Id = ug.UserId
JOIN Games g ON ug.GameId = g.Id
JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
JOIN Items i ON ugi.ItemId = i.Id
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >=10
ORDER BY [Items Count] DESC,  [Items Price] DESC, u.Username


--09.
	SELECT
	 u.Username 
	,g.Name AS Game
	, MAX( c.Name ) as Character
	,max(s.Strength) + SUM(s1.Strength)+max(s2.Strength) AS Strength
	,max(s.Defence) + SUM(s1.Defence)+MAX(s2.Defence) AS Defence
	,max(s.Speed) + SUM(s1.Speed)+MAX(s2.Speed) AS Speed
	,max(s.Mind) + SUM(s1.Mind)+MAX(s2.Mind) AS Mind
	,max(s.Luck) + SUM(s1.Luck)+MAX(s2.Luck) AS Luck
	
	
	 FROM Users u
	JOIN UsersGames ug ON u.Id = ug.UserId
	JOIN Games g ON ug.GameId = g.Id
	JOIN Characters c ON c.Id = ug.CharacterId
	JOIN [Statistics] s on c.StatisticId = s.Id
	JOIN UserGameItems ugi ON ug.Id = ugi.UserGameId
	JOIN Items i ON ugi.ItemId = i.Id
	JOIN [Statistics] s1 ON s1.Id = i.StatisticId
	JOIN GameTypes gt ON gt.Id = g.GameTypeId
	JOIN [Statistics] s2 ON s2.Id = gt.BonusStatsId

	GROUP BY  g.Name, u.Username
	ORDER BY Strength DESC, Defence DESC,Speed DESC,Mind DESC, Luck DESC

	


--10.

SELECT 
i.Name,
i.Price,
i.MinLevel,
s.Strength,
s.Defence,
s.Speed,
s.Luck,
s.Mind

 FROM Items i
JOIN [Statistics] s ON i.StatisticId = s.Id

WHERE s.Mind > 
(SELECT AVG(s1.Mind) FROM [Statistics] s1) 
AND
s.Luck > 
(SELECT AVG(s1.Luck) FROM [Statistics] s1)
AND
 s.Speed > 
(SELECT AVG(s1.Speed) FROM [Statistics] s1)
ORDER BY i.Name


--11.
SELECT

DISTINCT i.Name as Item,
i.Price,
i.MinLevel,
gt.Name AS [Forbidden Game Type]


FROM
Games g 
FULL JOIN GameTypes gt ON g.GameTypeId = gt.Id
FULL JOIN GameTypeForbiddenItems gtfi ON gt.Id = gtfi.GameTypeId
FULL JOIN Items i ON gtfi.ItemId = i.Id
ORDER BY gt.Name DESC, i.Name ASC

--12.

SELECT i.Id FROM Items i
WHERE i.Name = 'Blackguard'
OR i.Name = 'Bottomless Potion of Amplification'
OR i.Name = 'Eye of Etlich (Diablo III)'
OR i.Name = 'Gem of Efficacious Toxin'
OR i.Name = 'Golden Gorget of Leoric'
OR i.Name = 'Hellfire Amulet'




SELECT * FROM UsersGames ug 
WHERE 
ug.GameId =(SELECT g.Id FROM Games g
WHERE g.Name = 'Edinburgh') 
and ug.UserId = (SELECT u.Id FROM Users u 
WHERE u.Username = 'Alex')


INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES
((SELECT i.Id FROM Items i WHERE i.Name = 'Blackguard'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Bottomless Potion of Amplification'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Eye of Etlich (Diablo III)'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Gem of Efficacious Toxin'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Golden Gorget of Leoric'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Hellfire Amulet'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =221 and ug.UserId = 5))


UPDATE UsersGames 
SET Cash = Cash - (SELECT i.Price FROM Items i WHERE i.Name = 'Blackguard')
-(SELECT i.Price FROM Items i WHERE i.Name = 'Bottomless Potion of Amplification')
-(SELECT i.Price FROM Items i WHERE i.Name = 'Eye of Etlich (Diablo III)')
-(SELECT i.Price FROM Items i WHERE i.Name = 'Gem of Efficacious Toxin')
-(SELECT i.Price FROM Items i WHERE i.Name = 'Golden Gorget of Leoric')
-(SELECT i.Price FROM Items i WHERE i.Name = 'Hellfire Amulet')
WHERE UserId = (SELECT u.Id FROM Users u 
WHERE u.Username = 'Alex')

SELECT u.Username,g.Name,ug.Cash, i.Name AS [Item Name] FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON g.Id = ug.GameId
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON i.Id = ugi.ItemId
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name


--13.


SELECT * FROM UsersGames ug 
WHERE 
ug.GameId =(SELECT g.Id FROM Games g
WHERE g.Name = 'Safflower') 
and ug.UserId = (SELECT u.Id FROM Users u 
WHERE u.Username = 'Stamat')


BEGIN TRY
	BEGIN TRANSACTION [Tran 1]
		
		DECLARE @userId int = (SELECT u.Id FROM Users u WHERE u.Username = 'Stamat')

DECLARE @gameId int = (SELECT g.Id FROM Games g WHERE g.Name = 'Safflower')


DECLARE itemsCursor CURSOR FOR
                                	SELECT i.Price, i.Id FROM Items i 
									WHERE i.MinLevel = 11 OR i.MinLevel = 12
																	
                                OPEN itemsCursor
									DECLARE @price MONEY
									DECLARE @itemID INT
									 FETCH NEXT FROM itemsCursor INTO
								@price, @itemID
                                
                                WHILE @@FETCH_STATUS = 0 BEGIN
									
									INSERT INTO UserGameItems (ItemId, UserGameId)
									VALUES (@itemID, @gameId)


									UPDATE UsersGames 
									SET Cash = Cash - @price
									WHERE UserId = @userId
                                
                                	FETCH NEXT FROM itemsCursor INTO 
									@price, @itemID
                                
                                END
                                
                                CLOSE itemsCursor
								DEALLOCATE itemsCursor
	COMMIT TRANSACTION
END TRY
BEGIN CATCH

		ROLLBACK TRANSACTION [Tran 1]
  	
END CATCH;





SELECT i.Name FROM Items i
JOIN UserGameItems ugi ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = (SELECT g.Id FROM Games g
WHERE g.Name = 'Safflower')
ORDER BY i.Name





INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES
((SELECT i.Id FROM Items i WHERE i.Name = 'Angelic Shard'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Belt of Transcendence'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Crashing Rain'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Crusader Shields'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Frozen Blood'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Gem of Efficacious Toxin'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Gladiator Gauntlets'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Glowing Ore'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Gogok of Swiftness'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Illusory Boots'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Last Breath'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'The Crudest Boots'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'The Ninth Cirri Satchel'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)),
((SELECT i.Id FROM Items i WHERE i.Name = 'Wall of Man'),(SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9))



SELECT i.name, i.id FROM Items i
WHERE i.MinLevel =11 OR i.MinLevel =12

SELECT i.Name AS [Item Name] FROM Items i
JOIN UserGameItems ugi ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = (SELECT ug.id FROM UsersGames ug WHERE ug.GameId =87 and ug.UserId = 9)
ORDER BY i.Name



--14.




CREATE  function fn_CashInUsersGames  (@param1 NVARCHAR(MAX))
RETURNS MONEY
AS BEGIN
DECLARE @sum MONEY = 0;
DECLARE @row INT =1;
			DECLARE cashCursor CURSOR FOR
                                	SELECT  ug.Cash FROM UsersGames ug
									JOIN Games g ON g.Id = ug.GameId
									WHERE g.Name = @param1
									ORDER BY ug.Cash DESC
																	
                                OPEN cashCursor
									DECLARE @currentCash MONEY
									
									 FETCH NEXT FROM cashCursor INTO
									@currentCash
                                
                                WHILE @@FETCH_STATUS = 0 BEGIN
									IF @row%2!=0 BEGIN  
                                    	SET @sum = @sum + @currentCash
                                    END
                                    
									
									SET @row = @row+1;
                                	FETCH NEXT FROM cashCursor INTO 
									@currentCash
                                
                                END
                                
                                CLOSE cashCursor
								DEALLOCATE cashCursor

	RETURN @sum
END
GO

SELECT * FROM 
SELECT dbo.fn_CashInUsersGames('Bali')
UNION
SELECT 
dbo.fn_CashInUsersGames('Lily Stargazer')
UNION
SELECT 
dbo.fn_CashInUsersGames('Love in a mist')
UNION
SELECT 
dbo.fn_CashInUsersGames('Mimosa')
UNION
SELECT 
dbo.fn_CashInUsersGames('Ming fern')
