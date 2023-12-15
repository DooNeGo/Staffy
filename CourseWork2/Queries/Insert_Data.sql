USE courseworkdb;

INSERT INTO companies (name, address, phone)
VALUES ('Microsoft', 'One Microsoft Way, Redmond, WA 98052, USA', '+1-425-882-8080'),
       ('Google', '1600 Amphitheatre Parkway, Mountain View, CA 94043, USA', '+1-650-253-0000'),
       ('Apple', 'One Apple Park Way, Cupertino, CA 95014, USA', '+1-408-996-1010'),
       ('Amazon', '410 Terry Avenue North, Seattle, WA 98109, USA', '+1-206-266-1000'),
       ('Facebook', '1 Hacker Way, Menlo Park, CA 94025, USA', '+1-650-543-4800');

INSERT INTO departments (name, address, phone, company_id)
VALUES ('Research and Development', 'Building 99, 14820 NE 36th Street, Redmond, WA 98052, USA', '+1-425-703-6214', 1),
       ('Marketing', 'Building 17, 16011 NE 36th Way, Redmond, WA 98052, USA', '+1-425-882-8080', 1),
       ('Engineering', '1600 Amphitheatre Parkway, Mountain View, CA 94043, USA', '+1-650-253-0000', 2),
       ('Sales', '345 Spear Street, San Francisco, CA 94105, USA', '+1-415-736-0000', 2),
       ('Design', 'One Apple Park Way, Cupertino, CA 95014, USA', '+1-408-996-1010', 3),
       ('Customer Service', '12545 Riata Vista Circle, Austin, TX 78727, USA', '+1-512-674-2000', 3),
       ('Operations', '410 Terry Avenue North, Seattle, WA 98109, USA', '+1-206-266-1000', 4),
       ('Finance', '2021 7th Avenue, Seattle, WA 98121, USA', '+1-206-266-1000', 4),
       ('Product', '1 Hacker Way, Menlo Park, CA 94025, USA', '+1-650-543-4800', 5),
       ('Legal', '1601 Willow Road, Menlo Park, CA 94025, USA', '+1-650-308-7300', 5);

INSERT INTO workers (surname, name, patronymic, gender, status, military_registration, department_id)
VALUES ('Smith', 'John', 'Michael', 'Male', 'Accepted', TRUE, 1),
       ('Johnson', 'Mary', 'Elizabeth', 'Female', 'Accepted', FALSE, 2),
       ('Lee', 'David', 'Chang', 'Male', 'Accepted', TRUE, 3),
       ('Chen', 'Lily', 'Mei', 'Female', 'Accepted', FALSE, 4),
       ('Garcia', 'Carlos', 'Jose', 'Male', 'Accepted', TRUE, 5),
       ('Rodriguez', 'Maria', 'Luisa', 'Female', 'Accepted', FALSE, 6),
       ('Patel', 'Raj', 'Kumar', 'Male', 'Accepted', TRUE, 7),
       ('Singh', 'Priya', 'Kaur', 'Female', 'Accepted', FALSE, 8),
       ('Miller', 'James', 'Robert', 'Male', 'Accepted', TRUE, 9),
       ('Williams', 'Emma', 'Grace', 'Female', 'Accepted', FALSE, 10),
       ('Brown', 'Daniel', 'Thomas', 'Male', 'Fired', TRUE, 1),
       ('Jones', 'Anna', 'Sophia', 'Female', 'Fired', FALSE, 2),
       ('Kim', 'Min', 'Ji', 'Female', 'Fired', FALSE, 3),
       ('Wang', 'Wei', 'Jun', 'Male', 'Fired', TRUE, 4),
       ('Lopez', 'Pedro', 'Miguel', 'Male', 'Fired', TRUE, 5),
       ('Gonzalez', 'Sofia', 'Isabel', 'Female', 'Fired', FALSE, 6),
       ('Shah', 'Vikas', 'Anil', 'Male', 'Fired', TRUE, 7),
       ('Khan', 'Zara', 'Fatima', 'Female', 'Fired', FALSE, 8),
       ('Davis', 'William', 'Henry', 'Male', 'Fired', TRUE, 9),
       ('Taylor', 'Emily', 'Rose', 'Female', 'Fired', FALSE, 10),
       ('Wilson', 'Jack', 'Edward', 'Male', 'Retired', TRUE, 1),
       ('Clark', 'Olivia', 'Evelyn', 'Female', 'Retired', FALSE, 2),
       ('Park', 'Jin', 'Woo', 'Male', 'Retired', TRUE, 3),
       ('Li', 'Xiao', 'Yan', 'Female', 'Retired', FALSE, 4),
       ('Martinez', 'Juan', 'Carlos', 'Male', 'Retired', TRUE, 5);

INSERT INTO positions (position, salary)
VALUES ('Software Engineer', 100000.00),
       ('Marketing Manager', 80000.00),
       ('Web Developer', 60000.00),
       ('Sales Representative', 50000.00),
       ('Graphic Designer', 40000.00),
       ('Customer Service Agent', 30000.00),
       ('Operations Manager', 90000.00),
       ('Financial Analyst', 70000.00),
       ('Product Manager', 120000.00),
       ('Lawyer', 150000.00);

INSERT INTO accepted_workers (worker_id, accept_date, position_id, actual_salary)
VALUES (1, '2023-01-01', 1, 105000.00),
       (2, '2023-01-02', 2, 85000.00),
       (3, '2023-01-03', 3, 65000.00),
       (4, '2023-01-04', 4, 55000.00),
       (5, '2023-01-05', 5, 45000.00),
       (6, '2023-01-06', 6, 35000.00),
       (7, '2023-01-07', 7, 95000.00),
       (8, '2023-01-08', 8, 75000.00),
       (9, '2023-01-09', 9, 125000.00),
       (10, '2023-01-10', 10, 155000.00);

INSERT INTO fired_workers (worker_id, fire_date, fire_reason)
VALUES (11, '2023-03-01', 'Poor performance'),
       (12, '2023-03-02', 'Violation of company policy'),
       (13, '2023-03-03', 'Lack of skills'),
       (14, '2023-03-04', 'Redundancy'),
       (15, '2023-03-05', 'Misconduct'),
       (16, '2023-03-06', 'Harassment'),
       (17, '2023-03-07', 'Fraud'),
       (18, '2023-03-08', 'Theft'),
       (19, '2023-03-09', 'Insubordination'),
       (20, '2023-03-10', 'Conflict of interest');

INSERT INTO retired_workers (worker_id, retire_date, pension)
VALUES (21, '2023-02-01', 50000.00),
       (22, '2023-02-02', 40000.00),
       (23, '2023-02-03', 30000.00),
       (24, '2023-02-04', 20000.00),
       (25, '2023-02-05', 10000.00);
