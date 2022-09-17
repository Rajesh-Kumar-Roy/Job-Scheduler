using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TimeSchudlerApp.Models;
using TimeSchudlerApp.Repository;

namespace TimeSchudlerApp.DataConn
{
    public class HEllo: DbContext
    {
        private readonly DbContextOptions _options;
        public HEllo(DbContextOptions<HEllo> options): base(options)
            
        {
            _options = options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=DESKTOP-UFU9E0G\\SQLEXPRESS;Database=HEllo;Trusted_Connection=True;");

        }

        public DbSet<SchdularDemo> SchdularDemos { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
