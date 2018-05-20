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

        public bool AtualizarTarefa(TodoDTO todo)
        {
            return conexaoSQLite.Update(todo) > 0;
        }

        public bool DeletarTarefa(TodoDTO todo)
        {
            return conexaoSQLite.Delete(todo) > 0;
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
