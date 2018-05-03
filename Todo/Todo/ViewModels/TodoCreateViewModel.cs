using System;
using Prism.Navigation;
using Prism.Services;

namespace Todo.ViewModels
{
    public class TodoCreateViewModel : ViewModelBase
    {
        public TodoCreateViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            
        }
    }
}
