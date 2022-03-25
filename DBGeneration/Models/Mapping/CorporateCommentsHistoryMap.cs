using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DBGeneration.Models.Mapping
{
    public class CorporateCommentsHistoryMap : EntityTypeConfiguration<CorporateCommentsHistory>
    {
        public CorporateCommentsHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("CorporateCommentsHistory");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CorporateID).HasColumnName("CorporateID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ActionBy).HasColumnName("ActionBy");
            this.Property(t => t.ActionOn).HasColumnName("ActionOn");
        }
    }
}
