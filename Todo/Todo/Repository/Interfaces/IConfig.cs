using System;
using SQLite.Net.Interop;

namespace Todo.Repository.Interfaces
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}
