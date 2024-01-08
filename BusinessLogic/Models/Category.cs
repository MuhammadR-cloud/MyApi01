using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Edition { get; set; }
        public string PublisherName { get; set; }
        public DateTime YearPublished { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}

    }
}
