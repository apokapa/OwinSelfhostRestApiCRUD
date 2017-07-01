using Apox.Models;
using System.Data.Entity;

namespace Datastore.EF.SQL
{
    public class GenericDbContext :DbContext
    {
        public GenericDbContext() : base("name=MyAppConString") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
