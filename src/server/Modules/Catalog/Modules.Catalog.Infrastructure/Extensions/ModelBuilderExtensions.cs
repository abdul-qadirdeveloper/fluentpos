﻿using System.Linq;
using FluentPOS.Modules.Catalog.Core.Entities;
using FluentPOS.Modules.Catalog.Core.Entities.ExtendedAttributes;
using FluentPOS.Shared.Core.Settings;
using Microsoft.EntityFrameworkCore;

namespace FluentPOS.Modules.Catalog.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyCatalogConfiguration(this ModelBuilder builder, PersistenceSettings persistenceOptions)
        {
            // build model for MSSQL and Postgres

            if (persistenceOptions.UseMsSql)
            {
                foreach (var property in builder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
                {
                    property.SetColumnType("decimal(23,2)");
                }
            }

            builder.Entity<Product>(entity =>
            {
                entity.ToTable(name: "Products");

                if (persistenceOptions.UseMsSql)
                {
                    entity.Property(p => p.Price)
                        .HasColumnType("decimal(23, 2)");
                    entity.Property(p => p.Cost)
                        .HasColumnType("decimal(23, 2)");
                    entity.Property(p => p.AlertQuantity)
                        .HasColumnType("decimal(23, 2)");
                }
            });

            builder.Entity<BrandExtendedAttribute>(entity =>
            {
                entity.ToTable("BrandExtendedAttributes");
            });

            builder.Entity<CategoryExtendedAttribute>(entity =>
            {
                entity.ToTable("CategoryExtendedAttributes");
            });

            builder.Entity<ProductExtendedAttribute>(entity =>
            {
                entity.ToTable("ProductExtendedAttributes");
            });
        }
    }
}