using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace TesteLuby.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public Action ExibirLogin;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public ICommand SubmitCommand_Login { protected set; get; }
        public string Acesso { get; set; }

        public MainViewModel()
        {
            SubmitCommand_Login = new Command(OnSubmit_Login);
        }

        public void OnSubmit_Login()
        {
            ExibirLogin();
        }
    }
}
