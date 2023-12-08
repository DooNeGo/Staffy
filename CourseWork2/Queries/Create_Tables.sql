CREATE DATABASE IF NOT EXISTS Courseworkdb;
USE Courseworkdb;

CREATE TABLE IF NOT EXISTS Companies
(
    Id      INT          NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name    VARCHAR(30)  NOT NULL,
    Address VARCHAR(100) NULL,
    Phone   VARCHAR(20)  NULL
);

CREATE TABLE IF NOT EXISTS Departments
(
    Id        INT          NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name      VARCHAR(30)  NOT NULL,
    Address   VARCHAR(100) NULL,
    Phone     VARCHAR(20)  NULL,
    Companyid INT          NOT NULL,
    FOREIGN KEY (Companyid) REFERENCES Companies (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Workers
(
    Id                   INT         NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Surname              VARCHAR(30) NOT NULL,
    Name                 VARCHAR(30) NOT NULL,
    Patronymic           VARCHAR(30) NOT NULL,
    Gender               VARCHAR(6)  NOT NULL CHECK (Gender IN ('Male', 'Female')),
    Status               VARCHAR(8)  NOT NULL CHECK (Status IN ('Accepted', 'Fired', 'Retired')),
    Militaryregistration BIT         NOT NULL CHECK (Militaryregistration = 0 OR Militaryregistration = 1),
    Departmentid         INT         NOT NULL,
    FOREIGN KEY (Departmentid) REFERENCES Departments (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Acceptedworkers
(
    Workerid   INT            NOT NULL UNIQUE,
    Acceptdate DATE           NOT NULL,
    Position   VARCHAR(100)   NOT NULL,
    Salary     DECIMAL(20, 4) NOT NULL,
    FOREIGN KEY (Workerid) REFERENCES Workers (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Firedworkers
(
    Workerid   INT  NOT NULL UNIQUE,
    Firedate   DATE NOT NULL,
    Firereason TEXT NULL,
    FOREIGN KEY (Workerid) REFERENCES Workers (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Retiredworkers
(
    Workerid   INT            NOT NULL UNIQUE,
    Retiredate DATE           NOT NULL,
    Pension    DECIMAL(20, 4) NOT NULL,
    FOREIGN KEY (Workerid) REFERENCES Workers (Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Users
(
    Id       INT          NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Email    VARCHAR(100) NOT NULL,
    Role     VARCHAR(20)  NOT NULL
);