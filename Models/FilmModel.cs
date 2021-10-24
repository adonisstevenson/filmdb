using System;
using System.ComponentModel.DataAnnotations;

namespace filmdb.Models
{
    public class FilmModel
    {
        public int ID { get; set; }
        public string Title {get; set;}
        public int Year {get; set;}

    }
}
