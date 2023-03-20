using Google.Apis.Books.v1.Data; // Import the Google Books API data models
using GoogleBooksApp.Services; // Import the Google Books API client service
using Microsoft.AspNetCore.Mvc; // Import the ASP.NET Core MVC library

namespace GoogleBooksApp.Controllers
{
    public class HomeController : Controller // Define a controller class named HomeController
    {
        private readonly GoogleBooksApiClient googleBooksApiClient; // Declare a field to hold an instance of the GoogleBooksApiClient class

        public HomeController() // Define a constructor method for the HomeController class
        {
            googleBooksApiClient = new GoogleBooksApiClient(); // Create a new instance of the GoogleBooksApiClient class and assign it to the googleBooksApiClient field
        }

        public async Task<IActionResult> Index() // Define a method named Index that returns an IActionResult
        {
            var books = await googleBooksApiClient.GetBooksAsync("subject:fiction"); // Call the GetBooksAsync method of the GoogleBooksApiClient instance to get a list of books
            return View(books.Items); // Pass the list of books to the View method and return the result as an IActionResult
        }
    }
}
