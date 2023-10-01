using First.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace First.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Name = "GRZEGORZ";
            ViewBag.Hour = DateTime.Now.Hour;
            ViewBag.powitanie = ViewBag.Hour < 17 ? "Dzień Dobry" : "Dobry wieczór";

            Dane[] osoby =
            {
                new Dane {Name= "Grzegorz", Surrname="Moskała"},
                new Dane {Name= "Jan", Surrname="Kowal"},
                new Dane {Name= "Mati", Surrname="Kowalski"},
                new Dane {Name= "Kuba", Surrname="Nowak"}
            };
            return View(osoby);
        }

        public IActionResult UrodzinyForm()
        {
            return View();
        }

        public IActionResult Urodziny(Urodziny urodziny)
        {
            ViewBag.powitanie = $"Witaj {urodziny.Imie},Lat: {DateTime.Now.Year-urodziny.Rok}";
            return View(urodziny);
        }

        public IActionResult Calculator(Calculator calculator)
        {
            if (calculator.Operation == "Dodaj")
            {
                double wynik = calculator.Number1 + calculator.Number2;
                ViewBag.wynik = $"{calculator.Number1} + {calculator.Number2} = {wynik}";
            }
            else if(calculator.Operation == "Odejmij")
            {
                double wynik = calculator.Number1 - calculator.Number2;
                ViewBag.wynik = $"{calculator.Number1} - {calculator.Number2} = {wynik}";
            }
            else if (calculator.Operation == "Pomnoz")
            {
                double wynik = calculator.Number1 * calculator.Number2;
                ViewBag.wynik = $"{calculator.Number1} * {calculator.Number2} = {wynik}";
            }
            else if (calculator.Operation == "Podziel")
            {
                double wynik = calculator.Number1 / calculator.Number2;
                ViewBag.wynik = $"{calculator.Number1} / {calculator.Number2} = {wynik}";
            }
            return View(calculator);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}