using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite.Net.Attributes;

namespace Todo.Model.Entidade
{
    public class TodoDTO
    {
        [PrimaryKey]
        [AutoIncrement]
        public int TodoId
        {
            get;
            set;
        }
        public String Title { get; set; }

        public String Description { get; set; }

        public int Status { get; set; }

        [Ignore]
        public Color StatusColor { get; set; }

    }
}
