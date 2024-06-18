using EntityFramework_CodeFirst.Entities;
using EntityFramework_CodeFirst.Entities.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.Contexts
{
    public class ExampleEFDBContext : DbContext 
    {
        public ExampleEFDBContext() : base("ExampleEFDBContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new FatherMap());
        }

        DbSet<Father> Fathers { get; set; }
        DbSet<Mother> Mothers { get; set; }
    }
}
