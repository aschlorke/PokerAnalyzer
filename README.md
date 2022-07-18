# PokerAnalyzer

This is a basic application that uses an Angular client and a .NET API server to deal poker hands and determine the winner for each round. It is a sample application created in order to show integration between Angular and a .NET API. The client uses ngrx to manage the state of the application in order to allow components to easily get the data that they need. It also allows users to retrieve and view existing games, delete existing games, and change the number of players that take part in future games. The server handles creation of the poker games and determining the winner of each game. Players names are static and assigned in the same order every time. Games are stored in memory for this sample application, and will not persist after stopping the API. 

---
## Installation
---

The PokerAnalyzer code can be cloned using the following command:

```
git clone git@github.com:aschlorke/PokerAnalyzer.git
```

You can also download the source code directly [here](https://github.com/aschlorke/PokerAnalyzer/archive/refs/heads/master.zip).


To use the PokerAnalyzer application, you must install the following versions of these tools:
- [Node.js](https://nodejs.org/en/) v18.6.0
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) v6.0 

Links for downloading the specific versions of these tools required for Windows are provided below in the [Required Tool Direct Downloads](#required-tool-direct-downloads) section. 

After installing the tools, install the latest version of the angular CLI by running the following command: 

```
npm install -g @angular/cli@latest
```
---
## Running the Application
---
### Client

Using a terminal, navigate to the client/poker-analyzer directory, and install the required node modules using the following command:

```
npm install
```

Afterwards, run the following to serve the website on your local machine:

```
ng serve
```

The client should start and be accessible at http://localhost:4200.

### Server
Using a terminal, navigate to the server directory, and run the following commands:

```
dotnet restore
dotnet build
```

Navigate to the PokerAnalyzer.API directory and run the API using the following command:

```
dotnet run
```

This will start the API, which can be accessed at https://localhost:7245. Documentation for the API can be accessed at https://localhost:7245/swagger/index.html.

---
## Using the Application
---
After starting both the client and server applications, open a browser and navigate to http://localhost:4200. A header should be displayed with a button to start a new game in the upper left corner, and selects to choose existing games to view and change the number of players that will be a part of subsequent games. After starting several new games, the existing game selection dropdown will be populated with the ids of the available games. Selecting one of those ids will fetch the game from the server and display it again. Anytime a game is being shown, the winner and their winning hand will display beneath the dealt hands. The selected game can also be deleted by pressing the delete button at the bottom left of the screen. This button only shows when a game is selected.

---
## Packages and Modules
---
### Client
The client uses a few node modules provided by angular, as well as modules for using ngrx for state management. These are all installed by running the `npm install` command from the client/poker-analyzer directory.

### Server
The server only uses the NewtonSoft.Json nuget package. This will be installed when running the `dotnet restore` command from the server directory.

---
## Required Tool Direct Downloads
---
Here are the direct download links for specific platforms for the tools mentioned in the [Installation](#installation) section
### Windows
- [Node.js](https://nodejs.org/dist/v18.6.0/node-v18.6.0-x64.msi)
- [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.302-windows-x64-installer)

---
## TODO
---
The application has the following issues due to time constraints:
- UI Design is not very intuitive
- Errors on the UI and in communicating with the server are logged in the client's console, but not shown anywhere in the UI.
- At minimum, unit tests for determining the Poker Game winner should be written to ensure that all edge cases are covered.
