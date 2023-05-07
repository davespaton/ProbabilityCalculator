# Calculator
Simple probability calculator.

## Requirements
[.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
[Node.js](https://nodejs.org/en)


## Running the application

Backend API
```
dotnet build
dotnet run --project Calculator.Api
```
Runs on port 5000 (https: 5001), with swagger available at: https://localhost:5001/swagger/index.html

Frontend
```
cd Calculator.UI
npm install
npm run build
npm run preview
```
Runs on port 3000. http://localhost:3000/
Default file output location: `Calculator.Api\calculator.log`