# Docker Deployment Instructions

This project has been containerized using Docker. It includes the API, User Interface, and a SQL Server database.

## Prerequisites

- Docker Desktop installed and running.

## Services

- **portfolio.db**: SQL Server 2022 instance.
- **portfolio.api**: The Backend API (Port 5001).
- **portfolio.ui**: The Frontend UI (Port 5000).

## How to Run

1. Open a terminal in the project root.
2. Run the following command to build and start the containers:

```bash
docker-compose up --build
```

3. Access the services:
   - UI: [http://localhost:5000](http://localhost:5000)
   - API: [http://localhost:5001/swagger](http://localhost:5001/swagger) (if Swagger is enabled)

## Important Notes

- **Database**: The `docker-compose.yml` spins up a fresh SQL Server container. It will be empty initially. You may need to run Entity Framework migrations to create the schema.
- **Migrations**: Since the database is empty, you can run migrations from your local machine targeting the Docker database (if port 1433 is accessible), or run them inside the container.
  
  To run migrations from the container, you might need to add a script or run:
  
  ```bash
  docker exec -it <container_id_of_ui> dotnet ef database update
  ```
  (This assumes `dotnet ef` tool is installed in the container, which it isn't by default in the runtime image. A DevOps best practice is to include an entrypoint script to run migrations on startup).

- **Configuration**: The Connection Strings are injected via Environment Variables in `docker-compose.yml`.
