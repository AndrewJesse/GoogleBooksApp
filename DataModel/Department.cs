using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksApp
{
    public class Department
    {

        public long Departmentid { get; set; }
        public string Name { get; set; } = String.Empty;

        public IEnumerable<Person>? People { get; set; }
    }
}
