using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

using BookManager.Interfaces;
using BookManager.Models;

namespace BookManager.Models
{
    public class BookContext : DbContext
    {
        public BookContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Book> Books { get; set; }
    }

    [Table("Books")]
    public class Book : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool IsEbook
        {
            get;
            set;
        }

        
    }
}