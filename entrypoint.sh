#!/bin/bash
set -e
run_cmd="dotnet run -p /app/Bread.WebApi --launch-profile Bread-Docker"
until dotnet ef -s /app/Bread.WebApi -p /app/Bread.Data -v database update; do
>&2 echo "SQL Server is starting up..."
sleep 1
done
>&2 echo "SQL Server is up!"
>&2 echo "Starting WebApi..."
exec $run_cmd