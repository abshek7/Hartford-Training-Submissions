CREATE DATABASE ASSIGNMENT_WEEK1;
USE ASSIGNMENT_WEEK1;


--VC2,VC IN ORACLE
CREATE TABLE ClientMaster(
ClientNo VARCHAR(6) PRIMARY KEY
CHECK (ClientNo LIKE 'C%'),
Name VARCHAR(20) NOT NULL,
Address1 VARCHAR(20),
Address2 VARCHAR(20),
City VARCHAR(15),
Pincode NUMERIC(8),
State VARCHAR(15),
BalDue NUMERIC(10,2)
);

CREATE TABLE ProductMaster (
    ProductNo VARCHAR(6) PRIMARY KEY 
    CHECK (ProductNo LIKE 'P%'),
    Description VARCHAR(15) NOT NULL,
    ProfitPercent NUMERIC(4,2) NOT NULL,
    UnitMeasure VARCHAR(10) NOT NULL,
    QtyOnHand INT NOT NULL,
    ReorderLvl INT NOT NULL,
    SellPrice NUMERIC(8,2) NOT NULL CHECK (SellPrice != 0),
    CostPrice NUMERIC(8,2) NOT NULL CHECK (CostPrice != 0)
);


CREATE TABLE SalesManMaster(
        SalesManNo VARCHAR(6) PRIMARY KEY
        CHECK (SalesManNo LIKE 'S%'),
        SalesManName VARCHAR(20) NOT NULL,
        Address1 VARCHAR(30) NOT NULL,
        Address2 VARCHAR(30),
        CITY VARCHAR(20),
        Pincode NUMERIC(8),
        State VARCHAR(20),
        SalAmt NUMERIC(8,2) NOT NULL
        CHECK (SalAmt!=0),
        TargetToGet NUMERIC(6,2) NOT NULL,
        YearTdSales NUMERIC(6,2) NOT NULL,
        Remarks VARCHAR(60)
);


CREATE TABLE SalesOrder(
OrderNo VARCHAR(6) PRIMARY KEY
CHECK (OrderNo LIKE 'O%'),
ClientNo VARCHAR(6),
OrderDate DATE,
DelAddr VARCHAR(25),
SalesManNo VARCHAR(6),
DelType CHAR(1)
CHECK (DelType IN ('P','F')),
BilledYN CHAR(1)
CHECK (BilledYN IN ('Y','N')),
DelDate DATE,
OrderStatus VARCHAR(10)
CHECK (OrderStatus IN ('In Process','Fulfilled','Backorder','Cancelled')),

CONSTRAINT FK_SO_Client
FOREIGN KEY (ClientNo)
REFERENCES ClientMaster(ClientNo),

CONSTRAINT FK_SO_SalesMan
FOREIGN KEY (SalesManNo)
REFERENCES SalesManMaster(SalesManNo),
);



CREATE TABLE SalesOrderDetails(
OrderNo VARCHAR(6),
ProductNo VARCHAR(6),
QtyOrdered NUMERIC(8),
QtyDisp NUMERIC(8),
ProductRate NUMERIC(10,2),

CONSTRAINT PK_SalesOrderDetails
PRIMARY KEY (OrderNo,ProductNo),

CONSTRAINT FK_SOD_Order
FOREIGN  KEY(OrderNo)
REFERENCES SalesOrder(OrderNo),

CONSTRAINT FK_SOD_Product
FOREIGN  KEY(ProductNo)
REFERENCES ProductMaster(ProductNo),
);


--client master values insertion

INSERT INTO ClientMaster VALUES
('C0001','abhi','13-195','kamala nagar colony','medipally',500098,'telangana',1200.00),

('C0002','santhu','plot 45','railway colony','secunderabad',500003,'telangana',3500.50),

('C0003','spoorthik','near lake view','main road','tellapur',502032,'telangana',800.00),

('C0004','varun','teachers colony','station road','warangal',506002,'telangana',150.75),

('C0005','bhanu','flat 302','mg road','mumbai',400001,'maharashtra',2200.00),

('C0006','durgi','lane 7','shivaji nagar','mumbai',400002,'maharashtra',5000.00),

('C0007','arav','block b','it park','secunderabad',500015,'telangana',950.00),

('C0008','sai','phase 2','financial district','tellapur',502032,'telangana',1750.00);


