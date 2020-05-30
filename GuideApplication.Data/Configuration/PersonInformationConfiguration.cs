using GuideApplication.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideApplication.Data.Configuration
{
    //BaseConfiguration yazılabilir
    //Tablolar arasındaki ilişkiler yazıldı
    public class PersonInformationConfiguration : IEntityTypeConfiguration<PersonInformation>
    {
        public void Configure(EntityTypeBuilder<PersonInformation> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id).UseIdentityColumn();

            builder
                .Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Persons");
        }
    }
}
