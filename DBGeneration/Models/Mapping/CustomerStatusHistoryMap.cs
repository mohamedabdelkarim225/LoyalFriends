using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DBGeneration.Models.Mapping
{
    public class CustomerStatusHistoryMap : EntityTypeConfiguration<CustomerStatusHistory>
    {
        public CustomerStatusHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CustomerStatusHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CustomerStatusID).HasColumnName("CustomerStatusID");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ActionBy).HasColumnName("ActionBy");
            this.Property(t => t.ActionOn).HasColumnName("ActionOn");
        }
    }
}
