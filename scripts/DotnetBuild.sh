#!/bin/sh
echo "Stating pipeline"
echo "Running Restore"
dotnet restore 
echo "Running Build"
dotnet build
echo "Running Test"
dotnet test --no-build --verbosity normal