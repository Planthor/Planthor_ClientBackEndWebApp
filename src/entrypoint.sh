#!/bin/bash

set -e
run_cmd="dotnet PlanthorWebApiServer.dll --server.urls https://+:5000"

until dotnet ef database update; do
>&2 echo "Postgre SQL Server is starting up"
sleep 1
done
# >&2 ls
>&2 echo "Postgre SQL Server is up - executing command"
exec $run_cmd

