using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DBGeneration.Models.Mapping
{
    public class CustomerCommentsHistoryMap : EntityTypeConfiguration<CustomerCommentsHistory>
    {
        public CustomerCommentsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CustomerCommentsHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
        }
    }
}
