using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProAspNetCoreMvcValidation.Models;
using System;
using System.Diagnostics;

namespace ProAspNetCoreMvcValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() =>
        View("Agenda", new Compromisso { Data = DateTime.Now });

        [HttpPost]
        public ViewResult Agenda1(Compromisso compromisso) =>
        View("Completo", compromisso);

        [HttpPost]
        public ViewResult Agenda(Compromisso compromisso)
        {
            if (string.IsNullOrEmpty(compromisso.NomeCliente))
            {
                ModelState.AddModelError(nameof(compromisso.NomeCliente),
                "Informe seu nome");
            }
            if (ModelState.GetValidationState("Data")
            == ModelValidationState.Valid && DateTime.Now > compromisso.Data)
            {
                ModelState.AddModelError(nameof(compromisso.Data),
                "Informe uma data futura");
            }
            if (!compromisso.AceitaTermos)
            {
                ModelState.AddModelError(nameof(compromisso.AceitaTermos),
                "Você deve aceitar os termos");
            }

            if (ModelState.GetValidationState(nameof(compromisso.Data))
                == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(compromisso.NomeCliente))
                == ModelValidationState.Valid
                && compromisso.NomeCliente.Equals("Alice", StringComparison.OrdinalIgnoreCase)
                && compromisso.Data.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Alice não pode ser agendada na segunda-feira");
            }

            if (ModelState.IsValid)
            {
                return View("Completo", compromisso);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Compra()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Compra(Compra compra)
        {
            if (ModelState.IsValid)
            {
                return View("CompraConfirmado", compra);
            }
            else
            {
                return View(compra);
            }
            
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contato(Contato contato)
        {
            Debug.WriteLine("Invocando Método Contato...");
            if (ModelState.IsValid)
            {
                return View("ContatoConfirmado", contato);
            }
            else
            {
                return View(contato);
            }
        }

    }
}
