using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace GoogleBooksApp.Services
{
    public class GoogleBooksApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly BooksService _booksService;
        
        public GoogleBooksApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiKey = _configuration["GoogleBooksApiKey"];

            _booksService = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "GoogleBooksApp",
            });
        }

        public async Task<Volumes> GetBooksAsync(string query, int startIndex = 0)
        {
            var request = _booksService.Volumes.List(query);
            request.MaxResults = 5; // Set this to match the PageSize in HomeController
            request.StartIndex = startIndex;
            return await request.ExecuteAsync();
        }
    }
}