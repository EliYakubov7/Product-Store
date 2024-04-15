# Backend - ProductStoreAPI

## Before first startup

1. Install dotnet entity framework core installed globally:
`dotnet tool install --global dotnet-ef`

2. Install MySql (`https://dev.mysql.com/downloads/installer/`) locally running, and database `productStoreDB` created;

3. Go to `appsettings.Development.json` file inside `ProductStoreAPI.Host` folder and put your Password of MySql instead `admin`.

4. Run `dotnet ef database update` or `dotnet ef database update --project (Path of ProductStoreAPI.Host folder)` to update database with data;

5. Should launch app with `IIS Express` or `Apache HTTP Server` (It is not mandatory).

6. To open project folders, just double click on the `ProductStoreAPI.sln`.

7. Run the project.





# Frontend - ProductStoreUI

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.3.3. Make sure all the versioning is the same.

Angular CLI: 17.3.3
Node: 18.20.1
Package Manager: npm 10.5.1

Angular: 17.3.3
... animations, cdk, cli, common, compiler, compiler-cli, core
... forms, platform-browser, platform-browser-dynamic, router

Package                         Version
---------------------------------------------------------
@angular-devkit/architect       0.1703.3
@angular-devkit/build-angular   17.3.3
@angular-devkit/core            17.3.3
@angular-devkit/schematics      17.3.3
@schematics/angular             17.3.3
rxjs                            7.8.1
typescript                      5.4.4
zone.js                         0.14.4

## Development server

1. Before first run, don't forget to run `npm install`

2. Run `npm start` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Further help

1. Make sure the port of the following files: `dev.ts`, `local.ts` and `prod.ts` is the same as the port of the API Server.

2. Login with SiteAdministrator: `Email: admin@admin.com` and `Password: admin` (Register is for client only).





# Screenshots

## Login & Register Screen

<img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/login.png" height="350" width="600"> <img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/register.png" height="350" width="600">

## Home Screen

<img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/home.jpeg" height="350" width="600"> <img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/filter.jpeg" height="350" width="600">

## Users Screen & SignalIR 

<img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/users.jpeg" height="350" width="600"> <img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/edit_user_and_signalir.jpeg" height="350" width="600">

## Products Screen  & SignalIR

<img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/new_product.jpeg" height="350" width="600"> <img src="https://github.com/EliYakubov7/ProductStore/blob/main/Screenshots/edit_product_and_signalir.jpeg" height="350" width="600">

## Author

* **Eliyahu Yakubov** - *Initial work* - [Github](https://github.com/EliYakubov7), [Linkedin](https://www.linkedin.com/in/eli-yakubov-961908173)
