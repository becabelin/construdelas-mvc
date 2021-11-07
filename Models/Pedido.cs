using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class Pedido
    {
        public int Codigo {get;set;}
        public List<Hamburger> Itens {get;set;}
        public Cliente Cliente {get;set;}

        public double ValorTotal {get;set;}
    }
}