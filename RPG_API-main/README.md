# RPG_API
quando criar o projeto lembrar de ir na pasta properties o arquivo .json de la e remover a primeira parte de linha que tem o localhost por que se não da erro executando localmente

comandos
	dotnet new webapi -n (nome do projeto) -> cria um projeto de web api 
	dotnet build -> para compilar o projeto 	
	dotnet run -> para rodar o projeto 

para acessar a pagina do controler é localhost:5197/PersonagensExemplo/ 


oq é um ORM => é um framework que auxilia na conexão com o banco
	usa o método code first migration

modelo MVC => é um modelo baseado em separar o código em controller, model e view]

oq e o CRUD => são as principais operações de banco (create, update, delete, read)

dotnet add package Microsoft.EntityFrameworkCore.SqlServer => serve pra instalar o pacote do ORM

dotnet tool install --global dotnet-ef => permite trabalhar com os comandos do Migration

dotnet add package Microsoft.EntityFrameworkCore.Design => permiti customizar as tabelas pelo c#