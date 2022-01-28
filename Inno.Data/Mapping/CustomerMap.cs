using Inno.Core.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inno.Data.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.FixedLine)
                .HasMaxLength(50);

            this.Property(t => t.NearestFixedLine)
                .HasMaxLength(50);

            this.Property(t => t.Mobile)
                .HasMaxLength(50);

            this.Property(t => t.NationalId)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.RequestNumber).HasColumnName("RequestNumber");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Central).HasColumnName("Central");
            this.Property(t => t.ContactDate).HasColumnName("ContactDate");
            this.Property(t => t.FixedLine).HasColumnName("FixedLine");
            this.Property(t => t.NearestFixedLine).HasColumnName("NearestFixedLine");
            this.Property(t => t.GovernorateID).HasColumnName("GovernorateID");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.District).HasColumnName("District");
            this.Property(t => t.SpecialMark).HasColumnName("SpecialMark");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.NationalId).HasColumnName("NationalId");
            this.Property(t => t.OfferID).HasColumnName("OfferID");
            this.Property(t => t.ServiceProviderID).HasColumnName("ServiceProviderID");
            this.Property(t => t.ServiceQuotaID).HasColumnName("ServiceQuotaID");
            this.Property(t => t.CustomerStatusID).HasColumnName("CustomerStatusID");
            this.Property(t => t.RouterTypeID).HasColumnName("RouterTypeID");
            this.Property(t => t.RouterDeliveryMethodID).HasColumnName("RouterDeliveryMethodID");
            this.Property(t => t.CustomerTypeID).HasColumnName("CustomerTypeID");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedOn).HasColumnName("ModifiedOn");
        }
    }
}
