#!/bin/bash

## Setup database using entity-framework-core's migration features.
## Requires `ef-core` installed globally using dotnet.

if [ -z "$1" ]; then
    echo "Please add a migration name..."
    exit 1
fi

migrationName=$1

dotnet ef database update
dotnet ef migrations add "$migrationName"
dotnet ef database update