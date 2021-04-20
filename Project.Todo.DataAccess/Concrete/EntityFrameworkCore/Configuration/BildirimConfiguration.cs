using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Configuration
{
    public class BildirimConfiguration : IEntityTypeConfiguration<Bildirim>
    {
        public void Configure(EntityTypeBuilder<Bildirim> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Aciklama).HasColumnType("ntext").IsRequired();

            builder.HasOne(I => I.AppUser).WithMany(I => I.Bildirimler).HasForeignKey(I => I.AppUserId);
        }
    }
}
