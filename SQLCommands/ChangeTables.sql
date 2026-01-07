ALTER TABLE Booking
DROP CONSTRAINT booking_drakkar_id_fkey;

ALTER TABLE Booking
DROP CONSTRAINT booking_cruise_id_fkey;

ALTER TABLE Booking
ADD Foreign key (drakkar_id, cruise_id) references ticket(drakkar_id, cruise_id);