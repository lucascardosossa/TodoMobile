using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Todo.Business;
using Todo.Model.Entidade;

namespace Todo.ViewModels
{
    public class TodoItemViewModel : ViewModelBase
    {
        private TodoDTO _todo;
        public TodoDTO Todo
        {
            get { return _todo; }
            set { SetProperty(ref _todo, value); }
        }

        public DelegateCommand RemoveCommand { get; set; }
        public DelegateCommand EditarCommand
        {
            get;
            set;
        }

        public TodoItemViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            RemoveCommand = new DelegateCommand(Remove);
            EditarCommand = new DelegateCommand(Editar);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Todo = (TodoDTO)parameters["model"];
        }

        private async void Remove()
        {
            var result = await DialogService.DisplayAlertAsync("Remover", "Deseja remover esta tarefa", "Confirmar", "Cancelar");
            if (result)
            {
                try
                {
                    TodoRN.Remover(Todo);
                    DialogService.DisplayAlertAsync("Sucesso", "Tarefa foi removida", "Ok");
                    NavigationService.GoBackAsync();
                }
                catch (Exception ex)
                {
                    await DialogService.DisplayAlertAsync("Erro", ex.Message.ToString(), "Ok");
                }

            }
        }

        private async void Editar()
        {
            var result = await DialogService.DisplayAlertAsync("Edição", "Confirmar alterações", "Confirmar", "Cancelar");
            if (result)
            {
                try
                {
                    TodoRN.Atualizar(Todo);
                    DialogService.DisplayAlertAsync("Sucesso", "Alterações realizadas", "Ok");
                    NavigationService.GoBackAsync();
                }
                catch (Exception ex)
                {
                    await DialogService.DisplayAlertAsync("Erro", ex.Message.ToString(), "Ok");
                }

            }
        }
    }
}
