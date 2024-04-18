# instalando ferramentas dotnet
export PATH=$HOME/.dotnet/tools:$PATH
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator

# connection string
para postgres sob Npgsql
Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=myUsername;Password=myPassword;
https://rjdudley.com/installing-asp-net-core-identity-in-postgresql/

# app + auth a partir de template
- `$ dotnet new mvc -au Individual -o app --use-program-main`: cria app básico MVC Asp.Net usando esquema de autenticação Individual.
- `$ dotnet add package Npgsql ; dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL`: pacotes necessários para conexão do .NET com banco PostgreSQL.
- `app/appSettings.json`: mudar default connection para connection string do Postgres, formato "`Server=127.0.0.1;Port=5432;Database=myDataBase;User Id=postgres;Password=postgres"`.
- `app/Program.cs`: substituir `UseSqlite` por `UseNpgsql`.
- `$ dotnet-ef migrations remove`: remove migrações que vem por padrão.
- `$ dotnet-ef migrations add MigracaoInicial`: cria nova migração incluindo as coisas do Identity.
- `$ dotnet-ef database update`: aplica as migrações já no banco Postgres.
## removendo Implicit Usings
- `app.csproj`: trocar `ImplicitUsings` para `disable`
- `Program.cs`: adicionar explicitamente os usings como descrito [neste artigo](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview#implicit-using-directives)
- `HomeController.cs`: adicionar explicitamente os usings pedidos. Tente `dotnet run` para o compilador avisar quais faltam (provavelmente `Microsoft.Extensions.Logging`)

# bibliotecas dotnet (dotnet add package)
- Npgsql.EntityFrameworkCore.PostgreSQL
- Microsoft.EntityFrameworgkCore.Design
- Microsoft.EntityFrameworkCore.SQLite
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

# migrations
dotnet-ef database drop
dotnet-ef database update
dotnet ef migrations list
dotnet ef dbcontext {info,list,scaffold}

# adicionar model e CRUD scaffold
- criar Models/Xyz.cs
- `dotnet aspnet-codegenerator controller -name XyzController -m Xyz -dc app.Data.XyzContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries --databaseProvider postgres`
- ajustar db connection string em Program.cs
- `dotnet ef migrations add XyzInitial`, `dotnet ef database update`
- - caso erro 137: OOM/resource demais. rodar pelo docker engine e nao make.
- possivelmente ajustar connectionstrings em appsettings.json
