using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDb
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        [Key]
        public int Code { get; set; }
    }
}
