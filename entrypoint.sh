#!/bin/bash

set -e
run_cmd="dotnet run -p /app/Bread.WebApi --launch-profile Bread-Docker"

until dotnet-ef -s /app/Bread.WebApi -p /app/Bread.Data -v --environment Docker database update; do
>&2 echo "SQL Server is starting up lol"
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd