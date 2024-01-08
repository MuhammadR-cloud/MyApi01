using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public string BookName { get; set; }
        public int TotalPages { get; set; }
        public string AuthorName1 { get; set; }
        public string AuthorName2 { get; set;}
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}

    }
}
