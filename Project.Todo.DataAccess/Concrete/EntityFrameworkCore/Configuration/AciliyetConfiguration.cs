using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Todo.DataAccess.Concrete.EntityFrameworkCore.Configuration
{
    public class AciliyetConfiguration : IEntityTypeConfiguration<Aciliyet>
    {
        public void Configure(EntityTypeBuilder<Aciliyet> builder)
        {
            builder.Property(I => I.Tanim).HasMaxLength(100);
        }
    }
}
