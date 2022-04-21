﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.DataAccessLayer.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //fluent api
            builder.HasKey(x => x.Id);
            //builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.ToTable("tblCategories");
            
        }
    }
}
