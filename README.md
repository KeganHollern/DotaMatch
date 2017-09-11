# DotaMatch - .NET Dota 2 Lobby Controller
---
[![forthebadge](http://forthebadge.com/images/badges/made-with-c-sharp.svg)](http://forthebadge.com)
#####  DotaMatch is a .NET library that makes creating and managing dota 2 private lobbies easy. It works with [SteamKit](http://github.com/SteamRE/SteamKit) and Paralin's [Dota2](https://github.com/paralin/Dota2/) Library. 
#
#
## Binaries
---
[![forthebadge](http://forthebadge.com/images/badges/fuck-it-ship-it.svg)](http://forthebadge.com)
##### Available on NuGet [Here](https://www.nuget.org/packages/DotaMatch/1.0.0)
All dependencies will be installed automatically through nuget.

Installing through NuGet Package Manager and .NET CLI
```pm
PM> Install-Package DotaMatch -Version 1.0.0
```
```
> dotnet add package DotaMatch --version 1.0.0
```
#

## Documentation
---
[![forthebadge](http://forthebadge.com/images/badges/built-by-developers.svg)](http://forthebadge.com)
#### Before you start
You will need:
  - Steam Account with SteamGuard OFF
  - Steam API Key (get one [here](https://steamcommunity.com/dev/apikey))


#### Code
1. Initialize the `DotaClient` Class
```csharp
DotaClient client = DotaClient.Create("<SteamAccountUsername>",
                "<SteamAccountPassword>", 
                "<SteamAPIKey>", 
                new DotaClientParams());;
```
2. Connect to the GameCoordinator
```csharp
client.Connect();
```
3. Create a lobby & run the match
```csharp
client.CreateLobby("<LobbyName>",
    "<LobbyPassword>", 
    new DotaLobbyParams(
        new ulong[] { /* List of RADIANT team SteamID64s */  }, 
        new ulong[] { /* List of DIRE team SteamID64s */ }
    ));
```
4. Getting a match result
```csharp
//Add event handler for OnGameFinished
client.OnGameFinished += Client_OnGameFinished;
```
```csharp
private void Client_OnGameFinished(DotaGameResult Outcome) {
    if(Outcome == DotaGameResult.Radiant) {
        //Radiant Win
    } else if(Outcome == DotaGameResult.Dire) {
        // Dire Win
    } else {
        // Error Occured
    }
}
```
5. Reset the bot so a new lobby can be made.
```csharp
client.Reset();
```
#
## License
---
[![forthebadge](http://forthebadge.com/images/badges/contains-technical-debt.svg)](http://forthebadge.com)
##### Just like SteamKit and Dota2, DotaMatch is licensed under [LGPL](https://tldrlegal.com/license/gnu-lesser-general-public-license-v2.1-%28lgpl-2.1%29).