https://learn.microsoft.com/en-us/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api

dotnet new webapi -controllers -f net9.0


dotnet run


# test with httprepl

```
httprepl https://localhost:5000

connect http://localhost:5000 --openapi /swagger/v1/swagger.json

ls

cd Note

get
```



dotnet add package Swashbuckle.AspNetCore

```
https://localhost:5296/swagger/v1/swagger.json
```

