
SELECT *
  FROM [SoftUni].[dbo].[Projects]
  WHERE [EndDate] IS NULL

UPDATE [Projects]
	SET [EndDate] = GETDATE()
	WHERE [EndDate] IS NULL

SELECT * FROM Projects