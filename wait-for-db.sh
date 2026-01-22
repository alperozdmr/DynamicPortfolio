#!/bin/sh
# wait-for-db.sh

echo "Waiting for SQL Server to be available..."

# Loop until we can connect to the database
counter=0
while [ $counter -lt 60 ]; do
    /opt/mssql-tools18/bin/sqlcmd -S db -U sa -P "Password123!" -C -Q "SELECT 1" > /dev/null 2>&1
    if [ $? -eq 0 ]; then
        echo "SQL Server is ready."
        break
    else
        echo "Not ready yet..."
        sleep 5
        counter=$((counter+1))
    fi
done

if [ $counter -eq 60 ]; then
    echo "Timeout waiting for SQL Server."
    exit 1
fi

echo "Running initialization script..."
/opt/mssql-tools18/bin/sqlcmd -S db -U sa -P "Password123!" -C -i /var/opt/mssql/backup/restore-db.sql
