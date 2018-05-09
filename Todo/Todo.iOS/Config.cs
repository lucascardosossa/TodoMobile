using System;
using SQLite.Net.Interop;
using Todo.Repository.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(Todo.iOS.Config))]

namespace Todo.iOS
{
    public class Config : IConfig
    {
        private string _diretorioSQLite;
        private SQLite.Net.Interop.ISQLitePlatform _plataforma;

        public string DiretorioSQLite
        {
            get
            {
                if (string.IsNullOrEmpty(_diretorioSQLite))
                {
                    _diretorioSQLite = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                return _diretorioSQLite;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (_plataforma == null)
                {
                    _plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return _plataforma;
            }
        }
    }
}