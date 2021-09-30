#!/bin/bash

until dotnet ef database update; do
>&2 echo "Postgre SQL Server is starting up"
sleep 1
done


