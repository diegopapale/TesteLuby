using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TesteLuby.Services;
using TesteLuby.Views;
using SQLite;
using PCLExt.FileStorage.Folders;
using PCLExt.FileStorage;

namespace TesteLuby
{
    public partial class App : Application
    {
        public SQLiteConnection Conexao { get; private set; }
        public App()
        {
            InitializeComponent();

            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("banco.db", CreationCollisionOption.OpenIfExists);
            Conexao = new SQLiteConnection(arquivo.Path);

            // Armazenar dados de acesso
            Conexao.Execute("create table if not exists acesso " +
                "(id integer primary key, login text)");

            // Excluir dados de acesso ao entrar
            Conexao.Execute("delete from acesso");

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
