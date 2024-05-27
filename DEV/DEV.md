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

# Criacao e setup DbContext com PostgreSQL
## ConnectionString
Colocar connection string para DB em appsettings.Development.json
## DbContext
Criar um DbContext "vazio" no diretorio Data.
## Conexao Postgres
Em Program.cs adicionar a seguintes linhas **ANTES** de `var app = builder.Build()`
```
var connectionString = builder.Configuration.GetConnectionString(⟨CHAVE DA CONN STRING NO JSON⟩);
builder.Services.AddDbContext<⟨APP DBCONTEXT⟩>(options => options.UseNpgsql(connectionString));