--
INSERT INTO ProductMaster VALUES
('P0001','Trousers',10.00,'Piece',200,50,2500.00,2000.00),
('P0002','Pull Overs',12.00,'Piece',150,40,1800.00,1400.00),
('P0003','T-Shirts',8.00,'Piece',300,60,1200.00,900.00),
('P0004','Jeans',15.00,'Piece',100,30,3000.00,2500.00),
('P0005','4.44 Drive',5.00,'Piece',50,10,1300.00,1000.00);


INSERT INTO SalesManMaster VALUES
('S0001','Aman','A-14','Worli','Mumbai',400002,'Maharashtra',3000.00,100.00,50.00,'Good'),

('S0002','Ravi','Road No 5','Kukatpally','Hyderabad',500072,'Telangana',4000.00,120.00,80.00,'Excellent'),

('S0003','Kiran','Sector 9','Market Road','Warangal',506002,'Telangana',3500.00,90.00,60.00,'Average');


INSERT INTO SalesOrder VALUES
('O19001','C0001','2022-06-12','Hyderabad','S0001','F','N','2022-07-20','In Process'),

('O19002','C0005','2022-06-18','Mumbai','S0002','P','Y','2022-06-25','Fulfilled'),

('O19003','C0002','2022-05-10','Secunderabad','S0003','F','N','2022-05-20','Fulfilled'),

('O19004','C0006','2022-04-02','Mumbai','S0001','P','N','2022-04-10','Backorder');






UPDATE SalesOrder
SET 
    OrderDate = DATEADD(DAY, -10, GETDATE()),
    DelDate   = DATEADD(DAY, 5, GETDATE()),
    OrderStatus = 'In Process'
WHERE OrderNo = 'O19001';



UPDATE SalesOrder
SET 
    OrderDate = DATEADD(DAY, -5, GETDATE()),
    DelDate   = DATEADD(DAY, 10, GETDATE()),
    OrderStatus = 'Backorder'
WHERE OrderNo = 'O19004';




INSERT INTO SalesOrderDetails VALUES
('O19001','P0001',4,4,2500.00),
('O19001','P0002',2,2,1800.00),

('O19002','P0003',6,6,1200.00),

('O19003','P0002',3,3,1800.00),

('O19004','P0002',2,1,1800.00),
('O19004','P0004',1,1,3000.00);


select * from ClientMaster;
select * from ProductMaster;
select * from SalesManMaster;
select * from SalesOrder;
select * from SalesOrderDetails

SELECT Name from ClientMaster;


--
--display all clients who are in mumbai

SELECT * from ClientMaster WHERE City='Mumbai';

--display  all prod whose sp>2000 and <5000

SELECT * FROM ProductMaster where SellPrice BETWEEN 2000 AND 5000;

--display name,city,state of clients not in state of maharashtra


SELECT  Name,City,State FROM ClientMaster WHERE State!='maharashtra';

SELECT  Name,City,State FROM ClientMaster WHERE State NOT IN (
SELECT State FROM ClientMaster WHERE State='maharashtra'
);


--Display all the information of client no C0001 and C0002

SELECT * FROM  ClientMaster WHERE ClientNo IN ('C0001','C0002');

--Change the selling price of '1.44 drive' to Rs. 1150.50.

--SELECT * FROM ProductMaster;


--UPDATE ProductMaster
--SET Description = '1.44 drive'
--WHERE Description = '4.44 drive';


UPDATE ProductMaster
SET SellPrice = 1150.50
WHERE Description = '1.44 drive';


--Delete the record of client_no C0005


DELETE FROM ClientMaster
WHERE ClientNo='C0005';


--The DELETE statement conflicted with the REFERENCE constraint "FK_SO_Client". The conflict occurred in database "ASSIGNMENT_WEEK1", table "dbo.SalesOrder", column 'ClientNo'.
--The statement has been terminated.

--2 ways
-- on delete cascade
-- sequential multiple series of statments

ALTER TABLE SalesOrder DROP CONSTRAINT FK_SO_Client;
ALTER TABLE SalesOrder ADD CONSTRAINT FK_SO_Client FOREIGN KEY(ClientNo) REFERENCES ClientMaster(ClientNo) ON DELETE CASCADE;


