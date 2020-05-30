using GuideApplication.Core.Models;
using GuideApplication.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideApplication.Data
{
    public class GuideApplicationDbContext : DbContext
    {
        public DbSet<PersonInformation> Persons { get; set; }

        public GuideApplicationDbContext(DbContextOptions<GuideApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder
                .ApplyConfiguration(new PersonInformationConfiguration());
        }
    }
}
