using Microsoft.AspNetCore.Mvc;
using Google.Apis.Books.v1.Data; // Import the Google Books API data models
using GoogleBooksApp.Services; // Import the Google Books API client service
using GoogleBooksApp.Models.ViewModels;



namespace GoogleBooksApp.Controllers
{
    public class HomeController : Controller 
    {
        private readonly GoogleBooksApiClient googleBooksApiClient; 
        public int PageSize = 2;
        public HomeController() 
        {
            googleBooksApiClient = new GoogleBooksApiClient(); 
        }

        public async Task<IActionResult> Index(int productPage = 1)
        {
            var books = await googleBooksApiClient.GetBooksAsync("subject:thriller");
            var viewModel = new BooksListViewModel
            {
                Books = books.Items
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = books.TotalItems.GetValueOrDefault() // Replace this with the appropriate logic to get the total number of items
                }
            };

            return View(viewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}
