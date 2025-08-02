SELECT TOP (1000) [LetterNumber]
      ,[LetterDate]
      ,[DOJ]
      ,[EmployeeNumber]
      ,[CentreCode]
      ,[BranchCode]
      ,[CategoryCode]
      ,[DepartmentCode]
      ,[SectionCode]
      ,[EmployeeType]
      ,[ServiceType]
      ,[ServiceStatus]
      ,[OfficiatingDesignationCode]
      ,[FatherName]
      ,[DOB]
      ,[CertificateType]
      ,[CertificateNo]
      ,[CertificateDate]
      ,[Age]
      ,[Sex]
      ,[LicenceNumber]
      ,[ExpiryDate]
      ,[Name]
      ,[NickName]
      ,[MaritalStatus]
      ,[Religion]
      ,[Nationality]
      ,[ExtraCurricum]
      ,[MotherLanguage]
      ,[ApplicationNumber]
      ,[ApplicationDate]
      ,[LocationType]
      ,[LocationCode]
      ,[FunctionalDesignation]
      ,[DesignationCode]
      ,[IsActive]
      ,[IsFDActive]
      ,[ReportingToFD]
      ,[DeputationLocationType]
      ,[DeputationLocationCode]
      ,[ConfirmDate]
      ,[DivisionCode]
      ,[SectorCode]
      ,[GodownCode]
      ,[AreaCode]
      ,[PANNumber]
      ,[IssueDate]
      ,[JoiningBasic]
      ,[PresentBasic]
      ,[StatusCode]
      ,[IsMPBuffer]
      ,[OwnResidence]
      ,[TerminationStatus]
      ,[IsSuspended]
      ,[RetirementDate]
      ,[SeqNo]
      ,[BloodGroup]
      ,[InActiveNNo]
  FROM [EmpSample_#OK].[dbo].[tblEmployees]

--Get a List of Employees who have a one part name
SELECT * FROM tblEmployees
WHERE Name NOT LIKE '% '
GO

--Get a List of Employees who have a three part name
SELECT * FROM tblEmployees
WHERE Name LIKE '% % %'
  AND LEN(Name) - LEN(REPLACE(Name, ' ', '')) = 2
  GO

--Get a list of Employees who have a First Middle Or last name as Ram, and not any thing else
SELECT * FROM tblEmployees
WHERE Name = 'Ram'
   OR Name LIKE 'Ram %'
   OR Name LIKE '% Ram'
   OR Name LIKE '% Ram %'
GO

--SQL Bitwise Operations
SELECT 65 | 11 AS Result;  
SELECT 65 ^ 11 AS Result;  
SELECT 65 & 11 AS Result;  
SELECT (12 & 4) | (13 & 1) AS Result;  
SELECT 127 | 64 AS Result;  
SELECT 127 ^ 64 AS Result;  
SELECT 127 ^ 128 AS Result;
SELECT 127 & 64 AS Result; 
SELECT 127 & 128 AS Result;  


--query which returns data in all columns from the table dbo.tblCentreMaster
SELECT * FROM dbo.tblCentreMaster;

--Query to get distinct employee types in the organization
SELECT DISTINCT EmployeeType FROM tblEmployees;

--Query to return Name, FatherName, and DOB of employees based on PresentBasic
--a.Greater than 3000.
SELECT Name, FatherName, DOB FROM tblEmployees
WHERE PresentBasic > 3000
GO

--b.Less than 3000.
SELECT Name, FatherName, DOB FROM tblEmployees
WHERE PresentBasic < 3000
GO

--c.PresentBasic BETWEEN 3000 and 5000
SELECT Name, FatherName, DOB FROM tblEmployees
WHERE PresentBasic BETWEEN 3000 AND 5000
GO

--Query to return all details of employees based on Name conditions
--a.Ends with 'KHAN'
SELECT * FROM tblEmployees
WHERE Name LIKE '%KHAN'
GO

--b.Starts with 'CHANDRA'
SELECT * FROM tblEmployees
WHERE Name LIKE 'CHANDRA%'
GO

--c.Name is 'RAMESH' and initial is in range 'A' to 'T'
SELECT * FROM tblEmployees
WHERE Name LIKE '_.RAMESH'
  AND UPPER(SUBSTRING(Name, 1, 1)) BETWEEN 'A' AND 'T';

