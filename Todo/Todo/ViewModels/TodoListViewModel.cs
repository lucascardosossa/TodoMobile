using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Prism.Navigation;
using Todo.Model.Entidade;
using Prism.Services;
using Prism.Commands;
using Todo.Business;
using System.Windows.Input;

namespace Todo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        private IList<TodoDTO> _todoCollection;
		public IList<TodoDTO> TodoCollection
		{
			get { return _todoCollection; }
			set { SetProperty(ref _todoCollection, value); }
		}

		public DelegateCommand NovoCommand { get; set; }

        public ICommand ItemTappedCommand { get; set; }


		public TodoListViewModel(INavigationService navigationService, IPageDialogService dialogService) 
            : base(navigationService, dialogService)
        {
            NovoCommand = new DelegateCommand(Novo);
            ItemTappedCommand = new DelegateCommand<object>(ItemTapped);
        }

        private void ItemTapped(object todo)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("model", todo);
            NavigationService.NavigateAsync("TodoItem", navigationParams);

        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Title = "Lista de Tarefas";
			TodoCollection = TodoRN.ListarTarefas();
        }


		public override void OnNavigatedFrom(NavigationParameters parameters)
		{
			base.OnNavigatedFrom(parameters);
            TodoCollection = TodoRN.ListarTarefas();
		}

		private void Novo()
        {
            NavigationService.NavigateAsync("TodoCreate");
        }
    }
}
