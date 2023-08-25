@echo off
dotnet build src/Skybrud.Social.Meetup --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget