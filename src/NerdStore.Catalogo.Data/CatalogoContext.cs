﻿using Microsoft.EntityFrameworkCore;
using NerdStoreDemo.Catalogo.Domain;
using NerdStoreDemo.Core.Messages;
using NerdStoreDemo.Core.Data;
using Microsoft.CodeAnalysis.CSharp;

namespace NerdStoreDemo.Catalogo.Data;

public class CatalogoContext : DbContext, IUnitOfWork
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
    } 

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        return await base.SaveChangesAsync() > 0;
    }
}
