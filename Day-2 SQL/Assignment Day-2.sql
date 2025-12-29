--1) creation of database
CREATE DATABASE InsuranceDB;

USE InsuranceDB;

--2) creation of tables with relationships and constraints
CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) CONSTRAINT PK_Customers PRIMARY KEY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20),
    DateOfBirth DATE,
    Phone VARCHAR(20),
    Email VARCHAR(20) UNIQUE
);

CREATE TABLE Policies (
    PolicyID INT IDENTITY(1,1) CONSTRAINT PK_Policies PRIMARY KEY,
    PolicyName VARCHAR(20),
    PolicyType VARCHAR(20),
    PremiumAmount DECIMAL(10,2),
    DurationYear INT
);

CREATE TABLE Agents (
    AgentID INT IDENTITY(1,1) CONSTRAINT PK_Agents PRIMARY KEY,
    AgentName VARCHAR(20),
    Phone VARCHAR(15),
    City VARCHAR(20)
);

CREATE TABLE PolicyAssignments (
    AssignmentID INT IDENTITY(1,1) CONSTRAINT PK_PolicyAssignments PRIMARY KEY,
    CustomerID INT,
    PolicyID INT,
    AgentID INT,
    StartDate DATE,
    EndDate DATE,

    CONSTRAINT FK_PolicyAssignments_Customers
        FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),

    CONSTRAINT FK_PolicyAssignments_Policies
        FOREIGN KEY (PolicyID) REFERENCES Policies(PolicyID),

    CONSTRAINT FK_PolicyAssignments_Agents
        FOREIGN KEY (AgentID) REFERENCES Agents(AgentID)
);


CREATE TABLE Claims (
    ClaimID INT IDENTITY(1,1) CONSTRAINT PK_Claims PRIMARY KEY,
    AssignmentID INT,
    ClaimDate DATE,
    ClaimAmount DECIMAL(10,2),
    ClaimStatus VARCHAR(20),

    CONSTRAINT FK_Claims_PolicyAssignments
        FOREIGN KEY (AssignmentID) REFERENCES PolicyAssignments(AssignmentID)
);


INSERT INTO Customers (FirstName, LastName, DateOfBirth, Phone, Email)
VALUES
('Abhi', 'Shek', '2004-07-03', '7075268421', 'abhishek@gmail.com'),
('Santhu', 'Chepuri', '2004-05-24', '9080706050', 'chepuri@gmail.com');

INSERT INTO Policies (PolicyName,PolicyType,PremiumAmount,DurationYear)
VALUES
('Life Term', 'Life', 15000.00, 20),
('Health Plus', 'Health', 12000.00, 10);


INSERT INTO Agents (AgentName, Phone, City)
VALUES
('Spoorthik', '7867867867', 'Karachi'),
('Idries', '7867867866', 'Rawalpindi');


INSERT INTO PolicyAssignments
(CustomerID, PolicyID, AgentID, StartDate, EndDate)
VALUES
(1, 1, 1, '2025-01-01', '2045-01-01'),
(2, 2, 2, '2025-06-01', '2035-06-01');


INSERT INTO Claims
(AssignmentID, ClaimDate, ClaimAmount, ClaimStatus)
VALUES
(1, '2026-02-15', 50000.00, 'Approved'),
(2, '2026-03-10', 30000.00, 'Pending');

SELECT * FROM Agents;

SELECT * FROM Claims;

SELECT * FROM Policies;

SELECT * FROM PolicyAssignments;

SELECT * FROM Customers;

INSERT INTO Customers (FirstName, LastName, DateOfBirth, Phone, Email)
VALUES
('Varun', 'Kumar', '1999-08-12', '9001112233', 'varun@gmail.com'),
('Bhanu', 'Prakash', '1998-03-25', '9002223344', 'bhanu@gmail.com'),
('Ramu', 'Reddy', '2000-12-05', '9003334455', 'ramu@gmail.com');


