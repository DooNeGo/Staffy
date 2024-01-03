USE courseworkdb;

DROP USER 'user'@'localhost';
DROP USER 'admin'@'localhost';

CREATE USER IF NOT EXISTS 'user'@'localhost' IDENTIFIED BY '1111';
GRANT SELECT, INSERT, UPDATE, DELETE ON courseworkdb.departments TO 'user'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON courseworkdb.workers TO 'user'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON courseworkdb.positions TO 'user'@'localhost';
GRANT SELECT ON courseworkdb.accepted_workers TO 'user'@'localhost';
GRANT SELECT ON courseworkdb.fired_workers TO 'user'@'localhost';
GRANT SELECT ON courseworkdb.retired_workers TO 'user'@'localhost';
GRANT SELECT ON courseworkdb.users TO 'user'@'localhost';

CREATE USER IF NOT EXISTS 'admin'@'localhost' IDENTIFIED BY '2222';
GRANT ALL PRIVILEGES ON courseworkdb.* TO 'admin'@'localhost';

FLUSH PRIVILEGES;