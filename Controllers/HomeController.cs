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
        View("MakeBooking", new Appointment { Date = DateTime.Now });

        [HttpPost]
        public ViewResult MakeBooking1(Appointment appt) =>
        View("Completed", appt);

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError(nameof(appt.ClientName),
                "Please enter your name");
            }
            if (ModelState.GetValidationState("Date")
            == ModelValidationState.Valid && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError(nameof(appt.Date),
                "Please enter a date in the future");
            }
            if (!appt.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appt.TermsAccepted),
                "You must accept the terms");
            }

            if (ModelState.GetValidationState(nameof(appt.Date))
                == ModelValidationState.Valid
                && ModelState.GetValidationState(nameof(appt.ClientName))
                == ModelValidationState.Valid
                && appt.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase)
                && appt.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("",
                "Joe cannot book appointments on Mondays");
            }

            if (ModelState.IsValid)
            {
                return View("Completed", appt);
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
