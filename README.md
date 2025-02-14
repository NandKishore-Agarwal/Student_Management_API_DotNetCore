Created StudentRepository and IStudentRepository interface.
Created StudentService and IStudentService interface.

Injected as Singleton. (Used Dependency Injection)
Added Cache decorator on top of the Service, using in-memory cache for performance optimization.

Added Logging as Decorator for monitory api's request.

Added GET endpoints:
Get Student by Id: Accept Student ID and return student details.

Get average grade by Department Id: Accept Department ID and return the average grade.

Get student count per department: Return all departments and their student count.

Get all departments: Return all departments for data population.

Get all students by department. 
