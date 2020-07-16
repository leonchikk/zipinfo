## Setup project and run 

Build ZipInfo project using the .NET Core CLI, which is installed with [the latest .NET Core SDK](https://www.microsoft.com/net/download). Then run
these commands from the CLI in the root directory of the project:

```console
dotnet build
dotnet run --project ZipInfo.API
```

Then make GET request via Postman (or whatever you want) to endpoint /api/cities/info/zip-code/<zipCode>

