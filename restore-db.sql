USE master;
GO

-- Wait for SQL Server to be ready (usually handled by the script running this, but good practice to be safe)

-- Check if database already exists
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PortfoliDb')
BEGIN
    PRINT 'Restoring database...'
    
    -- Restore from the backup file
    RESTORE DATABASE [PortfoliDb] 
    FROM DISK = '/var/opt/mssql/backup/PortfolioDb.bak' WITH FILE = 1,
    MOVE 'PortfoliDb' TO '/var/opt/mssql/data/PortfoliDb.mdf',
    MOVE 'PortfoliDb_log' TO '/var/opt/mssql/data/PortfoliDb_log.ldf',
    NOUNLOAD, REPLACE, STATS = 5;
END
ELSE
BEGIN
    PRINT 'Database already exists. Skipping restore.'
END
GO
