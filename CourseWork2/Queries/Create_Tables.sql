CREATE DATABASE IF NOT EXISTS courseworkdb;
USE courseworkdb;

CREATE TABLE IF NOT EXISTS departments
(
    name    VARCHAR(30)  NOT NULL UNIQUE,
    address VARCHAR(100) NULL,
    phone   VARCHAR(20)  NULL,
    id      INT          NOT NULL PRIMARY KEY AUTO_INCREMENT
);

CREATE TABLE IF NOT EXISTS workers
(
    surname               VARCHAR(30) NOT NULL,
    name                  VARCHAR(30) NOT NULL,
    patronymic            VARCHAR(30) NULL,
    gender                VARCHAR(6)  NOT NULL CHECK (gender IN ('Male', 'Female')),
    status                VARCHAR(8)  NOT NULL CHECK (status IN ('Accepted', 'Fired', 'Retired')),
    military_registration BOOLEAN      NOT NULL,
    department_id         INT         NOT NULL,
    id                    INT         NOT NULL PRIMARY KEY AUTO_INCREMENT,
    FOREIGN KEY (department_id) REFERENCES departments (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS positions
(
    name   VARCHAR(100)   NOT NULL UNIQUE,
    salary DECIMAL(12, 2) NOT NULL,
    id     INT            NOT NULL PRIMARY KEY AUTO_INCREMENT
);

CREATE TABLE IF NOT EXISTS accepted_workers
(
    worker_id     INT            NOT NULL UNIQUE,
    accept_date   DATE           NOT NULL,
    position_id   INT            NOT NULL,
    actual_salary DECIMAL(12, 2) NOT NULL,
    id            INT            NOT NULL PRIMARY KEY AUTO_INCREMENT,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE CASCADE,
    FOREIGN KEY (position_id) REFERENCES positions (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS fired_workers
(
    worker_id   INT  NOT NULL UNIQUE,
    fire_date   DATE NOT NULL,
    fire_reason TEXT NULL,
    id          INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS retired_workers
(
    worker_id   INT            NOT NULL UNIQUE,
    retire_date DATE           NOT NULL,
    pension     DECIMAL(12, 2) NOT NULL,
    id          INT            NOT NULL PRIMARY KEY AUTO_INCREMENT,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS users
(
    username VARCHAR(100) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL,
    email    VARCHAR(100) NOT NULL,
    role     VARCHAR(20)  NOT NULL,
    id       INT          NOT NULL PRIMARY KEY AUTO_INCREMENT
);