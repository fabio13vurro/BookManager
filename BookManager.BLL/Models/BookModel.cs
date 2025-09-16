using BookManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string? Description { get; set; }
        public ICollection<AuthorModel> Authors { get; } = new List<AuthorModel>();

        public ICollection<CategoryModel> Categories { get; } = new List<CategoryModel>();

    }
}
