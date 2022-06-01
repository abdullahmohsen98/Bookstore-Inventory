using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Models
{
    public class Books
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]

        public string _id { get; set; }

        [Required(ErrorMessage = "Book Title is required")]
        
        [DisplayName("Book Title")]
        public string title { get; set; }

        [Required(ErrorMessage = "Book Description is required")]
        [DisplayName("Book Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "Book NOP is required")]
        [DisplayName("Number Of Pages")]
        public int bookQuantity { get; set; }

        [Required(ErrorMessage = "Book Category is required")]
        [DisplayName("Book Category")]
        public string category { get; set; }
        
        [Required(ErrorMessage = "Book Author is required")]
        [DisplayName("Book Author")]
        public string author { get; set; }

        [Required(ErrorMessage = "Book Price is required")]
        [DisplayName("Book Price")]
        public decimal price { get; set; }
    }
}