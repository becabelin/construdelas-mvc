using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class Hamburger
    {
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public int Quantidade {get;set;}
        public double Valor {get;set;}
        public List<Ingrediente> Ingredientes {get;set;}
    }
}