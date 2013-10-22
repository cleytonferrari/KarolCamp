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

<<<<<<< HEAD
### Master ###
	Esta é a branch de desenvolvimento, utilizado na construção das outras branch
=======
### codigoRefatoradoNivel1 ###
	Nesta branch a solution foi dividida em vários projetos:
	1. KarolCamp.Aplicacao
		Neste projeto fica toda a logica do negocio e abstração da manipulação dos dados (CRUD)
	2. KarolCamp.Dominio
		Neste projeto fica as classes que representa o dominio (POCO); Neste projeto tambem ficam as interfaces IRepositorio.cs e IRepositorioArquivo.cs que abstrai o Repositorio para utilização de qualquer banco.
	3. KarolCamp.Repositorio.Mongo
		Neste projeto fica o repositorio do MongoDb, que abstrari o acesso ao MongoDb
	4. KarolCamp.UI.Web
		Neste projeto fica os ASP .Net MVC que representa nossa interface gráfica

	** Banco utilizado MongoDb
>>>>>>> codigoRefatoradoNivel1
