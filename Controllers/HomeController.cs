using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clientes(string nome, string telefone, string endereco)
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

        public IActionResult Hamburgeres(string nome, int quantidade, double valor, List<Ingrediente> ingredientes)
        {

            var hamburgeres = HamburgerDto.Todos();
            ViewBag.ingredientes = IngredientesDto.Todos();

            if(!string.IsNullOrEmpty(nome))
            {
                var hamburger = new Hamburger(){
                    Codigo = (hamburgeres.Count + 1),
                    Nome = nome,
                    Quantidade = quantidade,
                    Valor = valor,
                    Ingredientes = ingredientes
                };
                var listaHam = new List<Hamburger>();
                listaHam.Add(hamburger);

                HamburgerDto.Salvar(listaHam);

                Console.WriteLine("Cadastro de hamburger realizado");
            }

            ViewBag.hamburgeres = HamburgerDto.Todos();

            return View();
        }

        public IActionResult Pedidos(List<Cliente> clientes, List<Hamburger> hamburgeres, double valorTotal)
        {
            var pedidos = PedidoDto.Todos();
            ViewBag.pedidos = PedidoDto.Todos();

            hamburgeres = HamburgerDto.Todos();
            ViewBag.hamburgeres = HamburgerDto.Todos();

            if(!string.IsNullOrEmpty(valorTotal.ToString())){
                var pedido = new Pedido(){
                    Codigo = (pedidos.Count + 1),
                    Cliente = clientes,
                    Itens = hamburgeres,
                    ValorTotal = valorTotal
                };
                var listaPed = new List<Pedido>();
                listaPed.Add(pedido);

                PedidoDto.Salvar(listaPed);

                Console.WriteLine("Cadastro de pedido realizado");
            }

            ViewBag.pedidos = PedidoDto.Todos();

            return View();
        }

        public IActionResult Ingredientes(string nome)
        {

            var ingredientes = IngredientesDto.Todos();

            if(!string.IsNullOrEmpty(nome))
            {
                var Ingrediente = new Ingrediente(){
                    Codigo = (ingredientes.Count + 1),
                    Nome = nome
                };
                var listaCli = new List<Ingrediente>();
                listaCli.Add(Ingrediente);

                IngredientesDto.Salvar(listaCli);

                Console.WriteLine("Novo ingrediente cadastrado");
            }

            ViewBag.ingredientes = IngredientesDto.Todos();

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
