using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }
        
    }
}
