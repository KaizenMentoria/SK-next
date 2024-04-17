# Sistema Kaizen
## Desenvolver usando devcontainers do VSCode
- Clonar repositório
- No VSCode, instalar a extensão Dev Conteiners e abrir o diretório raíz do repositório
- Abrir a Command Pallete e chamar `DevContainers: Reopen in container`
Com isto o repositório local está _bind mounted_ em `/workspace` no container de desenvolvimento. 

## Executando o projeto
- Mudar para o diretório `/workspace/app`
- Se o banco de dados não foi inicializado, fazer `dotnet-ef database update`
- Fazer `dotnet run` ou `dotnet watch` para colocar o app no ar