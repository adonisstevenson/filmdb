using filmdb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdb{

    public class FilmContext : DbContext
    {

        DbSet<FilmModel> Films {get; set;}
        string con = "Data Source=localhost:1433;Initial Catalog=filmdb;User Id=SA;Password=Szumarat1;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
        
    }

}