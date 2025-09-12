using BookManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }
        public ICollection<BookModel> Books { get; } = new List<BookModel>();

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
