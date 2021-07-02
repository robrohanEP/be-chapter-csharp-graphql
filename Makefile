
BIN?=bin/Release/net5.0/linux-x64/dnet

prep:
#	dotnet new sln
#	dotnet new console
	dotnet new web -n dnet

pre-install:
	dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json

install:
#	dotnet add package Newtonsoft.Json
# dotnet add ./dnet package HotChocolate.AspNetCore
#	dotnet new graphql
	dotnet restore --force-evaluate

start:
	dotnet run --project dnet
# $(BIN)

build:
	dotnet publish ./ \
		--configuration Release \
		--output ./bin \
		--self-contained false \
		--runtime linux-x64 \
		--verbosity quiet \
		--framework net5.0

clean:
	rm -rf bin
	rm -rf obj