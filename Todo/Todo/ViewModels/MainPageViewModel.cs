using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Todo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand SigninCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Todo App Mobile";
            SigninCommand = new DelegateCommand(Signin);
        }

        private void Signin()
        {
            NavigationService.NavigateAsync("TodoList");
        }
    }
}
