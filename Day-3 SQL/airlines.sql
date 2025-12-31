CREATE DATABASE AirlineDB;
use AirlineDB;


CREATE TABLE airPassengerProfile (
    profileId VARCHAR(10) PRIMARY KEY,
    password VARCHAR(10),
    firstName VARCHAR(10),
    lastName VARCHAR(10),
    address VARCHAR(100),
    mobileNumber BIGINT,
    emailId VARCHAR(30)
);

CREATE TABLE airFlight (
    flightId VARCHAR(10) PRIMARY KEY,
    airlineId VARCHAR(10),
    airlineName VARCHAR(30),
    fromLocation VARCHAR(20),
    toLocation VARCHAR(20),
    departureTime TIME,
    arrivalTime TIME,
    duration TIME,
    totalSeats INT
);

CREATE TABLE airFlightDetails (
    flightId VARCHAR(10),
    flightDepartureDate DATE,
    price DECIMAL(8,2),
    availableSeats INT,
    PRIMARY KEY (flightId, flightDepartureDate),
    FOREIGN KEY (flightId) REFERENCES airFlight(flightId)
);

CREATE TABLE airTicketInfo (
    ticketId VARCHAR(10) PRIMARY KEY,
    profileId VARCHAR(10),
    flightId VARCHAR(10),
    flightDepartureDate DATE,
    status VARCHAR(10),
    FOREIGN KEY (profileId) REFERENCES airPassengerProfile(profileId),
    FOREIGN KEY (flightId) REFERENCES airFlight(flightId)
);

CREATE TABLE airCreditCardDetails (
    profileId VARCHAR(10),
    cardNumber BIGINT,
    cardType VARCHAR(10),
    expirationMonth INT,
    expirationYear INT,
    PRIMARY KEY (cardNumber),
    FOREIGN KEY (profileId) REFERENCES airPassengerProfile(profileId)
);

INSERT INTO airPassengerProfile VALUES
('P001','pass1','Abhi','Shek','Hyderabad',9876543210,'abhishek@gmail.com'),
('P002','pass2','varun','Kumar','Chennai',9123456780,'varun@gmail.com'),
('P003','pass3','aneet','Padda','Ahmedabad',9988776655,'aneet@gmail.com'),
('P004','pass4','Santhu','Chepuri','Mumbai',9090909090,'santhu@gmail.com'),
('P005','pass5','Deepika','Mehta','Delhi',9012345678,'deepika@gmail.com');

INSERT INTO airFlight VALUES
('F101','A001','IndiGo','Mumbai','Delhi','10:00:00','12:00:00','02:00:00',180),
('F102','A002','AirIndia','Delhi','Bangalore','14:00:00','16:30:00','02:30:00',200),
('F103','A003','Vistara','Chennai','Mumbai','09:00:00','11:00:00','02:00:00',160),
('F104','A004','SpiceJet','Hyderabad','Pune','18:00:00','19:30:00','01:30:00',150),
('F105','A005','Akasa','Kolkata','Delhi','06:00:00','08:30:00','02:30:00',170);

INSERT INTO airFlightDetails VALUES
('F101','2024-09-10',5500.00,150),
('F102','2024-09-11',6200.00,180),
('F103','2024-09-12',4800.00,140),
('F104','2024-09-13',4500.00,130),
('F105','2024-09-14',7000.00,160);

INSERT INTO airTicketInfo VALUES
('T001','P001','F101','2024-09-10','Booked'),
('T002','P002','F102','2024-09-11','Booked'),
('T003','P003','F103','2024-09-12','Cancelled'),
('T004','P004','F104','2024-09-13','Booked'),
('T005','P005','F105','2024-09-14','Booked');

INSERT INTO airCreditCardDetails VALUES
('P001',1111222233334444,'VISA',12,2026),
('P002',2222333344445555,'MASTER',11,2025),
('P003',3333444455556666,'VISA',10,2027),
('P004',4444555566667777,'RUPAY',9,2026),
('P005',5555666677778888,'VISA',8,2028);



