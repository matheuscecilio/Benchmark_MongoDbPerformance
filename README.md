# Benchmark - MongoDbPerformance

This project aims to compare performance running queries in collections with and without indexes. There are two collections with 400000 documents each and one of these collections have indexes.

To run the project you have:
- Install MongoDB or run the docker-compose file if you have docker
- In the prompt go to your project folder
- Run `dotnet build -c Release`
- Get DLL's path and run `dotnet {dllpath}` 

If you want to change the number of documents on each collection, change property NumberOfDocuments on `appsettings.json`
