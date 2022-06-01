using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string ProvaParametri(string Nome, string Cognome)
        {
            string sAppo = "i dati inserirti sono: " + Nome + "e" + Cognome;
            string sQueryString = Request.QueryString.ToString();
            return sAppo;
        }

        List<Movie> ListaMovies = new List<Movie>();

        public void PrendiDati()
        {
            Movie PrimoMovie = new Movie()
            {
                Id = 1,
                Title = "When Harry Met Sally",
                ReleaseDate = DateTime.Parse("1989 - 2 - 12"),
                Genre = "Romantic Comedy",
                Price = 7.99M,
                Photo = "/img/io.jpg",
                AlternateText = "Pranaya Rout Photo not available"
            };

            Movie SecondoMovie = new Movie()
            {
                Id = 1,
                Title = "Mio Titolo",
                ReleaseDate = DateTime.Parse("1996 - 1 - 11"),
                Genre = "Action",
                Price = 7.99M,
                Photo = "/img/io.jpg",
                AlternateText = "Pranaya Rout Photo not available"
            };
            ListaMovies.Add(PrimoMovie);
            ListaMovies.Add(SecondoMovie);
        }

        public IActionResult ShowMovie()

        {
            PrendiDati();
            return View(ListaMovies);
        }
    }
}
