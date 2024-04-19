# Criar e ajustar template do projeto
- `dotnet new mvc --auth Individual --use-program-main --output App` copia o template localmente
- `dotnet add package` para `Npgsql` e `Npgsql.EntityFrameworkCore.PostgreSQL` para usarmos PostgreSQL
- Ajustar connection string em `appsettings.json` para apontar para o DB conteinerizado, i.e. `"Server=database;Port=5432;Database=postgres;User Id=postgres;Password=postgres;"`
- Trocar `UseSqlite` por `UseNpgsql` em `builder.Services.AddDbContext` em `Program.cs`
- Apagar `Data/Migrations/` para remover as migrações iniciais (criadas para SQLite por padrão)
- Recriar migrações usando `dotnet ef migrations add IdentityInitial`
- Se desejado, alterar porta do webserver em  `Properties/launchSettings.json`

# Remover Implicit Usings
- `app.csproj`: trocar `ImplicitUsings` para `disable`
- `Program.cs`: adicionar explicitamente os usings como descrito [neste artigo](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview#implicit-using-directives)
- `HomeController.cs`: adicionar explicitamente os usings pedidos. Tente `dotnet run` para o compilador avisar quais faltam (provavelmente `Microsoft.Extensions.Logging`)

# Criar modelo/entidade e gerar migrações ou CRUD

## Criar classes referentes a entidades/modelos 
Criar classes sob o diretório `Models`. Veja explicação [aqui](https://learn.microsoft.com/en-us/ef/core/modeling/).

## Registrar classes OU scaffold CRUD
Para que o EF crie as migrações relativas às entidades, estas devem estar registradas como propriedades de um `DbContext` como e.g. `DbSet<MinhaEntidade>`. Isto pode ser feito à mão ou aproveitando o gerador de código e.g.

 ```dotnet aspnet-codegenerator controller -name <Nome>Controller -m <Nome> -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider postgres```

Veja um tutorial [aqui](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-8.0).

## Gerar migrações referentes às entidades
A ferramenta `dotnet ef` cria automaticamente as migrações com o comando `dotnet ef migrations add <NOMEDAMIGRACAO>`. As migrações podem ser aplicadas com o comando `dotnet ef database update`. 
