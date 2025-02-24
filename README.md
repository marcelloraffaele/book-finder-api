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
curl -X POST "http://localhost:5097/Books" -H "Content-Type: application/json" -d '{
  "id": 1,
  "title": "Sample Book Title",
  "author": "Sample Author",
  "isbn": "123-4567890123",
  "publisher": "Sample Publisher",
  "publishedDate": "2025-02-24T00:00:00",
  "genre": "Sample Genre",
  "pageCount": 300,
  "language": "English",
  "description": "Sample book description."
}'

###
curl -X get "http://localhost:5097/Books" 
  -H "Content-Type: application/json"
  
###
curl -x GET http://localhost:5097/swagger/v1/swagger.json
```

