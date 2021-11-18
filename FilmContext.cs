using filmdb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmdb{

    public class FilmContext : DbContext
    {

        public DbSet<FilmModel> Films {get; set;}
        // string con = "Data Source=localhost:1433;Initial Catalog=filmdb;User Id=SA;Password=Szumarat1;";
        
        string connection_optional = @"Data Source=localhost; Initial Catalog=filmdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Server=localhost;Database=filmdb;User Id=SA;Password=Szumarat1;";
            string connection_2 = @"Server=localhost,1433;Database=filmdb;User Id=SA;Password=Szumarat1;";

            optionsBuilder.UseSqlServer(connection_2);
        }
        
    }

}