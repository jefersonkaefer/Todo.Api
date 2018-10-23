using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infrastructure.Data.Mapping;

namespace Todo.Infrastructure.Data.Context
{
    public class MySqlContext<TEntity, TMap> : DbContext
        where TEntity : BaseEntity
        where TMap : IEntityTypeConfiguration<BaseEntity>
    {
        public DbSet<User> User { get; set; }
        public MySqlContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql("Server=[SERVIDOR];Port=[PORTA];Database=modelo;Uid=[USUARIO];Pwd=[SENHA]");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TEntity>(TMap.Configure);
        }
    }
}
