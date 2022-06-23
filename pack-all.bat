:: ad-hoc script for packing all packages
:: designed to produce local-only pre-release versions for testing

@echo off
set outputdir=bin\output

:: clean output directories
if exist %outputdir% rmdir /s /q %outputdir%
mkdir %outputdir%

:: restore dependencies
dotnet restore
echo(

:: pack each project
dotnet pack TehGM.Utilities.Time -c Debug -o %outputdir% --no-restore
echo(
dotnet pack TehGM.Utilities.Time.JsonNet -c Debug -o %outputdir% --no-restore
echo(
dotnet pack TehGM.Utilities.Validation -c Debug -o %outputdir% --no-restore
echo(
dotnet pack TehGM.Utilities.UniqueIDs -c Debug -o %outputdir% --no-restore
echo(
dotnet pack TehGM.Utilities.Randomization -c Debug -o %outputdir% --no-restore
echo(
dotnet pack TehGM.Utilities.Logging -c Debug -o %outputdir% --no-restore
echo(

:: pack metapackage
nuget pack "TehGM.Utilities\TehGM.Utilities.nuspec" -Exclude "*.*" -BasePath "TehGM.Utilities" -NonInteractive -OutputDirectory %outputdir%