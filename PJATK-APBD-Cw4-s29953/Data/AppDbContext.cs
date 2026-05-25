using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw4_s29953.Models;

namespace PJATK_APBD_Cw4_s29953.Data;

public class AppDbContext : DbContext
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PCId);

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode);

        modelBuilder.Entity<ComponentManufacturer>()
            .Property(m => m.FoundationDate)
            .HasColumnType("date");

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PC { Id = 3, Name = "Creator Station", Weight = 9.8f, Warranty = 48, CreatedAt = new DateTime(2026, 3, 20, 10, 15, 0), Stock = 3 }
        );

        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "INT", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "NVD", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturer { Id = 3, Abbreviation = "KST", FullName = "Kingston Technology", FoundationDate = new DateOnly(1987, 10, 17) }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "CPU001", Name = "Intel Core i7", Description = "High performance processor", ComponentManufacturerId = 1, ComponentTypeId = 1 },
            new Component { Code = "GPU001", Name = "NVIDIA RTX 4070", Description = "Graphics card for gaming and creative work", ComponentManufacturerId = 2, ComponentTypeId = 2 },
            new Component { Code = "RAM001", Name = "Kingston Fury 16GB", Description = "DDR5 memory module", ComponentManufacturerId = 3, ComponentTypeId = 3 }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "RAM001", Amount = 2 },
            new PCComponent { PCId = 2, ComponentCode = "CPU001", Amount = 1 },
            new PCComponent { PCId = 2, ComponentCode = "RAM001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "CPU001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "GPU001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "RAM001", Amount = 4 }
        );
    }
}