ALTER TABLE SalesOrderDetails DROP CONSTRAINT FK_SOD_Order;
ALTER TABLE SalesOrderDetails ADD CONSTRAINT FK_SOD_Order FOREIGN KEY(OrderNo) REFERENCES SalesOrder(OrderNo) ON DELETE CASCADE;

DELETE FROM ClientMaster
WHERE ClientNo = 'C0005';


--Display the clients who stay in a city whose second letter is 'a'


SELECT * FROM ClientMaster WHERE City LIKE '_a%';


--Count the number of products having price greater than or equal to 1500

SELECT COUNT(*) as cnt FROM ProductMaster WHERE SellPrice>=1500;


SELECT QtyOrdered,QtyDisp,(QtyOrdered-QtyDisp) AS BalanceQty
FROM SalesOrderDetails;

--add a new column phone number in clientmaster table
ALTER TABLE ClientMaster ADD PhoneNo VARCHAR(15);
--SELECT * FROM ClientMaster


--change size of name column to 60 in clientmaster table
ALTER TABLE ClientMaster ALTER COLUMN Name VARCHAR(60) NOT NULL;

--Remove pincode column from table
ALTER TABLE ClientMaster DROP COLUMN Pincode;

--SELECT * FROM ClientMaster


--Find out the products which have been sold to 'Ivan Bayross'
SELECT p.Description FROM ClientMaster c
JOIN SalesOrder o ON c.ClientNo=o.ClientNo
JOIN SalesOrderDetails d ON o.OrderNo=d.OrderNo
JOIN ProductMaster p ON d.ProductNo=p.ProductNo
WHERE c.Name='abhi';

--Finding out the products and their quantities that will have to be delivered in the current month

SELECT p.Description,d.QtyDisp FROM SalesOrder o
JOIN SalesOrderDetails d ON o.OrderNo=d.OrderNo
JOIN ProductMaster p ON d.ProductNo=p.ProductNo
WHERE MONTH(o.DelDate)=MONTH(GETDATE())
AND YEAR(o.DelDate)=YEAR(GETDATE());


SELECT 
    P.ProductNo,
    P.Description
FROM ProductMaster P
JOIN SalesOrderDetails SOD 
    ON P.ProductNo = SOD.ProductNo
GROUP BY P.ProductNo, P.Description
HAVING COUNT(SOD.ProductNo) > 1;


--Finding the names of clients who have purchased 'Trousers'
SELECT DISTINCT c.Name FROM ClientMaster c
JOIN SalesOrder o ON  c.ClientNo=o.ClientNo
JOIN SalesOrderDetails d ON o.OrderNo=d.OrderNo
JOIN ProductMaster p ON d.ProductNo=p.ProductNo
WHERE p.Description='trousers';



SELECT 
    SO.OrderNo,
    P.ProductNo,
    P.Description,
    SOD.QtyOrdered
FROM SalesOrder SO
JOIN SalesOrderDetails SOD 
    ON SO.OrderNo = SOD.OrderNo
JOIN ProductMaster P 
    ON SOD.ProductNo = P.ProductNo
WHERE P.Description = 'Pull Overs'
  AND SOD.QtyOrdered < 5;



---subqueries
SELECT Description from ProductMaster
WHERE ProductNo NOT IN (
SELECT ProductNo FROM SalesOrderDetails
);


--Finding the name and complete address for the customer who has placed Order number 'O19001'
SELECT * FROM ClientMaster WHERE ClientNo =(
SELECT ClientNo from SalesOrder where OrderNo='O19001'
);


 --Finding the clients who have placed orders before the month of May'02

SELECT Name FROM ClientMaster where ClientNo IN
( SELECT ClientNo FROM SalesOrder
  WHERE OrderDate<'2002-05-01'
);


---
SELECT FORMAT(CAST('2012-02-11' AS DATE), 'dddd, MMMM dd, yyyy') AS system_date;

---
SELECT FORMAT(99999.99, 'C') AS balance_due;
SELECT 
    ClientNo,
    FORMAT(BalDue, 'C') AS Balance_Due
FROM ClientMaster;


----
SELECT 'Salesman Aman sold goods of 50 while given target was 100' AS message;


--
SELECT DATEDIFF(YEAR, '2004-07-03', GETDATE()) AS age_in_years;
