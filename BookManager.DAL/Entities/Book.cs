using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }
        public ICollection<Author> Authors { get; } = new List<Author>();

        public ICollection<Category> Categories { get; } = new List<Category>();
    }
}
