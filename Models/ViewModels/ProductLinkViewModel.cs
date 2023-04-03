// Models/ViewModels/BooksListViewModel.cs
using Google.Apis.Books.v1.Data;
using System.Collections.Generic;

namespace GoogleBooksApp.Models.ViewModels
{
    public class BooksListViewModel
    {
        public List<Volume>? Books { get; set; }
        public PagingInfo? PagingInfo { get; set; }
    }
}
