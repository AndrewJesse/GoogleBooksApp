using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using System.Threading.Tasks;

namespace GoogleBooksApp.Services
{
    public class GoogleBooksApiClient
    {
        private readonly string apiKey = "AIzaSyCIv33otYHsBVeQSgEE3_5SysFKQcGCIfQ";
        private readonly BooksService booksService;

        public GoogleBooksApiClient()
        {
            booksService = new BooksService(new BaseClientService.Initializer
            {
                ApiKey = apiKey,
                ApplicationName = "GoogleBooksApp",
            });
        }

        public async Task<Volumes> GetBooksAsync(string query, int maxResults = 40)
        {
            var request = booksService.Volumes.List(query);
            request.MaxResults = maxResults;
            return await request.ExecuteAsync();
        }
    }
}
