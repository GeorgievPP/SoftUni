
CREATE VIEW v_HighestPeek AS
SELECT TOP(1) *
  FROM [Geography].[dbo].[Peaks]
  ORDER BY Elevation DESC