USE courseworkdb;

SELECT departments.name, workers.name, workers.status
FROM departments,
     workers
WHERE departments.id = workers.department_id
  AND (workers.status = 'Retired' OR workers.status = 'Accepted');