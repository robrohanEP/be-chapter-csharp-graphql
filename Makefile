PROJECT=example
# osx.10.11-x64
RUNTIME=linux-x64
FRAMEWORK=net5.0
CONFIG=Release
BIN?=bin/$(CONFIG)/$(FRAMEWORK)/$(RUNTIME)/$(PROJECT)

usage:
	@echo "Hello! Cat the Makefile."

# prep:
# #	dotnet new sln
# #	dotnet new console
# 	dotnet new web -n dnet
# #	dotnet new graphql
# 	dotnet nuget add source --name nuget.org https://api.nuget.org/v3/index.json
# # Need this for EF and migrations stuff
# 	dotnet new tool-manifest
# 	dotnet tool install dotnet-ef

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
		--configuration $(CONFIG) \
		--output ./bin \
		--self-contained true \
		--runtime $(RUNTIME) \
		--framework $(FRAMEWORK)
#		--verbosity quiet \

clean:
	rm -rf bin
	rm -rf obj
	rm -rf $(PROJECT)/bin
	rm -rf $(PROJECT)/obj

migration_init:
	cd dnet; dotnet ef migrations add InitialCreate
# Example to add another one:
# dotnet ef migrations add ...
# dotnet ef migrations remove ...
# dotnet ef database update