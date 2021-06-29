# README

## Goal

I'd like to have a script, which 

- starts the web-app in a docker container
- and also uses a docker container which runs ms-sql; including setup for docker volume to persist the data.

Probably something using docker-compose.

Primary host os: linux.

## Notes

I'll try to setup everything manually from the command line, so I won't be using any fancy features from Rider, Visual Studio, or VS Code.

Once I understand how everything works I might look into IDE tooling support (but don't hold your breath).

## Initial setup

- I started with a default Web API template using dotnet5.
- Added a Dockerfile, and 2 scripts: 1 to build the image, the other to start a container.
