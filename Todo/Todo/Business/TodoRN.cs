using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Model.Entidade;
using Todo.Repository;

namespace Todo.Business
{
    public class TodoRN
    {


        public static bool CriarTarefa(TodoDTO todo)
        {
            bool retorno = false;
            try
            {
                using(var query = new TodoRepository())
                {
                    query.InserirTarefa(todo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static List<TodoDTO> ListarTarefas()
        {
            try
            {
                using(var query = new TodoRepository())
                {
                    return query.GetTarefas();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool Atualizar(TodoDTO todo)
        {
            try
            {
                using(var query = new TodoRepository())
                {
                    return query.AtualizarTarefa(todo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Remover(TodoDTO todo)
        {
            try
            {
                using(var query = new TodoRepository())
                {
                    return query.DeletarTarefa(todo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
