### For development purpose
1. Start the API
    ```
    dotnet run --project ..\..\src\Catalog.Service.Api\Catalog.Service.Api.csproj
    ```

2. Build jar
    ```
    .\build-jar.ps1
    ```

3. Run tests from jar
    ```
    .\run-jar.ps1
    ```
    Or use following command to build & run tests `.\build-jar.ps1; .\run-jar.ps1`