INSERT INTO Policies (PolicyName, PolicyType, PremiumAmount, DurationYear)
VALUES
('Life Term', 'Life', 18000.50, 25),
('Health Shield', 'Health', 9500.75, 12),
('Car Protect', 'Vehicle', 7200.00, 5);


INSERT INTO Agents(AgentName,Phone,City)
VALUES 
('Anil', '9876543210', 'Delhi'),
('Suresh', '9223344556', 'Hyderabad');


INSERT INTO PolicyAssignments
(CustomerID, PolicyID, AgentID, StartDate, EndDate)
VALUES
(3, 3, 1, '2023-01-10', '2048-01-10'),
(4, 4, 2, '2024-06-15', '2036-06-15'),
(5, 5, 1, '2025-03-01', '2030-03-01');


INSERT INTO Claims
(AssignmentID, ClaimDate, ClaimAmount, ClaimStatus)
VALUES
(3, '2024-11-20', 45000.00, 'Approved'),
(4, '2025-07-05', 15000.00, 'Rejected'),
(5, '2025-09-18', 8000.00, 'Pending');


INSERT INTO Customers (FirstName, LastName, DateOfBirth, Phone, Email)
VALUES
('sangu', 'Rao', '2002-02-10', '9876543210', 'sangu@gmail.com'),
('Manu', 'pal', '1998-11-15', '9876543211', 'manu@gmail.com');



INSERT INTO Policies (PolicyName, PolicyType, PremiumAmount, DurationYear)
VALUES
('Motor Secure', 'Motor', 11000.00, 1),
('Family Health', 'Health', 20000.00, 1);

INSERT INTO Agents (AgentName, Phone, City)
VALUES
('Rakesh', '9112233445', 'Bangalore'),
('Ajay', '9887766554', 'Chandigarh');


INSERT INTO PolicyAssignments (CustomerID, PolicyID, AgentID, StartDate, EndDate)
VALUES
(1, 6, 3, '2024-01-01', '2025-01-01'),
(2, 7, 4, '2025-02-01', '2026-02-01'),
(6, 4, 3, '2023-05-10', '2035-05-10');


INSERT INTO Claims (AssignmentID, ClaimDate, ClaimAmount, ClaimStatus)
VALUES
(6, '2025-03-15', 60000.00, 'Approved'),
(7, '2025-05-20', 25000.00, 'Rejected');



-- 4)select commands

--4.1 view all records from customers
SELECT * FROM Customers;

--4.2 select  from Policies;


SELECT CustomerID, PolicyID, StartDate, EndDate FROM PolicyAssignments;


--4.3 health policies
SELECT * FROM Policies WHERE PolicyType='Health';

--4.4 
Select * from Policies
Where PremiumAmount>10000 AND DurationYear=1;

--4.5 unique cities;
SELECT DISTINCT City FROM Agents;


--4.6 listing using or operator 
 SELECT * FROM Policies
WHERE PolicyType='Life' OR PolicyType='Health' OR PolicyType='Motor';

--4.7 listing using in operator
SELECT * FROM Policies
WHERE PolicyType IN ('Life','Health','Motor');

--4.8 <= and => operator (otherwise between operator)
SELECT * FROM Customers
WHERE DateOfBirth >= '2001-01-01'
AND DateOfBirth <= '2020-12-31';

--4.9 between operator
SELECT * FROM Customers
WHERE DateOfBirth BETWEEN'2001-01-01'
AND '2020-12-31';

--4.10 rejectec claims

SELECT * FROM Claims WHERE ClaimStatus='Rejected';


--4.11 agents city 2nd letter is a 
SELECT * FROM Agents
WHERE City LIKE '_a%';


--4.12
select max(ClaimAmount) as HighestClaim,min(ClaimAmount) as LowestClaim
from Claims;
select * from Claims;

--4.13
select top 1* from Claims
order by ClaimDate;

--4.14
UPDATE Policies
SET PremiumAmount=PremiumAmount*1.10
WHERE PolicyType='Health';

--select * from Policies;


--4.15
-- here policy assignments is parent table and we have claims which is dependent on policy assignment
-- we cant delete directly
-- we need to delete dependency first
--DELETE FROM PolicyAssignments
--WHERE EndDate < GETDATE();

