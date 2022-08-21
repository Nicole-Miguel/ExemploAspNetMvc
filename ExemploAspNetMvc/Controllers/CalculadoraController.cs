using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExemploAspNetMvc.Models;

namespace ExemploAspNetMvc.Controllers;

public class CalculadoraController : Controller 
{
    public class UserForm
    {
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
    }
    private readonly ILogger<CalculadoraController> _logger;

    public CalculadoraController(ILogger<CalculadoraController> logger)
    {
        _logger = logger;
    }
   
   public IActionResult Operacao ()
   {
        return View();
   }
    public IActionResult Resultado ([FromForm] string operacao, [FromForm] double n1, [FromForm] double n2)
    {
        ViewBag.operacao = operacao;
        ViewBag.Numero1 = n1;
        ViewBag.Numero2 = n2;

        switch(operacao)
        {
            case "Soma":
                ViewBag.operadorAritmetico = '+';
                ViewBag.resultado = n1 + n2;
                break;

            case "Subtração":
                ViewBag.operadorAritmetico = '-';
                ViewBag.resultado = n1 - n2;
                break;

            case "Multiplicação":
                ViewBag.operadorAritmetico = '*';
                ViewBag.resultado = n1 * n2;
                break;

            case "Divisão":
                ViewBag.operadorAritmetico = '/';
                ViewBag.resultado = n1 / n2;
                break;
        }
    
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}