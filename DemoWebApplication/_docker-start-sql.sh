#!/bin/sh

## Manually start "ms-sql" container

## - TODO DB password is plain text -> replace by something else (key-fault)
## - uses a docker-volume for persistence (`-v mssql-demo`)
docker run \
  -e 'ACCEPT_EULA=Y' \
  -e 'SA_PASSWORD=Str0ngPa$$w0rd' \
  -p 1433:1433 \
  -v mssql-demo:/var/opt/mssql \
  -d mcr.microsoft.com/mssql/server:2019-latest
