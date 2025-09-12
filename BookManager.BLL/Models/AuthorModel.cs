using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Models
{
    internal class AuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
