# Illarion Server

This is the Server for the online roleplaying game [Illarion](http://illarion.org). The server is based on the
[Photon OnPremise Server](https://www.photonengine.com/en-US/OnPremise).

## Objectives

Illarion is the online multiplayer roleplaying game that is developed and maintained by the Illarion e.V.

This repository contains the sources of the game server.

## Requirements

- [Photon OnPremise Server SDK](https://www.photonengine.com/en-US/sdks#onpremiseserver) >= v4.0.29.11263
- .NET Framework 4.7
- Microsoft Visual Studio 2017
- Microsoft Windows >= 7

## Build Instructions

The repository is set up to be developed and debugged with any version of Microsoft Visual Studio 2017. The build
currently required a environment variable named `PHOTON_SERVER_SDK` to be present on the system. This variable
has to point to the downloaded Photon OnPremise Server SDK directory that includes the `deploy/` and the `lib/`
directory.

Building the server and running the tests will work once the variable is present.

## Execution Instructions

To actually run the server it is required to create the database. Since the server is not actively in use right now,
there is no migration for the database set up. After building the server the package management console of Visual
Studio allows to execute the commands
```powershell
Add-Migration init
Update-Database
```
on the project *Persistence\Illarion.Server.Persistence*. Doing so will create the migration for the current state of
the database. Do **not** add this migration of the repository for now. The layout for the database is not even close
to be done.

The created Sqlite database should be created in the project *Illarion.Server.Photon*. Make sure to set it to be
copied during the build. After that is done you should be able to launch the server from Visual Studio.