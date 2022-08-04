using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3.Components
{
    public class Customer
    {
        public string nameEnglish { get; set; }
        public string contact { get; set; }
    }


    public class GraphQL
    {
        public List<Customer> nodes { get; set; }
    }
    public class GraphQL2
    {
        public GraphQL customers { get; set; }
    }
}
