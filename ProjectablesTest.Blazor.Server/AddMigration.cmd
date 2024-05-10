REM dotnet tool update --global dotnet-ef

dotnet ef migrations add %1 --project ..\ProjectablesTest.Module\ --context ProjectablesTestEFCoreDbContext
