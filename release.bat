@echo off
dotnet build src/Skybrud.Social.Meetup --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget