using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.Entities.Mappings
{
    public class FatherMap : EntityTypeConfiguration<Father>
    {
        public FatherMap()
        {
                this.HasKey(x => x.Id);
                
                this.Property(x => x.Name).HasMaxLength(50).IsRequired();

            // Bire - Bir ilişki Örneği
            
        }
    }
}
