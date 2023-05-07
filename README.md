# Calculator
Simple probability calculator.  React front end with .NET 7 API backend.

## Requirements
[.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
[Node.js](https://nodejs.org/en)


## Backend API
```
dotnet build
dotnet run --project Calculator.Api
```
[Swagger](https://localhost:5001/swagger/index.html)
Runs on port 5000 (https: 5001).  

## Frontend
```
cd Calculator.UI
npm install
npm run build
npm run preview
```
Runs on port [3000](http://localhost:3000/)
Default log file output location: `Calculator.Api\calculator.log`