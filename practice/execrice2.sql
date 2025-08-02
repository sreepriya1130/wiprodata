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

--Write a query to get Total Present basic  for all departments
--where total Present basic is greater than 30000, 
--data should be sorted by department
SELECT DepartmentCode, SUM(PresentBasic) AS TotalPresentBasic FROM tblEmployees
GROUP BY DepartmentCode
HAVING SUM(PresentBasic) > 30000
ORDER BY DepartmentCode
GO

 --Max, Min, Avg age by ServiceType, ServiceStatus, and Centre (in Years and Months)
select emp.CentreCode,emp.ServiceType,emp.ServiceStatus,
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as MAX_AGE,
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as MIN_AGE,            
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOB,GETDATE())/12))+'years '+
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOB,GETDATE())%12))+'months' as AVG_AGE
from dbo.tblEmployees emp
group by emp.CentreCode,emp.ServiceType,emp.ServiceStatus
order by emp.CentreCode,emp.ServiceType,emp.ServiceStatus;

--Max, Min, Avg Service (in Years and Months)
select emp.CentreCode,emp.ServiceType,emp.ServiceStatus,
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),MAX(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MAX_SERVICE,            
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),MIN(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as MIN_SERVICE,            
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOJ,GETDATE())/12))+' years '+
CONVERT(varchar(10),AVG(DATEDIFF(MM,EMP.DOJ,GETDATE())%12))+' months' as AVG_SERVICE
from dbo.tblEmployees emp
group by emp.CentreCode,emp.ServiceType,emp.ServiceStatus
order by emp.CentreCode,emp.ServiceType,emp.ServiceStatus;

--Departments where Total Salary > 3× Average Salary
select emp.DepartmentCode,SUM(emp.PresentBasic)
from dbo.tblEmployees emp
group by emp.DepartmentCode
having SUM(emp.PresentBasic)> 3*AVG(emp.PresentBasic);

--Departments where Total Salary > 2× Avg Salary AND MaxBasic ≥ 3× MinBasic
SELECT DepartmentCode FROM tblEmployees
GROUP BY DepartmentCode
HAVING SUM(PresentBasic) > 2 * AVG(PresentBasic)
   AND MAX(PresentBasic) >= 3 * MIN(PresentBasic)
GO

--Centers where Max Name Length = 2× Min Name Length
SELECT CentreCode FROM tblEmployees
GROUP BY CentreCode
HAVING MAX(LEN(Name)) = 2 * MIN(LEN(Name))
GO

--Max, Min, Avg Service in Milliseconds
select emp.CentreCode,emp.ServiceType,emp.ServiceStatus,            
MAX(DATEDIFF(HH,emp.DOJ,GETDATE())) as MAX_SEVICE ,                        
MIN(DATEDIFF(HH,emp.DOJ,GETDATE())) as MIN_SEVICE,            
AVG(DATEDIFF(HH,emp.DOJ,GETDATE())) as AVG_SEVICE            
from dbo.tblEmployees emp
group by emp.CentreCode,emp.ServiceType,emp.ServiceStatus
order by emp.CentreCode,emp.ServiceType,emp.ServiceStatus;   

--Employees with Leading or Trailing Spaces in Names
SELECT * FROM tblEmployees
WHERE Name LIKE ' %' OR Name LIKE '% '
GO

--Employees with Multiple Spaces Between Name Parts
SELECT * FROM tblEmployees
WHERE Name LIKE '%  %'
GO

--Clean Employee Names: Trim + Replace dots and extra spaces with single space
SELECT LTRIM(RTRIM(REPLACE(REPLACE(Name, '.', ' '),'  ', ' '))) AS Name
FROM tblEmployees;

--Employees whose names start and end with the same character
SELECT * 
FROM tblEmployees
WHERE LEFT(LTRIM(Name), 1) = RIGHT(RTRIM(Name), 1);

--Employees whose first and second names start with the same character
SELECT * 
FROM tblEmployees
WHERE 
    CHARINDEX(' ', LTRIM(Name)) > 0 AND
    LEFT(LTRIM(Name), 1) = SUBSTRING(LTRIM(Name), CHARINDEX(' ', Name) + 1, 1);

--Employees whose every word in name starts with the same character
WITH NameParts AS (
    SELECT 
        E.Name,
        Split.a.value('.', 'VARCHAR(100)') AS part
    FROM tblEmployees E
    CROSS APPLY (
        SELECT CAST('<x>' + 
             REPLACE(REPLACE(LTRIM(RTRIM(E.Name)), '.', ' '), ' ', '</x><x>') + 
             '</x>' AS XML) 
    ) AS A(Split)
    CROSS APPLY A.Split.nodes('/x') AS Split(a)
)
SELECT Name
FROM NameParts
GROUP BY Name
HAVING MIN(LEFT(part, 1)) = MAX(LEFT(part, 1));


--15: Any word (excluding initials) in name starts and ends with same character

WITH NameParts AS (
    SELECT 
        E.Name,
        Split.a.value('.', 'VARCHAR(100)') AS part
    FROM tblEmployees E
    CROSS APPLY (
        SELECT CAST('<x>' + 
             REPLACE(REPLACE(LTRIM(RTRIM(E.Name)), '.', ' '), ' ', '</x><x>') + 
             '</x>' AS XML) 
    ) AS A(Split)
    CROSS APPLY A.Split.nodes('/x') AS Split(a)
)
SELECT DISTINCT Name
FROM NameParts
WHERE LEN(part) > 1
  AND LEFT(part,1) = RIGHT(part,1);




