# Minimal API RESTful com .NET 5.0 

# Introdução

### Este projeto é uma implementação de uma API RESTful minimalista utilizando .NET 5.0, com integração ao banco de dados via Entity Framework Core, autenticação JWT Bearer e testes de integração utilizando xUnit.:

### Principais Tecnologias e Funcionalidades:

 *  SqlServer: Banco de dados relacional para armazenamento das tabelas.
 *  Entity Framework: Ferramenta ORM para mapeamento e manipulação dos dados do banco.
 *  Autenticação JWT (Bearer Token): Implementação de segurança para proteger a API, com geração e validação de tokens JWT para acesso autorizado.
 *  Swagger (OpenAPI): Interface para documentação interativa e teste dos endpoints da API.

### Endpoints Planejados:

   #### Usuario:
   * Registrar: Adiciona uma novo registro de Usuario.
   * Login: Validação de credenciais e geração de token JWT.

   #### Cursos:
   * Cadastro de cursos vinculados a usuários autenticados Jwt Bearer Token.
   * Consulta, usuários autenticados Jwt Bearer Token.

### Objetivos:

* Fornecer uma API simples, segura e eficiente para autenticação e gerenciamento de veículos.
* Facilitar a integração com sistemas externos por meio de endpoints bem documentados no Swagger.
* Demonstrar boas práticas de desenvolvimento utilizando .NET 6, EF Core e autenticação JWT.

Se precisar de ajuda com implementação ou ajustes, é só avisar!

## Technologies used

 * .net 5 
 * EntityFrameworkCore 3.1.9
 * Autenticação com JWT Bearer 3.1.9
 * SuwggreSwashbuckle.AspNetCore 5.6.3
 * Banco de dados SqlServer
 * Testes com Xunit 2.4.1
 * AutoBogus 2.13.1

## Requirements to run:

- .Net5 

- Database SqlServer
* appsetting.json 
```
 // changes to your connection string
 "ConnectionStrings": {
    "DefaultConnection":"Server=localhost;Database=CURSO;user=sa;password=App@223020";
  },
```

## Running Api Test Instructions
1. Para rodar os testes de integração:
```
cd Test
```
```
dotnet test
```
## Estrutura de Testes

Os testes utilizam o xUnit e estão localizados no diretório Tests/. Eles cobrem:

* Integração com o banco de dados SQL Server.

* Validação de endpoints protegidos (ex.: cadastro de cursos).

* Validação de autenticação e emissão de tokens JWT.

## Running Api Instructions

1. Clone the project:

```
 git clone https Chave SSh
```

2. Install the dependecies:

```
 Cd curso.api
```
```
 dotnet restore
```

3. Run the project:

```
  Cd curso.api
```
```
dotnet run
```

## Observação
Este projeto foi desenvolvido como um exemplo educativo e pode ser expandido ou adaptado conforme a necessidade.

