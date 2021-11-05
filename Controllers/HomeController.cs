using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvc.Models;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro(string nome, string telefone, string endereco)
        {

            var clientes = ClienteDto.Todos();

            if(!string.IsNullOrEmpty(nome))
            {
                var cliente = new Cliente(){
                    Codigo = (clientes.Count + 1),
                    Nome = nome,
                    Telefone = telefone,
                    Endereco = endereco
                };
                var listaCli = new List<Cliente>();
                listaCli.Add(cliente);

                ClienteDto.Salvar(listaCli);

                Console.WriteLine("Cadastro realizado");
            }

            ViewBag.clientes = ClienteDto.Todos();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
