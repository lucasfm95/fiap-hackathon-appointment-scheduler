START TRANSACTION;

CREATE TABLE Doctors (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    specialty VARCHAR(100) NOT NULL,
    contact_info VARCHAR(100)
);

CREATE TABLE Patients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    birth_date DATE NOT NULL,
    contact_info VARCHAR(100)
);

CREATE TABLE AppointmentSlots (
    id SERIAL PRIMARY KEY,
    doctor_id INT NOT NULL,
    available_date DATE NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    FOREIGN KEY (doctor_id) REFERENCES Doctors(id)
);

CREATE TABLE Appointments (
    id SERIAL PRIMARY KEY,
    slot_id INT NOT NULL,
    patient_id INT NOT NULL,
    status_id INT NOT NULL,
    FOREIGN KEY (slot_id) REFERENCES AppointmentSlots(id),
    FOREIGN KEY (patient_id) REFERENCES Patients(id)
);

COMMIT;