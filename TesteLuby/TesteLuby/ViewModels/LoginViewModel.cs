using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using TesteLuby.Services;
using TesteLuby.Models;

namespace TesteLuby.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public Action ExibirAvisoDeLoginInvalido;
        public Action ExibirPrincipal;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Senha"));
            }
        }

        public LoginViewModel()
        {
            SubmitCommand_Confirmar = new Command(OnSubmit_Confirmar);
        }

        public ICommand SubmitCommand_Confirmar { protected set; get; }

        public async void OnSubmit_Confirmar()
        {
            if (email == "user" && senha == "@123")
            {
                MockDataStore dataStore = new MockDataStore();

                Acesso acesso = new Acesso();

                acesso.Login = await GetTokenAsync();

                if (await dataStore.AddAcessoAsync(acesso))
                {
                    ExibirPrincipal();
                }
            }
            else
            {
                ExibirAvisoDeLoginInvalido();
            }
        }

        /// <summary>
        /// Recupera o retorno do get api
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetTokenAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://run.mocky.io/v3/83599a37-9b03-47d1-970d-555f8835355c");
            var token = JsonConvert.DeserializeObject<string>(response);
            return token;
        }
    }
}
