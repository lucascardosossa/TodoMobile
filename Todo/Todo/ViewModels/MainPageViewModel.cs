using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Todo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand SigninCommand { get; set; }

        private string _user;
        private string _password;

        public string User 
        { 
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public string Password 
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            Title = "Todo App Mobile";
            SigninCommand = new DelegateCommand(Signin);
        }

        private void Signin()
        {
            if (User.ToUpper() == "LUCAS" && Password == "1234")
                NavigationService.NavigateAsync("TodoList");
            else
                DialogService.DisplayAlertAsync("Erro", "Credenciais incorretas","Cancelar");
        }
    }
}
