# CodedSummer2022_LCNC_T6_BackendAPI

This is a backend for coded summer of itworx using ASP.net core 6 wep api and using code first approach

the structure of the code is:

-  itworx-Backend is the main folder that will run the program and hold controllers that will preform routes.
    -- controller files which contain the routes.
    -- wwwroot contain all the static files and images we can use
    -- program file is the startup file which connect it with the database,connect services with itworx-Backend,etc
-  itworx-Backend.Domain is the folder that contain all the database classes and models.
    -- entities folder is the main folder of this folder which contains the class models.
    -- mapping folder is the folder which contains the mapping between all classes.
-  itworx-Backend.Repository is the folder that contain database context and migration files.
    -- applicationDbcontext is the file which we use twhen doing migration
    -- Repository folder contain all the functions of database.
    -- migrations folder is the folder contain all the migrations done.
-  itworx-Backend.service is the folder that hold all the business logic of the entity.

## 💻 Built Using <a name = "tech"></a>

- [ASP.NET]()

## how to start

If you want to start the app, you have to press F5 in vitual studio.

don't forget to put your connection string in appsettings.json in main folder in conn.
don't forget to do migration so the database have all classes
```
  add-migration "migration name"
  update-database
```

