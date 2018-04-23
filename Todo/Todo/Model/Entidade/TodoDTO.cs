using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Todo.Model.Entidade
{
    public class TodoDTO
    {
        public String Title { get; set; }

        public String Description { get; set; }

        public int Status { get; set; }

        public Color StatusColor { get; set; }

    }
}
