$ErrorActionPreference = "Stop"

Write-Host "Checking for database backup..." -ForegroundColor Cyan

$backupPath = ".\db_backup\PortfolioDb.bak"

if (-not (Test-Path $backupPath)) {
    Write-Host "ERROR: Database backup file NOT FOUND at: $backupPath" -ForegroundColor Red
    Write-Host "Please create a backup of your local database named 'PortfolioDb.bak' and place it in the 'db_backup' folder." -ForegroundColor Yellow
    exit 1
}

Write-Host "Backup found using it." -ForegroundColor Green

Write-Host "Starting Docker containers..." -ForegroundColor Cyan
docker-compose up -d --build

Write-Host "Waiting for SQL Server to warm up (15 seconds)..." -ForegroundColor Cyan
Start-Sleep -Seconds 15

Write-Host "Restoring Database..." -ForegroundColor Cyan
try {
    # Using mssql-tools18 path and -C for TrustServerCertificate
    docker exec -i portfolio_db /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P Password123! -C -i /var/opt/mssql/backup/restore-db.sql
    Write-Host "Database restored successfully!" -ForegroundColor Green
}
catch {
    Write-Host "Failed to restore database. Check logs above." -ForegroundColor Red
}

Write-Host "Showing logs from UI..." -ForegroundColor Cyan
docker-compose logs -f portfolio.ui
