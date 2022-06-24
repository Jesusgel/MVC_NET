using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Practica_MVC.Models.ViewModels
{
    public class TablaUsuarioVM
    {

        public int id { get; set; }
        public string name {get; set;}
        public string apellido { get; set; }
        public string correo { get; set; }
    }
}