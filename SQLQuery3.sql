UPDATE DivTests 
SET ParamA = 5000000000, ParamB = 1, ExpectedResult = 0, ExpectedError = 'Error 06' 
WHERE TestId = 4;
UPDATE DivTests SET ParamA = 10, ParamB = 2, ExpectedResult = 5, ExpectedError = NULL WHERE TestId = 1;
UPDATE DivTests SET ParamA = -20, ParamB = -5, ExpectedResult = 4, ExpectedError = NULL WHERE TestId = 2;
UPDATE DivTests SET ParamA = 10, ParamB = 0, ExpectedResult = 0, ExpectedError = 'Error 09' WHERE TestId = 3;
UPDATE DivTests SET ParamA = 5000000000, ParamB = 1, ExpectedResult = 0, ExpectedError = 'Error 06' WHERE TestId = 4;