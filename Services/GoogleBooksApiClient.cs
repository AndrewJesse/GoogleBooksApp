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

        // Method that retrieves a list of books from the Google Books API based on a query
        public async Task<Volumes> GetBooksAsync(string query, int maxResults = 40)
        {
            // Create a request to search for volumes (books) with the specified query
            var request = booksService.Volumes.List(query);

            // Set the maximum number of results to be returned
            request.MaxResults = maxResults;

            // Execute the request and return the results
            return await request.ExecuteAsync();
        }
    }
}
