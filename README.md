# Benchmark - MongoDbPerformance

Project to test MongoDB performance. There are two collections with 400000 documents. In one of these collections we have a indexes. The idea of this project is to compare performance running queries on both collections. 

To run the project you have:
- Install MongoDB
- In the prompt go to your project folder
- Run `dotnet build -c Release`
- Get DLL's path and run `dotnet {dllpath}` 

If you want to change the number of documents on each collection, change property NumberOfDocuments on `appsettings.json`
