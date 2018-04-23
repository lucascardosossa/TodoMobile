using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Prism.Navigation;
using Todo.Model.Entidade;

namespace Todo.ViewModels
{
    public class TodoListViewModel : ViewModelBase
    {
        public IList<TodoDTO> TodoCollection { get; set; }

        public TodoListViewModel(INavigationService navigationService) : base(navigationService)
        {
            TodoCollection = new List<TodoDTO>();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Title = "Lista de Tarefas";
            GenerateTodoList();
        }

        private void GenerateTodoList()
        {
            for (var i = 0; i < 10; i++)
            {
                var todo = new TodoDTO()
                {
                    Title = "Tarefa " + i,
                    Description = "Refatorar" + i,
                    Status = i % 2 ,
                    StatusColor = (i % 2 == 0) ? Color.Green : Color.Red,
                };
                TodoCollection.Add(todo);
            }
        }
    }
}
