using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SQLite.Net;
using Todo.Model.Entidade;
using Todo.Repository.Interfaces;
using Xamarin.Forms;

namespace Todo.Repository
{
    public class TodoRepository : IDisposable
    {
        private SQLiteConnection conexaoSQLite;

        public TodoRepository()
        {
            var config = DependencyService.Get<IConfig>();
            conexaoSQLite = new SQLiteConnection(config.Plataforma, Path.Combine(config.DiretorioSQLite, "Cadastro.db3"));
            conexaoSQLite.CreateTable<TodoDTO>();
        }
        public void InserirTarefa(TodoDTO todo)
        {
            conexaoSQLite.Insert(todo);
        }

        public void AtualizarTarefa(TodoDTO todo)
        {
            conexaoSQLite.Update(todo);
        }

        public void DeletarTarefa(TodoDTO todo)
        {
            conexaoSQLite.Delete(todo);
        }

        public TodoDTO GetTarefa(int codigo)
        {
            return conexaoSQLite.Table<TodoDTO>().FirstOrDefault(c => c.TodoId == codigo);
        }

        public List<TodoDTO> GetTarefas()
        {
            return conexaoSQLite.Table<TodoDTO>().ToList();
        }

        public void Dispose()
        {
            conexaoSQLite.Dispose();
        }

    }
}
