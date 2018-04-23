using System;
using Prism.Navigation;

namespace Todo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public TodoListViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }
    }
}
