using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ImpiegatoController : Controller
    {
        public IActionResult CreaForm()
        {
            Impiegato TempImpiegato = new Impiegato()
            {
                Id = 1,
                FullName = "",
                Gender = "",
                City = "",
                EmailAddress = "",
                PersonalWebSite = "",
                Photo = "",
                AlternateText = ""
            };
            return View(TempImpiegato);
        }

        public IActionResult CreaFormConFoto()
        {
            Impiegato TempImpiegato = new Impiegato()
            {
                Id = 1,
                FullName = "",
                Gender = "",
                City = "",
                EmailAddress = "",
                PersonalWebSite = "",
                Photo = "",
                AlternateText = ""
            };
            return View(TempImpiegato);
        }

        public IActionResult CreaScheda(Impiegato DatiImpiegato)
        {

            string NomeImpiegato = DatiImpiegato.FullName.Split(" ")[0];
            string CognomeImpiegato = DatiImpiegato.FullName.Split(" ")[1];

            Impiegato VeroImpiegato = new Impiegato()
            {
                Id = DatiImpiegato.Id,
                FullName = DatiImpiegato.FullName,
                Gender = DatiImpiegato.Gender,
                City = DatiImpiegato.City,
                EmailAddress = NomeImpiegato + "." + CognomeImpiegato + "@email.com",
                PersonalWebSite = "www." + NomeImpiegato + "-" + CognomeImpiegato + ".com",
                Photo = "",
                AlternateText = "Foto non disponibile"
            };
            return View(VeroImpiegato);
        }

        public IActionResult CreaSchedaConFoto(Impiegato DatiImpiegato)
        {

            string NomeImpiegato = DatiImpiegato.FullName.Split(" ")[0];
            string CognomeImpiegato = DatiImpiegato.FullName.Split(" ")[1];

            Impiegato VeroImpiegato = new Impiegato()
            {
                Id = DatiImpiegato.Id,
                FullName = DatiImpiegato.FullName,
                Gender = DatiImpiegato.Gender,
                City = DatiImpiegato.City,
                EmailAddress = NomeImpiegato + "." + CognomeImpiegato + "@email.com",
                PersonalWebSite = "www." + NomeImpiegato + "-" + CognomeImpiegato + ".com",
                Photo = "",
                AlternateText = "Foto non disponibile"
            };
            return View(VeroImpiegato);
        }
    }
}
