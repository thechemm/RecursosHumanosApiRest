using Microsoft.EntityFrameworkCore;
using System.Data;
using RecursoshumanosApiRest.Models;

namespace RecursoshumanosApiRest.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
    }
}
