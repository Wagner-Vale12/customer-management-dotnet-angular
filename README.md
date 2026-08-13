# Customer Management - .NET + Angular

Aplicação Full Stack para gerenciamento de clientes, desenvolvida com **ASP.NET Core/.NET** no backend e **Angular** no frontend.

O sistema permite realizar o gerenciamento completo de clientes através de operações de cadastro, consulta, pesquisa, atualização e exclusão.

## Funcionalidades

* Cadastro de clientes
* Listagem de clientes
* Pesquisa por nome, e-mail ou CPF
* Edição de clientes
* Exclusão de clientes
* Confirmação antes da exclusão
* Validação de formulário
* Persistência dos dados em banco SQLite
* Integração entre frontend e backend através de API REST

## Dados do Cliente

Cada cliente possui os seguintes campos:

* Nome
* E-mail
* CPF
* Telefone
* Data de nascimento
* Cidade

Além desses campos, cada cliente possui um `Id` gerado automaticamente pelo banco de dados.

---

# Tecnologias

## Backend

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* LINQ
* Dependency Injection
* REST API
* Async/Await

## Frontend

* Angular 22
* TypeScript
* Reactive Forms
* Angular Signals
* HttpClient
* Observables
* HTML
* CSS

## Ferramentas

* Visual Studio Code
* PowerShell
* Git
* GitHub
* Node.js 24
* npm
* Angular CLI

---

# Arquitetura

A comunicação da aplicação segue o seguinte fluxo:

```text
Angular Component
        ↓
ClienteService
        ↓
HttpClient
        ↓
ASP.NET Core API
        ↓
ClientesController
        ↓
AppDbContext
        ↓
Entity Framework Core
        ↓
SQLite
```

O frontend é responsável pela interface e interação com o usuário.

O backend é responsável pelas regras da API e pelo acesso aos dados.

O Entity Framework Core realiza o mapeamento entre as entidades C# e o banco SQLite.

---

# Estrutura do Projeto

```text
customer-management-dotnet-angular
│
├── CadastroApi
│   │
│   ├── Controllers
│   │   └── ClientesController.cs
│   │
│   ├── Data
│   │   └── AppDbContext.cs
│   │
│   ├── Models
│   │   └── Cliente.cs
│   │
│   ├── Migrations
│   │
│   ├── Program.cs
│   ├── appsettings.json
│   └── CadastroApi.csproj
│
└── cadastro-web
    │
    └── src
        └── app
            │
            ├── models
            │   └── cliente.model.ts
            │
            ├── services
            │   └── cliente.service.ts
            │
            ├── app.ts
            ├── app.html
            ├── app.css
            └── app.config.ts
```

---

# API

A API disponibiliza os seguintes endpoints:

### Listar clientes

```http
GET /api/clientes
```

### Pesquisar clientes

```http
GET /api/clientes?termo=Wagner
```

A pesquisa pode ser realizada por:

* Nome
* E-mail
* CPF

### Buscar cliente por ID

```http
GET /api/clientes/{id}
```

### Cadastrar cliente

```http
POST /api/clientes
```

Exemplo:

```json
{
  "nome": "Wagner Vale",
  "email": "wagner@email.com",
  "cpf": "12345678901",
  "telefone": "11999999999",
  "dataNascimento": "1990-05-15",
  "cidade": "São Paulo"
}
```

### Atualizar cliente

```http
PUT /api/clientes/{id}
```

### Excluir cliente

```http
DELETE /api/clientes/{id}
```

---

# Como executar o projeto

## Pré-requisitos

Antes de iniciar, tenha instalado:

```text
.NET SDK 10
Node.js 24+
npm
Angular CLI
Git
```

Para verificar as versões:

```bash
dotnet --version
node --version
npm --version
ng version
```

---

# 1. Clonar o repositório

```bash
git clone https://github.com/Wagner-Vale12/customer-management-dotnet-angular.git
```

Entre na pasta:

```bash
cd customer-management-dotnet-angular
```

---

# 2. Executar o Backend

Entre na pasta da API:

```bash
cd CadastroApi
```

Restaure as dependências:

```bash
dotnet restore
```

Caso ainda não tenha a ferramenta do Entity Framework instalada:

```bash
dotnet tool install --global dotnet-ef
```

Atualize o banco de dados utilizando as migrations:

```bash
dotnet ef database update
```

Execute a API:

```bash
dotnet run --urls http://localhost:5000
```

A API estará disponível em:

```text
http://localhost:5000
```

---

# 3. Executar o Frontend

Abra outro terminal.

Entre na pasta do frontend:

```bash
cd cadastro-web
```

Instale as dependências:

```bash
npm install
```

Execute o Angular:

```bash
ng serve
```

A aplicação estará disponível em:

```text
http://localhost:4200
```

Abra no navegador:

```text
http://localhost:4200
```

---

# Comunicação entre Frontend e Backend

O Angular utiliza o `HttpClient` para consumir a API .NET.

A URL utilizada pelo frontend é:

```text
http://localhost:5000/api/clientes
```

Durante o desenvolvimento:

```text
Frontend
http://localhost:4200

        ↓ HTTP

Backend
http://localhost:5000

        ↓

SQLite
```

O backend possui configuração de CORS permitindo a comunicação com o frontend Angular.

---

# CRUD

O projeto implementa as quatro operações básicas de persistência:

```text
CREATE
Cadastrar cliente

READ
Listar e pesquisar clientes

UPDATE
Editar cliente

DELETE
Excluir cliente
```

---

# Banco de Dados

O projeto utiliza **SQLite** como banco de dados.

O acesso aos dados é realizado através do **Entity Framework Core** utilizando o `AppDbContext`.

As alterações da estrutura do banco são controladas através de migrations.

Exemplo:

```bash
dotnet ef migrations add NomeDaMigration
```

Para aplicar uma migration:

```bash
dotnet ef database update
```

---

# Frontend

O formulário foi desenvolvido utilizando **Angular Reactive Forms**.

A aplicação utiliza validações para os campos e um `ClienteService` responsável por centralizar a comunicação com a API.

A listagem de clientes utiliza **Angular Signals** para gerenciamento do estado utilizado pelo template.

Exemplo do fluxo:

```text
Usuário
   ↓
Formulário Angular
   ↓
ClienteService
   ↓
API .NET
   ↓
Entity Framework
   ↓
SQLite
```

---

# Autor

**Wagner Vale**

Desenvolvedor Full Stack
