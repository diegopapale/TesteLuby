# TesteLuby Xamarin

#### Projeto TesteLuby:
- Criado para gerenciar a regra geral da aplicação, código compartilhado por todas as plataformas.
- Model:
	- Contém os modelos usados no app, acesso para guardar os dados de acesso, menu e o item que refere-se aos usuários cadastrados.
- ViewModel:
    - Contém o modelo das Views, Main, login, about e do cadastro dos usuarios.
	- Criei um baseview para usar em todas as demais views, para acesso as classes de data.
	- Loginviewmodel, foi implementado a conferencia de login e o uso do token via endpoint.
- Views:
    - Contém as telas .axml, que são vinculadas as viewmodels.
	- Fiz a implementação da tela de login, no OnAppearing do mainpage, assim o login é mostrado ao carregar a tela principal.
	- App.xaml: 
		- Fiz a chamada pra tela principal, main. 
		- Faz a criação do banco sqlite.
		- Criação da tabela caso não exista, de acesso. (Essa tabela vai ser alimentada no login e pode ser usada em qualquer lugar no sistema).
		- Exclui dados de acesso se tiver, na entrada.
- Services:
	- IDataStore, é a inteface de comunicação.
	- MockDataStore, onde forma alocados os métodos crud.
- Dependencias:
	- Usei sqlite-net-pcl pra sqllite.
	- Newtonsoft, para trabalhar com o retorno do endpoint em json.
	- PclExt, para identificar o path do dispositivo onde salvar a base de dados.

#### Projeto TesteLuby.Android:
- Código do projeto especifico para plataforma Android.

#### Projeto TesteLuby.IOS:
- Código do projeto especifico para plataforma IOS.