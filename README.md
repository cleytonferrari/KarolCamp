KarolCamp
=========

Sistema para controle de Eventos e Palestras

Controla:
	1. Trilha
	2. Sala
	3. Palestrante
	4. Palestra

** Para cada tela foi criado uma lista, cadastro, detalhes e edição.

	Este código foi separado em varias branchs, cada branch esta uma etapa do processo de fatoração do código. 
	Veja todas as branchs https://github.com/cleytonferrari/KarolCamp/branches


## Branch ##

### codigoRefatoradoNivel3 ###
	Nesta branch foi somente refatorado o HTML e CSS aplicado um layout para o sistema
	
	A Solution continua separada em vários projetos:
	1. KarolCamp.Aplicacao
		Neste projeto fica toda a logica do negocio e abstração da manipulação dos dados (CRUD)
	2. KarolCamp.Dominio
		Neste projeto fica as classes que representa o dominio (POCO)
	3. KarolCamp.Repositorio.EF
		Neste projeto fica o repositorio do Entity Framework, que abstrai o nosso acessao ao SQL Server
	4. KarolCamp.Repositorio.Mongo
		Neste projeto fica o repositorio do MongoDb, que abstrari o acesso ao MongoDb
	5. KarolCamp.UI.Web
		Neste projeto fica os ASP .Net MVC que representa nossa interface gráfica
		
	** Banco utilizado MongoDb
	** Banco utilizado SQL Server com EF
