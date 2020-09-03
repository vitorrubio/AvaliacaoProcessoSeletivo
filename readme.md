# Avaliação Dot Net Core

## Objetivo
Mais uma avaliação comum de processos seleteivos. A avaliação pede, entre outras coisas, para:
1. Adicionar um repositório git e usar gitflow
2. Criar uma API de CRUD para uma classe chamada Conta com os atributos Nome e Descrição (o que inclui criar banco de dados, mapear o context etc)
3. Criar uma aplicação WEB com Razor para consumir esta API (não especifica se é MVC ou RazorPages e não especifica se é para consumir a API server side [aplicação web consome no servidor] ou Client Side [browser consome via ajax com angular ou algo do tipo])


## Referências
## CORS
- [Enable Cross-Origin Requests (CORS) in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1)
- [O que é e como resolver os principais erros de CORS](https://www.treinaweb.com.br/blog/o-que-e-cors-e-como-resolver-os-principais-erros/)

### CORS Anywhere
É uma gambiarra, uma API que suporta CORS mas que atua como proxy para redirecionar para outra API que não suporta, assim você pode fazer uma requisição para qualquer API sem que tenha o CORS habilitado
- [Questão no Stack Overflow](https://stackoverflow.com/questions/43871637/no-access-control-allow-origin-header-is-present-on-the-requested-resource-whe)
- [Exemplo de Uso](https://ourcodeworld.com/articles/read/73/how-to-bypass-access-control-allow-origin-error-with-xmlhttprequest-jquery-ajax-)
- [https://cors-anywhere.herokuapp.com/](https://cors-anywhere.herokuapp.com/)

### Testes Unitários
- [Microsoft.VisualStudio.TestTools.UnitTesting Namespace](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=mstest-net-1.3.2)
- [Use the MSTest framework in unit tests](https://docs.microsoft.com/en-us/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests?view=vs-2019)

### EF Core e Migrations
- [Testing EF Core in Memory using SQLite](https://www.meziantou.net/testing-ef-core-in-memory-using-sqlite.htm)
- [Entity Framework Core – database initialization with Unit Test](https://www.codejourney.net/2017/07/entity-framework-core-database-initialization-with-unit-test/)
- [Access denied CREATE DATABASE LocalDB](https://stackoverflow.com/questions/56281343/access-denied-create-database-localdb)


### ChangeLog
#### 2020-02-09
testes unitarios com as combinações

InMemoryDatabase

Sqlite em arquivo

sqlite in memory

Sql server 

migrations

atualização e simplificação do wrapper de ajax

habilitando cors via atributo

