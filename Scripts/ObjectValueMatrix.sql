DECLARE @sql NVARCHAR(MAX)
DECLARE @columns NVARCHAR(MAX)

-- Build the column list dynamically
SELECT @columns = STRING_AGG(
    'MAX(CASE WHEN Q.Id = ' + CAST(Id AS NVARCHAR(10)) + 
    ' THEN AA.Value END) AS [' + Text + ']',
    ', '
)
FROM [dbo].[Questions]

-- Build the full query
SET @sql = '
SELECT 
    A.Id AS AnimalId,
    A.Name AS AnimalName,
    ' + @columns + '
FROM [TwentyQ].[dbo].[Animals] AS A
INNER JOIN [dbo].[AnimalAnswers] AS AA ON A.Id = AA.AnimalId
INNER JOIN [dbo].[Questions] AS Q ON AA.QuestionId = Q.Id
GROUP BY A.Id, A.Name
'

-- Execute it
EXEC sp_executesql @sql