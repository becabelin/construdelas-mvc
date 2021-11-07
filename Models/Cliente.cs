using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class Cliente
    {
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public string Endereco {get;set;}
        public string Telefone {get;set;}

        public static implicit operator Cliente(List<Cliente> v)
        {
            throw new NotImplementedException();
        }
    }
}