# Sistema Kaizen

## Setup desenvolvimento
- Instalar VSCode e extensão Dev Containers
- Clonar repositório (de preferência pelo próprio VSCode)
- Abrir repositório local pelo VSCode
- Abrir a Command Pallete e chamar `DevContainers: Rebuild and reopen in container`
Com isto o repositório local está _bind mounted_ em `/workspace` e o VSCode roda dentro do conteiner.

## Executando o projeto
- Mudar para o diretório `/workspace/App`
- Se o banco de dados não foi inicializado, fazer `dotnet-ef database update`
- Fazer `dotnet run` ou `dotnet watch` para colocar o app no ar
