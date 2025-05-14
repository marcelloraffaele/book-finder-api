# Book finder API

## How this project was created
https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api

```powershell
dotnet new webapi -controllers -f net9.0
dotnet run

# if needed to add packages
# dotnet add package Swashbuckle.AspNetCore
```

## test with httprepl

```
httprepl https://localhost:<port>

connect http://localhost:<port> --openapi /swagger/v1/swagger.json

ls

cd Books

get
```

## test with curl
```powershell
# POST a new book
$body = @{
    id = 1
    title = "Sample Book Title"
    author = "Sample Author"
    isbn = "123-4567890123"
    publisher = "Sample Publisher"
    publishedDate = "2025-02-24T00:00:00"
    genre = "Sample Genre"
    pageCount = 300
    language = "English"
    description = "Sample book description."
} | ConvertTo-Json
Invoke-RestMethod -Uri "http://localhost:5097/Books" -Method Post -ContentType "application/json" -Body $body

# GET all books
Invoke-RestMethod -Uri "http://localhost:5097/Books" -Method Get -ContentType "application/json" | ConvertTo-Json

# GET swagger JSON
Invoke-RestMethod -Uri "http://localhost:5097/swagger/v1/swagger.json" -Method Get | ConvertTo-Json
```

## Prompt used to create this code with GitHub Copilot
```
create the following apis: 
- search by title
- get all books
- get by id
- get by author

- add book.

Add a service class that must be testable by junit test. create also junit test
```

other prompt that can be used:
```
update the api adding book changes, book delete

/tests

create a github actions to build this project and run test

create a github codespace file for this project
```