select * from airPassengerProfile;
select * from airFlight;
select * from airFlightDetails;
select * from airTicketInfo;
select * from airCreditCardDetails;


INSERT INTO airFlightDetails VALUES
('F102','2024-04-10',6000,170),
('F102','2024-05-15',6400,160),
('F104','2024-04-20',4600,120),
('F104','2024-05-18',4800,110);



INSERT INTO airFlight VALUES
('F106','A002','AirIndia','Chennai','Hyderabad','07:00:00','08:30:00','01:30:00',180);

INSERT INTO airFlightDetails VALUES
('F106','2024-04-12',5200,150),
('F106','2024-04-15',5300,145);


INSERT INTO airTicketInfo VALUES
('T006','P001','F102','2024-04-10','Booked'),
('T007','P001','F102','2024-05-15','Booked'),
('T008','P002','F104','2024-04-20','Booked'),
('T009','P003','F106','2024-04-12','Booked'),
('T010','P003','F106','2024-04-15','Booked'),
('T011','P003','F106','2024-04-15','Booked');


--Write a query to display the average monthly ticket cost for each flight in ABC Airlines. 
--The query should display the Flight_Id, From_location, To_Location,
--Month Name as Month_Name, and average price as Average_Price.
--Display the records sorted in ascending order based on Flight_Id and then by Month_Name.


select f.flightId,f.fromLocation,f.toLocation,DATENAME(MONTH,fd.flightDepartureDate) AS Month_Name,
AVG(fd.price) AS Average_Price
FROM airFlight f
JOIN airFlightDetails fd
ON f.flightId=fd.flightId
WHERE airlineName='AirIndia'
GROUP BY
f.flightId,f.fromLocation,f.toLocation,DATENAME(MONTH,fd.flightDepartureDate)
ORDER BY
f.flightId,
Month_Name;

--sp_helpindex airPassengerProfile;


--Write a query to display the customer(s) who has/have booked least number of tickets in ABC
--Airlines. The Query should display profile_id, customer’s first_name, Address and Number of
--tickets booked as “No_of_Tickets”. Display the records sorted in ascending order based on
--customer's first name



SELECT TOP 1 WITH TIES
    p.profileId,
    p.firstName,
    p.address,
    COUNT(t.ticketId) AS No_of_Tickets
FROM airPassengerProfile p
JOIN airTicketInfo t ON p.profileId = t.profileId
JOIN airFlight f ON t.flightId = f.flightId
WHERE f.airlineName = 'AirIndia'
GROUP BY
    p.profileId,
    p.firstName,
    p.address
ORDER BY COUNT(t.ticketId) ASC, p.firstName ASC;



--Write a query to display the number of flight services between locations in a month. The Query
--should display From_Location, To_Location, Month as “Month_Name” and number of flight
--services as “No_of_Services”. Hint: The Number of Services can be calculated from the
--number of scheduled departure dates of a flight. The records should be displayed in ascending
--order based on From_Location and then by To_Location and then by month name.

SELECT
f.fromLocation AS From_Location,
f.toLocation AS To_Location,
DATENAME(MONTH,fd.flightDepartureDate) AS Month_Name,
COUNT(fd.flightDepartureDate) AS No_of_Services

FROM airFlight f
JOIN airFlightDetails fd
    ON f.flightId = fd.flightId
GROUP BY 
    f.fromLocation,
    f.toLocation,
    DATENAME(MONTH, fd.flightDepartureDate),
    MONTH(fd.flightDepartureDate)
ORDER BY 
    f.fromLocation,
    f.toLocation,
    MONTH(fd.flightDepartureDate);


--Write a query to display the customer(s) who has/have booked maximum number of tickets in
--ABC Airlines. The Query should display profile_id, customer’s first_name, Address and Number
--of tickets booked as “No_of_Tickets”. Display the records in ascending order based on
--customer's first name. 

SELECT TOP 1 WITH TIES
    p.profileId,
    p.firstName,
    p.address,
    COUNT(t.ticketId) AS No_of_Tickets
