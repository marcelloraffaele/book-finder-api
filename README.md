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
```
curl -X POST "http://localhost:5097/Books" -H "Content-Type: application/json" -d '{ "id": 1, "title": "Sample Book Title", "author": "Sample Author", "isbn": "123-4567890123", "publisher": "Sample Publisher", "publishedDate": "2025-02-24T00:00:00", "genre": "Sample Genre", "pageCount": 300, "language": "English", "description": "Sample book description." }'

curl -X get "http://localhost:5097/Books" -H "Content-Type: application/json"

curl -x GET http://localhost:5097/swagger/v1/swagger.json
```

## test with Powershell Invoke-RestMethod
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

## other prompt:
- Prompt 1
```
Develop the following points:
1. Update the API adding book changes, book delete and get book by IBAN.
2. Update all the test and exec the test. If any test fail, fix it and run again the test.
3. Create a file `client.http` containing a list of `curl` that can be used in order to test all the created API.
```
- Prompt 2
```
Create a file `test.ps1` containing a powershell script that can be used in order to test all the created API.
```
- Prompt 3

```
create a github actions to build this project and run test
create a github codespace file for this project
```

