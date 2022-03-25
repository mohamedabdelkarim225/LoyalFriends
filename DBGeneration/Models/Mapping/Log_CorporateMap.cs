using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DBGeneration.Models.Mapping
{
    public class Log_CorporateMap : EntityTypeConfiguration<Log_Corporate>
    {
        public Log_CorporateMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Log_Corporate");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CorporateID).HasColumnName("CorporateID");
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
            this.Property(t => t.Action).HasColumnName("Action");
            this.Property(t => t.ActionBy).HasColumnName("ActionBy");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");
        }
    }
}
