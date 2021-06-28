# Diffing app
## .net core API with Vue.JS UI

This application runs with .Net 5.0 and Vue.JS 3. 
Application offers: Api with 4 endpoints | User interface 

Application receives two base64 encoded strings, performs a diffing operation between them and returns objects with calculation. 

## Requirements
- .NET 5.0 SDK or Later(Software Development Kit)
- Node.js JavaScript runtime 
- Vue CLI (npm install -g @vue/cli)



## Endpoints

- https://localhost:5001/v1/diff --> Returns list of Json objects (All data in database)
- https://localhost:5001/v1/diff/{id} --> Returns Json object with a result type and list of diffs
- https://localhost:5001/v1/diff/{id}/left --> accepts JSON object containing base64 encoded binary data
- https://localhost:5001/v1/diff/{id}/right --> accepts JSON object containing base64 encoded binary data

## Usage

BACKEND:
...\diffs-master
- dotnet build:  Builds project and all of its dependencies.
- dotnet run:  Runs source code without any explicit compile or launch commands.
- dotnet test: Used to execute unit tests.

FRONTEND:
Move to folder ...\diffs-master\ui
- npm install: to install dependencies
- npm run serve: to start app

