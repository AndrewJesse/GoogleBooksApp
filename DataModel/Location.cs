using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksApp
{
    public class Location
    {

        public long LocationId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = String.Empty;

        public IEnumerable<Person>? People { get; set; }
    }
}
