# Sales Web MVC

Aplicação web desenvolvida com ASP.NET Core MVC para gerenciamento de vendedores, departamentos e registros de vendas.

O projeto foi criado com o objetivo de praticar conceitos de desenvolvimento web utilizando C#, Entity Framework Core e banco de dados relacional, seguindo o padrão MVC.

## Funcionalidades

- Cadastro, edição e exclusão de vendedores
- Cadastro de departamentos
- Registro de vendas
- Filtro de vendas por período
- Validação de dados
- Seed de dados para popular o banco

## Tecnologias utilizadas

- C#
- ASP.NET Core MVC
- Entity Framework Core
- MySQL
- LINQ
- Bootstrap

## Como executar

1. Clone o repositório.
2. Configure a string de conexão no arquivo `appsettings.json`.
3. Execute as migrations:

```bash
dotnet ef database update
```

4. Inicie a aplicação:

```bash
dotnet run
```

## Aprendizados

Durante o desenvolvimento deste projeto pratiquei:

- Arquitetura MVC
- Entity Framework Core
- Relacionamentos entre entidades
- Consultas com LINQ
- Injeção de dependência
- Operações assíncronas (`async`/`await`)
- CRUD completo

---
Projeto desenvolvido para fins de estudo.
