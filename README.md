# TesteLuby Xamarin

#### Projeto TesteLuby:
- Criado para gerenciar a regra geral da aplica��o, c�digo compartilhado por todas as plataformas.
- Model:
	- Cont�m os modelos usados no app, acesso para guardar os dados de acesso, menu e o item que refere-se aos usu�rios cadastrados.
- ViewModel:
    - Cont�m o modelo das Views, Main, login, about e do cadastro dos usuarios.
	- Criei um baseview para usar em todas as demais views, para acesso as classes de data.
	- Loginviewmodel, foi implementado a conferencia de login e o uso do token via endpoint.
- Views:
    - Cont�m as telas .axml, que s�o vinculadas as viewmodels.
	- Fiz a implementa��o da tela de login, no OnAppearing do mainpage, assim o login � mostrado ao carregar a tela principal.
	- App.xaml: 
		- Fiz a chamada pra tela principal, main. 
		- Faz a cria��o do banco sqlite.
		- Cria��o da tabela caso n�o exista, de acesso. (Essa tabela vai ser alimentada no login e pode ser usada em qualquer lugar no sistema).
		- Exclui dados de acesso se tiver, na entrada.
- Services:
	- IDataStore, � a inteface de comunica��o.
	- MockDataStore, onde forma alocados os m�todos crud.
- Dependencias:
	- Usei sqlite-net-pcl pra sqllite.
	- Newtonsoft, para trabalhar com o retorno do endpoint em json.
	- PclExt, para identificar o path do dispositivo onde salvar a base de dados.

#### Projeto TesteLuby.Android:
- C�digo do projeto especifico para plataforma Android.

#### Projeto TesteLuby.IOS:
- C�digo do projeto especifico para plataforma IOS.