﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Niculae_AnaMaria_Lab2.Models
{
    public class Book
    {
        //public int ID { get; set; }
        //public string Title { get; set; }
        //public string Author { get; set; }
        //public decimal Price { get; set; }
        //public ICollection<Order> Orders { get; set; }

        public int ID { get; set; }
        public string Title { get; set; } 
        public decimal Price { get; set; }

        //[ForeignKey("Author")]
        public int AuthorID { get; set; } 

        public Author Author { get; set; }
    }
}
