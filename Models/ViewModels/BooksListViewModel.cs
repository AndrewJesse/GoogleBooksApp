using System.Collections.Generic;

namespace YourAppNamespace.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<GoogleBook> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }

    public class GoogleBook
    {
        public string Id { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public string PublishedDate { get; set; }
        public ImageLinks ImageLinks { get; set; }
    }

    public class ImageLinks
    {
        public string Thumbnail { get; set; }
    }

    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)System.Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}