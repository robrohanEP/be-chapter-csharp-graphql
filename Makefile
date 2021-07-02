
PROJECT=dnet
BIN?=bin/Release/net5.0/linux-x64/$(PROJECT)

usage:
	@echo "Hello!"

prep:
#	dotnet new sln
#	dotnet new console
	dotnet new web -n dnet
#	dotnet new graphql
	dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
# Need this for EF and migrations stuff
	dotnet new tool-manifest
	dotnet tool install dotnet-ef

pre-install:

install:
# dotnet add ./dnet package HotChocolate.AspNetCore
# Install all  libraries
	dotnet restore --force-evaluate

start:
	dotnet run --project $(PROJECT)

run:
# runs a build binary made with run
	$(BIN)

build:
	dotnet publish ./ \
		--configuration Release \
		--output ./bin \
		--self-contained false \
		--runtime linux-x64 \
		--framework net5.0
#		--verbosity quiet \

clean:
	rm -rf bin
	rm -rf obj
	rm -rf dnet/bin
	rm -rf dnet/obj

migration_init:
	cd dnet; dotnet ef migrations add InitialCreate
# Example to add another one:
# dotnet ef migrations add ...
# dotnet ef migrations remove ...
# dotnet ef database update