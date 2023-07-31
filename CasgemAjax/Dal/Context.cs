using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CasgemAjax.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AKOHCIC\\SQLEXPRESS;initial Catalog=CasgemAjax;integrated Security=true");
        }
        public DbSet<Costumer> Costumers { get; set; }
    }

}