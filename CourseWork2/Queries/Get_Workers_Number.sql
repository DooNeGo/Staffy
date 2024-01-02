use courseworkdb;

SELECT COUNT(*) 
FROM accepted_workers as a, workers as w, departments as d
WHERE w.id = a.worker_id AND w.department_id = d.id