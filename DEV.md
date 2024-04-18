# Criando template do projeto
- `dotnet new mvc --auth Individual --use-program-main --output App` copia o template localmente
- `dotnet add package` para `Npgsql` e `Npgsql.EntityFrameworkCore.PostgreSQL` para usarmos PostgreSQL
- Ajustar connection string em `appsettings.json` para apontar para o DB conteinerizado, i.e. `"Server=database;Port=5432;Database=postgres;User Id=postgres;Password=postgres;"`
- Trocar `UseSqlite` por `UseNpgsql` em `builder.Services.AddDbContext` em `Program.cs`
- Apagar `Data/Migrations/` para remover as migrações iniciais (criadas para SQLite por padrão)
- Recriar migrações usando `dotnet ef migrations add IdentityInitial`
- Se desejado, alterar porta do webserver em  `Properties/launchSettings.json`

## removendo Implicit Usings
- `app.csproj`: trocar `ImplicitUsings` para `disable`
- `Program.cs`: adicionar explicitamente os usings como descrito [neste artigo](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview#implicit-using-directives)
- `HomeController.cs`: adicionar explicitamente os usings pedidos. Tente `dotnet run` para o compilador avisar quais faltam (provavelmente `Microsoft.Extensions.Logging`)

# adicionar model e CRUD scaffold
- criar Models/Xyz.cs
- `dotnet aspnet-codegenerator controller -name XyzController -m Xyz -dc app.Data.XyzContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider postgres`
- ajustar db connection string em Program.cs
- `dotnet ef migrations add XyzInitial`, `dotnet ef database update`
- - caso erro 137: OOM/resource demais. rodar pelo docker engine e nao make.
- possivelmente ajustar connectionstrings em appsettings.json
