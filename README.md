# MemoryGameBackEnd

Necessário executar o comando de migrations:

Entrar no diretório do projeto core 
"cd MemoryGame.Core"

Executar o comando de migration
"dotnet ef database update --startup-project ..\MemoryGame.Api\MemoryGame.Api.csproj"

A conexão com o Banco de dados é através da porta 1433 com usuario "sa"
Alterar a senha no arquivo appsettings.json presente no diretório \MemoryGame.Api

Front-End localhost:3000 e BackEnd localhost:5000


Caso haja problemas com CORS devido a restrições do browser, instalar uma extensão do Chrome que ignore o cors para http.
