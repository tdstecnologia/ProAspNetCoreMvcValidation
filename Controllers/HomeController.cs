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
        public ViewResult Agenda1(Compromisso appt) =>
        View("Completo", appt);

        [HttpPost]
        public ViewResult Agenda(Compromisso appt)
        {
            if (string.IsNullOrEmpty(appt.NomeCliente))
            {
                ModelState.AddModelError(nameof(appt.NomeCliente),
                "Informe seu nome");
            }
            if (ModelState.GetValidationState("Data")
            == ModelValidationState.Valid && DateTime.Now > appt.Data)
            {
                ModelState.AddModelError(nameof(appt.Data),
                "Informe uma data futura");
            }
            if (!appt.AceitaTermos)
            {
                ModelState.AddModelError(nameof(appt.AceitaTermos),
                "Você deve aceitar os termos");
            }

            if (ModelState.GetValidationState(nameof(appt.Data))
                == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.NomeCliente))
                == ModelValidationState.Valid
                && appt.NomeCliente.Equals("Alice", StringComparison.OrdinalIgnoreCase)
                && appt.Data.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Alice não pode ser agendada na segunda-feira");
            }

            if (ModelState.IsValid)
            {
                return View("Completo", appt);
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
