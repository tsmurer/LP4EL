# LP4EL
Projeto dotnet para a matéria LP4EL, no curso de Análise e Desenvolvimento de Sistemas do Instituto Federal de Ciência e Tecnologia de São Paulo
Trata-se de uma aplicação não comercial para que hemocentros registrem a doação de sangue por um usuário da aplicação. O registro gera pontos para o usuário e os pontos são
usados para, idealmente, comprar vantagens em jogos, cupons e etc.

# Instruções
São necessários para executar a aplicação:
  - Angular
  - ASP.NET
  - Banco de Dados MySQL
  
Para executar a aplicação em localhost é necessário:
  - ajustar a connection string (DefaultConnection) no arquivo appsetings.json
  - usar o comando 'ng serve' no diretório LP4EL-Front
  - usar o comando 'dotnet run' no diretório

É necessário popular o banco de dados por scrip de produtos. O seguinte script pode ser seguido para adicionar produtos:

```sh
use shopjoin;
insert into produtos values
    (default, 'produto 1', 100),
    (default, 'produto 2', 200),
    (default, 'produto 3', 300),
    (default, 'produto 4', 400);
```

As demais informações podem ser registradas com a utilização da aplicação. A lista de hemocentros associados na homepage depende de cadastro de Hospital.