--16: PresentBasic rounded to hundred using various methods

SELECT Name, PresentBasic
FROM tblEmployees
WHERE ROUND(PresentBasic, -2, 0) = PresentBasic;


SELECT Name, PresentBasic
FROM tblEmployees
WHERE FLOOR(PresentBasic / 100.0) * 100 = PresentBasic;

SELECT Name, PresentBasic
FROM tblEmployees
WHERE PresentBasic % 100 = 0;


SELECT Name, PresentBasic
FROM tblEmployees
WHERE CEILING(PresentBasic / 100.0) * 100 = PresentBasic;

--17: Departments where all employees have basic rounded to 100

SELECT DepartmentCode
FROM tblEmployees
GROUP BY DepartmentCode
HAVING MIN(PresentBasic % 100) = 0
   AND MAX(PresentBasic % 100) = 0;

--18: Departments where no employee has basic rounded to 100

SELECT DepartmentCode
FROM tblEmployees
GROUP BY DepartmentCode
HAVING MAX(CASE WHEN PresentBasic % 100 = 0 THEN 1 ELSE 0 END) = 0;

--:19. Bonus eligibility: service ≥ 1 year 3 months 15 days

SELECT 
    E.Name,
    DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ)) AS EligibilityDate,
    
    DATEDIFF(YEAR, E.DOB, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) AS AgeYears,
    
    DATEDIFF(MONTH, E.DOB, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) % 12 AS AgeMonths,
    
    DATEDIFF(DAY,
        DATEADD(YEAR,
            DATEDIFF(YEAR, E.DOB, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))),
            DATEADD(MONTH,
                DATEDIFF(MONTH, E.DOB, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) % 12,
                E.DOB
            )
        ),
        DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))
    ) AS AgeDays,

    DATENAME(WEEKDAY, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) AS Weekday,
    DATEPART(WEEK, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) AS WeekOfYear,
    DATEPART(DAYOFYEAR, DATEADD(MONTH, 15, DATEADD(DAY, 15, E.DOJ))) AS DayOfYear
FROM tblEmployees AS E;




--20: Bonus eligibility by service type/employee type criteria

SELECT Name, ServiceType, EmployeeType, DOJ, DOB
FROM tblEmployees
WHERE (
    ServiceType = 1 AND EmployeeType = 1 AND
      DATEDIFF(YEAR, DOJ, GETDATE()) >= 10 AND
      DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 60, DOB)) >= 15
)
OR (
    ServiceType = 1 AND EmployeeType = 2 AND
      DATEDIFF(YEAR, DOJ, GETDATE()) >= 12 AND
      DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 55, DOB)) >= 14
)
OR (
    ServiceType = 1 AND EmployeeType = 3 AND
      DATEDIFF(YEAR, DOJ, GETDATE()) >= 12 AND
      DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 55, DOB)) >= 12
)
OR (
    ServiceType IN (2,3,4) AND
      DATEDIFF(YEAR, DOJ, GETDATE()) >= 15 AND
      DATEDIFF(YEAR, GETDATE(), DATEADD(YEAR, 65, DOB)) >= 20
);


--:21. Display current date in all formats using CONVERT

SELECT
  CONVERT(VARCHAR(30), GETDATE(), 100) AS Format100,
  CONVERT(VARCHAR(30), GETDATE(), 101) AS Format101,
  CONVERT(VARCHAR(30), GETDATE(), 103) AS Format103,
  CONVERT(VARCHAR(30), GETDATE(), 112) AS Format112,
  CONVERT(VARCHAR(30), GETDATE(), 121) AS Format121;


--22: Compare net payment vs. expected basic using TblPayEmployeeParamDetails

WITH SalarySummary AS (
    SELECT 
        p.EmployeeNumber,
        e.Name,
        p.NoteNumber,
        SUM(CASE WHEN p.ParamCode = 'BASIC' THEN p.Amount ELSE 0 END) AS BasicPay,
        SUM(p.Amount) AS NetPay
    FROM tblPayEmployeeparamDetails p
    JOIN tblEmployees e ON e.EmployeeNumber = p.EmployeeNumber
    GROUP BY p.EmployeeNumber, e.Name, p.NoteNumber
)
SELECT *
FROM SalarySummary
WHERE NetPay < BasicPay;

WITH SalaryBreakdown AS (
    SELECT 
        p.EmployeeNumber,
        e.Name,
        SUM(CASE WHEN p.ParamCode = 'BASIC' THEN p.Amount ELSE 0 END) AS BasicAmount,
        SUM(CASE WHEN p.ParamCode <> 'BASIC' THEN p.Amount ELSE 0 END) AS OtherComponents
    FROM tblPayEmployeeparamDetails p
    JOIN tblEmployees e ON e.EmployeeNumber = p.EmployeeNumber
    GROUP BY p.EmployeeNumber, e.Name
)
SELECT *
FROM SalaryBreakdown
WHERE OtherComponents < BasicAmount;