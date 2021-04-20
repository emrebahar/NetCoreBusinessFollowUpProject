using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Configuration
{
    public class RaporConfiguration : IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Tanim).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Detay).HasColumnType("ntext");

            builder.HasOne(I => I.Gorev).WithMany(I => I.Raporlar).HasForeignKey(I => I.GorevId);
        }
    }
}
