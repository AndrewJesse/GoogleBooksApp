using Google.Apis.Books.v1.Data;
using GoogleBooksApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoogleBooksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly GoogleBooksApiClient googleBooksApiClient;

        public HomeController()
        {
            googleBooksApiClient = new GoogleBooksApiClient();
        }

        public async Task<IActionResult> Index()
        {
            var books = await googleBooksApiClient.GetBooksAsync("subject:fiction");
            return View(books.Items);
        }
    }
}
