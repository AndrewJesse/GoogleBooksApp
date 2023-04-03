using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System.Threading.Tasks;

namespace GoogleBooksApp.Services
{
    public class GoogleBooksApiClient
    {
        // The API key used for accessing the Google Books API
        private readonly string apiKey = "AIzaSyCIv33otYHsBVeQSgEE3_5SysFKQcGCIfQ";

        // A BooksService object used for making requests to the API
        private readonly BooksService booksService;

        // Constructor that initializes the BooksService object
        public GoogleBooksApiClient()
        {
            booksService = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "GoogleBooksApp",
            });
        }

        public async Task<Volumes> GetBooksAsync(string query, int startIndex = 0)
        {
            var request = booksService.Volumes.List(query);
            request.MaxResults = 5; // Set this to match the PageSize in HomeController
            request.StartIndex = startIndex;
            return await request.ExecuteAsync();
        }

    }
}
