# **Staffy**
This is an application written for a 2nd year coursework. It uses the WPF framework, the MVVM pattern, and a MySQL database designed for the application

:x:**Not implemented:**
1. Add page
2. Edit page
3. Dashboard
4. Settings

## Login page
![](https://github.com/DooNeGo/Staffy/blob/master/AppImages/LoginView.png)

## Main page
![](https://github.com/DooNeGo/Staffy/blob/master/AppImages/MainView.png)

## The code of the designed database
```SQL
CREATE TABLE departments
(
    id      INT          NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name    VARCHAR(30)  NOT NULL UNIQUE,
    address VARCHAR(100) NULL,
    phone   VARCHAR(13)  NULL
);

CREATE TABLE workers
(
    id                    INT         NOT NULL PRIMARY KEY AUTO_INCREMENT,
    surname               VARCHAR(30) NOT NULL,
    name                  VARCHAR(30) NOT NULL,
    patronymic            VARCHAR(30) NULL,
    gender                VARCHAR(6)  NOT NULL CHECK (gender IN ('Male', 'Female')),
    status                VARCHAR(7)  NOT NULL CHECK (status IN ('Hired', 'Fired', 'Retired')),
    military_registration BOOLEAN     NOT NULL,
    department_id         INT         NOT NULL,
    FOREIGN KEY (department_id) REFERENCES departments (id) ON DELETE NO ACTION
);

CREATE TABLE positions
(
    id            INT            NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name          VARCHAR(100)   NOT NULL UNIQUE,
    salary        DECIMAL(12, 2) NOT NULL,
    department_id INT            NOT NULL,
    FOREIGN KEY (department_id) REFERENCES departments (id) ON DELETE NO ACTION
);

CREATE TABLE accepted_workers
(
    id            INT            NOT NULL PRIMARY KEY AUTO_INCREMENT,
    worker_id     INT            NOT NULL,
    accept_date   DATE           NOT NULL,
    position_id   INT            NOT NULL,
    actual_salary DECIMAL(12, 2) NOT NULL,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE NO ACTION,
    FOREIGN KEY (position_id) REFERENCES positions (id) ON DELETE NO ACTION
);

CREATE TABLE fired_workers
(
    id          INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    worker_id   INT  NOT NULL,
    fire_date   DATE NOT NULL,
    fire_reason TEXT NULL,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE NO ACTION
);

CREATE TABLE retired_workers
(
    id          INT            NOT NULL PRIMARY KEY AUTO_INCREMENT,
    worker_id   INT            NOT NULL,
    retire_date DATE           NOT NULL,
    pension     DECIMAL(12, 2) NOT NULL,
    FOREIGN KEY (worker_id) REFERENCES workers (id) ON DELETE NO ACTION
);
```
