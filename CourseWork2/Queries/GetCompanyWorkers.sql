USE courseworkdb;

SELECT companies.name, departments.name, workers.name, workers.status
FROM companies, departments, workers
WHERE companies.id = departments.company_id
AND departments.id = workers.department_id;