# Instructions to start
 - Setup connection strings in AppSettings.json/AppSettings.development.json in projects ProductMicroService/OrderMicroService
 - Install nuget packages
 - Launch this commands inside the folder of the projects ProductMicroService/OrderMicroService : <br>
    a. dotnet ef migrations add Initial <br>
    b. dotnet ef database update Initial <br>
 - Set your solution as a multiple startup project in solution properties <br> <br>
   ![image](https://github.com/giaco99/OrderManagementDemo/assets/62729639/c6f509ff-eb61-4d71-890b-aa5f41a8b0d7)

# Instructions to test GatewayApi
 - The GatewayApi manages the "GetById" calls of both the microservices so before test it you must : <br>
    a. add one productCategory and after one product from ProductMicroServiceApi's swagger interface <br>
    b. add one order OrderMicroServiceApi's swagger interface <br>
    c. this is the GWApi baseUrl : https://localhost:7011 <br>
    d. this is the url to try the call to the "getById" method of productMicroService.Api --> https://localhost:7011/api/product/{idProductToSee} <br>
    e. this is the url to try the call to the "getById" method of orderMicroService.Api --> https://localhost:7011/api/order/{idOrderToSee} <br>

