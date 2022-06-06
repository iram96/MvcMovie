using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Net;

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
            ImpiegatoConFile TempImpiegato = new ImpiegatoConFile()
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

        [HttpPost]
        [ValidateAntiForgeryToken]

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
                Photo = "/img/io.jpg",
                AlternateText = "Foto non disponibile"
            };
            return View(VeroImpiegato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult CreaSchedaConFoto(ImpiegatoConFile DatiImpiegato)
        {
            if (!ModelState.IsValid)
            {
                return View("CreaFormConFoto", DatiImpiegato);
            }

            //Devo prendere il file ricevuto dal client 
            //DatiImpiegato.File.CopyTo()
            //lo devo salvare sul file system
            //creo la scheda Nuova con il file salvato su File system (wwwroot)

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

            //creare folder se non c'è
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //prendi l'estensione del file
            FileInfo fileInfo = new FileInfo(DatiImpiegato.File.FileName);
            string fileName = DatiImpiegato.FullName + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                DatiImpiegato.File.CopyTo(stream);
            }

            string NomeImpiegato = DatiImpiegato.FullName.Split(" ")[0];
            string CognomeImpiegato = DatiImpiegato.FullName.Split(" ")[1];

            ImpiegatoConFile VeroImpiegato = new ImpiegatoConFile()
            {
                Id = DatiImpiegato.Id,
                FullName = DatiImpiegato.FullName,
                Gender = DatiImpiegato.Gender,
                City = DatiImpiegato.City,
                EmailAddress = NomeImpiegato + "." + CognomeImpiegato + "@email.com",
                PersonalWebSite = "www." + NomeImpiegato + "-" + CognomeImpiegato + ".com",
                Photo = "/Files/" + fileName,
                AlternateText = "Foto non disponibile"
            };
            return View(VeroImpiegato);
        }

        //  !!! PUT METHOD !!!



        public IActionResult CreaFormPut()
        {

            var request = (HttpWebRequest)WebRequest.Create("https://localhost:7088/Impiegato/InserisciDirigente");
            var postData = "NomeDir=" + Uri.EscapeDataString("Mario");
            postData += "&CognomeDir=" + Uri.EscapeDataString("Rossi");
            var data = System.Text.Encoding.ASCII.GetBytes(postData);

            request.Method = "PUT";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            //Invio dei dati al server
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            //Prendiamo la risposta
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            //Processiamo la risposta del server
            //e creiamo la view conseguentemente.
            //if(responseString == "Dirigente Inserito correttamente")
            EsitoOperazionePut Esito = new EsitoOperazionePut();
            Esito.sEsito = responseString;


            return View(Esito);
        }

        [HttpPut]
        public string InserisciDirigente()
        {
            string sAppo = Request.Method;
            if (sAppo == "PUT")
            {
                return "Dirigente Inserito Correttamente";

            }
            else
            {
                return "Errore Inserimento Dirigente";
            }
        }
    }
}
