# paySimplex backend test

This project is a API for a task manager service, which allows you to get, create, update and delete tasks and users. For a job selection process @paySimplex

## How to run

run the following:

1. ```git clone https://github.com/get-Friday/paySimplex-backend-test```
2. ```cd paySimplex-backend-test```
3. ```dotnet ef database update --project .\paySimplex.Infra\ --startup-project .\paySimplex.API\```
4. ```dotnet run --project .\paySimplex.API\```

Then open the project at [localhost](https://localhost:7021/swagger/index.html)

## Features

- DDD architecture
- Dependency injection
- Error middleware for exception treatment
- Data Annotations
- EF Code First
- Swagger
- SOLID

## Endpoints

### CHORE ENDPOINT
- GET api/Chore
- POST api/Chore
- GET api/Chore/{id}
- PUT api/Chore/{id}
- DELETE api/Chore/{id}
- GET api/Chore/user/{id}
   - Get tasks by user id
- PATCH api/Chore/{id}/status/{status}
  - Update task status using its enum (0, 1 and 2)
- GET api/Chore/{id}/duration
  - Get task time span between start date and end date

### USER ENDPOINT
- GET api/User
- POST api/User
- GET api/User/{id}
- PUT api/User/{id}
- DELETE api/User/{id}
