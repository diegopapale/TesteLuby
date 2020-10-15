using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteLuby.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TesteLuby.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            var vm = new LoginViewModel();
            BindingContext = vm;

            vm.ExibirAvisoDeLoginInvalido += () => DisplayAlert("Erro", "Login Inválido, tente novamente.", "OK");

            vm.ExibirPrincipal += () => Chama_Principal();

            InitializeComponent();

            Email.Completed += (object sender, EventArgs e) =>
            {
                Senha.Focus();
            };
        }

        private async void Chama_Principal()
        {
            // tirando pagina da pilha a pagina
            Navigation.RemovePage(Navigation.NavigationStack[1]);

            // voltando para pagina anterior
            await Navigation.PopAsync(true);
        }
    }
}