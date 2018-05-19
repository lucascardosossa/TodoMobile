using System;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Todo.Business;

namespace Todo.ViewModels
{
    public class TodoCreateViewModel : ViewModelBase
    {
        public DelegateCommand SalvarCommand { get; set; }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        public TodoCreateViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            SalvarCommand = new DelegateCommand(Salvar);
        }

        private void Salvar()
        {
            if(String.IsNullOrEmpty(Titulo) && String.IsNullOrEmpty(Descricao))
            {
                DialogService.DisplayAlertAsync("Campos obrigatórios", "Favor preencher campos", "Ok");
                return;
            }
            try
            {
                TodoRN.CriarTarefa(new Model.Entidade.TodoDTO { Title = Titulo, Description = Descricao, Status = 0 });
                DialogService.DisplayAlertAsync("Sucesso", "Nova tarefa criada", "Ok");
                NavigationService.GoBackAsync();
            }
            catch (Exception)
            {
                DialogService.DisplayAlertAsync("Erro", "Houve erro ao inserir nova tarefa","ok");
            }

        }
    }
}