DELETE FROM Claims
WHERE AssignmentID IN (
    SELECT AssignmentID
    FROM PolicyAssignments
    WHERE EndDate < GETDATE()
);

DELETE FROM PolicyAssignments
WHERE EndDate < GETDATE();


--4.16

SELECT COUNT(*) AS RejectedClaims
FROM Claims
WHERE ClaimStatus = 'Rejected';

--4.17

select PolicyID,PolicyName,PremiumAmount,
PremiumAmount*0.06 AS LocalTaxes,
PremiumAmount*1.06 AS PremiumTaxes,
(PremiumAmount*1.06)/12 AS Montly
FROM Policies;


--4.18
select * from Customers;

ALTER table customers
ADD Address VARCHAR(50),
City VARCHAR(20);

--4.19
ALTER TABLE Agents
ADD DevOfId INT;
select* from Agents;

--4.20
ALTER TABLE Agents
ADD CONSTRAINT FK_Agents_DevOfId
FOREIGN KEY(DevOfId) REFERENCES Agents(AgentId);

--5 queries using  joins,groupby,having

--5.1
SELECT p.* -- we need policies only
FROM Policies p   
JOIN PolicyAssignments pa ON p.PolicyID = pa.PolicyID  --join condition
WHERE pa.CustomerID = 5;
 

--5.2
select FirstName,PolicyName
FROM Customers c
JOIN PolicyAssignments pa
on c.CustomerID=pa.CustomerID
JOIN Policies p
on p.PolicyID=pa.PolicyID;

--5.3
select c.FirstName,cl.ClaimAmount,cl.ClaimStatus from  Claims cl join PolicyAssignments pa on cl.AssignmentID=pa.AssignmentID
join Customers c  on pa.CustomerID=c.CustomerID;


--5.4
select FirstName,PolicyName,AgentName,StartDate,EndDate
FROM PolicyAssignments pa
join Customers c on pa.CustomerID=c.CustomerID
join Policies p on pa.PolicyID=p.PolicyID
join Agents a on pa.AgentID=a.AgentID;

--5.5
SELECT c.FirstName, p.PolicyName,
       cl.ClaimAmount, cl.ClaimStatus, cl.ClaimDate
FROM Claims cl
JOIN PolicyAssignments pa ON cl.AssignmentID = pa.AssignmentID
JOIN Customers c ON pa.CustomerID = c.CustomerID
JOIN Policies p ON pa.PolicyID = p.PolicyID;


--5.6
SELECT c.CustomerID,c.FirstName,p.PolicyName,p.PolicyID
FROM Customers c
LEFT JOIN PolicyAssignments pa ON c.CustomerID = pa.CustomerID
LEFT JOIN Policies p ON pa.PolicyID = p.PolicyID;

--5.7 
select c.* from Customers c
left join PolicyAssignments pa on c.CustomerID=pa.CustomerID
left join Claims cl on cl.AssignmentID=pa.AssignmentID
where cl.ClaimID is null;


--5.8
select concat(c.FirstName,c.LastName) as FullName,
sum(cl.ClaimAmount) as TotalClaim
from Customers c
join PolicyAssignments pa on pa.CustomerID=c.CustomerID
join Claims cl on cl.AssignmentID=pa.AssignmentID
group by c.FirstName,c.LastName;


select concat(c.FirstName,c.LastName) as FullName,
sum(cl.ClaimAmount) as TotalClaim
from Customers c
join PolicyAssignments pa on pa.CustomerID=c.CustomerID
join Claims cl on cl.AssignmentID=pa.AssignmentID
group by c.FirstName,c.LastName
having sum(cl.ClaimAmount)>50000;


--5.10
--agentwise policy count
SELECT a.AgentName,COUNT(pa.AgentID) AS PolicyCount
FROM Agents a
JOIN PolicyAssignments pa
ON
a.AgentID=pa.AgentID
group by a.AgentID,a.AgentName;