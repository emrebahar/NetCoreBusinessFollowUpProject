using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.SurName).HasMaxLength(100);

            builder.HasMany(I => I.Gorevler).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
