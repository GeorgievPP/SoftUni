
UPDATE [NamesWithSalasies]
	SET Salary = Salary * 0.9,
		FullName = '_' + FullName
	WHERE Salary > 60000