FROM airPassengerProfile p
JOIN airTicketInfo t ON p.profileId = t.profileId
JOIN airFlight f ON t.flightId = f.flightId
WHERE f.airlineName = 'AirIndia'
GROUP BY
    p.profileId,
    p.firstName,
    p.address
ORDER BY COUNT(t.ticketId) DESC, p.firstName;


--Write a query to display the number of tickets booked from Chennai to Hyderabad. The Query
--should display passenger profile_id,first_name,last_name, Flight_Id , Departure_Date and
--number of tickets booked as “No_of_Tickets”. Display the records sorted in ascending order
--based on profile id and then by flight id and then by departure date.


SELECT
    p.profileId,
    p.firstName,
    f.flightId AS FlightId,
    t.flightDepartureDate AS Departure_Date,
    COUNT(t.ticketId) AS No_of_Tickets
FROM airPassengerProfile p
JOIN airTicketInfo t
ON p.profileId=t.profileId
JOIN airFlight f
ON t.flightId=f.flightId
WHERE
f.fromLocation='Chennai'
and f.toLocation='Hyderabad'
GROUP BY
  p.profileId,
    p.firstName,
    p.lastName,
    f.flightId,
    t.flightDepartureDate
ORDER BY
p.profileId,
f.flightId,
t.flightDepartureDate ASC;


--Write a query to display flight id,from locaƟon, to locaƟon and Ɵcket price of flights whose
--departure is in the month of april. 


SELECT 
    f.flightId,
    f.fromLocation,
    f.toLocation,
    fd.price AS Ticket_Price,
    fd.flightDepartureDate
FROM airFlight f
JOIN airFlightDetails fd
    ON f.flightId = fd.flightId
WHERE MONTH(fd.flightDepartureDate) = 4;


--Write a query to display the average cost of the Ɵckets in each flight on all scheduled dates.
--The query should display flight_id, from_location, to_location and Average price as “Price”.
--Display the records sorted in ascending order based on flight id and then by from_location and
--then by to_location.

select * from airFlight;
select * from airFlightDetails;

select f.flightId,f.fromLocation,f.toLocation,
avg(fd.price) AS Price
FROM airFlight f
JOIN airFlightDetails fd
ON f.flightId=fd.flightId
GROUP BY
f.flightId,
f.fromLocation,
f.toLocation
ORDER BY
f.flightId ASC,f.fromLocation ASC,
f.toLocation ASC;

--Write a query to display the customers who have booked tickets from Chennai to Hyderabad.
--The query should display profile_id, customer_name (combine first_name & last_name with
--comma in b/w), address of the customer. Give an alias to the name as customer_name. Hint:
--Query should fetch unique customers irrespecƟve of multiple tickets booked. Display the
--records sorted in ascending order based on profile id.

select distinct 
p.profileId,
p.firstName+','+p.lastName AS customer_name,
p.address
from airPassengerProfile p
join airTicketInfo t
on p.profileId=t.profileId
join airFlight f
on t.flightId=f.flightId
where f.fromLocation='Chennai'
and f.toLocation='Hyderabad'
order by p.profileId asc;


--Write a query to display profile id of the passenger(s) who has/have booked maximum number
--of tickets. In case of multiple records, display the records sorted in ascending order based on
--profile id. 



select top 1  with ties profileId,count(ticketId) as cnt
from airTicketInfo
group by profileId
order by count(ticketId) desc;



----

SELECT 
    f.flightId,
    f.fromLocation,
    f.toLocation,
    COUNT(t.ticketId) AS No_of_Tickets
FROM airFlight f
JOIN airTicketInfo t
    ON f.flightId = t.flightId
WHERE f.airlineName = 'AirIndia'
GROUP BY 
    f.flightId,
    f.fromLocation,
    f.toLocation
HAVING COUNT(t.ticketId) >= 1
ORDER BY f.flightId ASC;


select * from airFlight;
select * from airTicketInfo;
