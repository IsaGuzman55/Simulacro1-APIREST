using Microsoft.EntityFrameworkCore;
using Simulacro1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simulacro1.Services;

namespace Simulacro1.Data 
{
    public class SimulacroBaseContext : DbContext{
        public SimulacroBaseContext(DbContextOptions<SimulacroBaseContext> options) : base(options){

        }

        public DbSet<Author> Authors {get; set;}
        public DbSet<Editorial> Editorials {get; set;}
        public DbSet<Book> Books {get; set;}


    }
}