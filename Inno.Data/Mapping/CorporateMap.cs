using Inno.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inno.Data.Mapping
{
    public class CorporateMap : EntityTypeConfiguration<Corporate>
    {
        public CorporateMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Corporate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.AccountNumber).HasColumnName("AccountNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.CompanyAddress).HasColumnName("CompanyAddress");
            this.Property(t => t.CompanyType).HasColumnName("CompanyType");
            this.Property(t => t.LinesNumber).HasColumnName("LinesNumber");
            this.Property(t => t.AccountTypeID).HasColumnName("AccountTypeID");
            this.Property(t => t.CustomerStatusID).HasColumnName("CustomerStatusID");
            this.Property(t => t.RequestTypeID).HasColumnName("RequestTypeID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.ContactDate).HasColumnName("ContactDate");
            this.Property(t => t.RejectedReason).HasColumnName("RejectedReason");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
        }
    }
}
