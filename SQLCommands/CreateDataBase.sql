CREATE TABLE Drakkar
(
	Drakkar_ID int primary key,
	Drakkar_range int,
	Drakkar_name varchar,
	Constraint valid_range Check (Drakkar_range > 0 AND Drakkar_range <= 10)
);

CREATE TABLE Cruise
(
	Cruise_ID int primary key,
	Place_of_departure varchar,
	Place_of_arrival varchar,
	Time_of_departure timestamp with time zone
);

CREATE TABLE Ticket
(
	Cruise_ID int unique,
	Drakkar_ID int unique,
	Foreign key (Cruise_ID) References Cruise(Cruise_ID),
	Foreign key (Drakkar_ID) References Drakkar(Drakkar_ID),
	Primary key (Cruise_ID, Drakkar_ID),
	Price int
);

CREATE TABLE Booking
(
	Booking_ID int primary key,
	User_name varchar,
	Booking_time timestamp with time zone,
	Cruise_ID int,
	Drakkar_ID int,
	Foreign key (Cruise_ID) References Ticket(Cruise_ID),
	Foreign key (Drakkar_ID) References Ticket(Drakkar_ID)
);