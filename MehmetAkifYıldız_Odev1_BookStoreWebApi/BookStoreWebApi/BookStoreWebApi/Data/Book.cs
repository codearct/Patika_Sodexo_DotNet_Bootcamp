using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApi.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Translator { get; set; }
        public int PageNumbers { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
    }
}
