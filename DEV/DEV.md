# para criar template
- `dotnet new mvc --auth None --no-https --framework net8.0 --use-program-main`

# para trocar porta do server dev
Properties/launchSettings.json em profile http application url

# pacotes EF core
`dotnet add package ...`
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Abstractions
- Microsoft.EntityFrameworkCore.Analyzers (roslyn code analyzer for efcore)
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Relational
- Microsoft.EntityFrameworkCore.Relational.Specification.Tests
- Npgsl (postgres database provider)
- Npgsql.EntityFrameworkCore.PostgreSQL (postgres para EF core)

`dotnet tool install --global ...`
- aspnet-codegenerator
- dotnet-ef
