# xp-customer-api

- Versão do .NET utilizada: [6.0](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
- ORM: [Entity Framework Core 6.0.21](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.21)
- Documentação: [Swagger](https://swagger.io/)
- Clean Architecture: para estruturar o código de maneira eficiente, separando as responsabilidades por módulos para uma melhor leitura e manutenção do código.
- Padrão de design de projeto utilizado: o padrão Repository para isolar a manipulação de dados, facilitando o uso da injeção de dependência (DI).
- Minimal API's: utilizando a abordagem que simplifica a criação de API's
- Docker-Compose: arquivo de configuração sobe tanto o banco de dados SQL Server 2022 (e suas dependências) quanto a aplicação do desafio técnico.
- Como é feita a validação do telefone?
  - O telefone pode ser declarado da seguinte forma:
  - Deve conter 2 dígitos de região, com parênteses opcional
  - Pode conter '-' ou espaço
  - Deve conter 4 a 5 dígitos (primeira parte do número)
  - Pode conter '-' ou espaço
  - Deve conter 4 dígitos (última parte do número)
  - No projeto de testes temos alguns casos de testes para serem testados.
