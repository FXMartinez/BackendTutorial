using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YoutubeTutorial.Models
{
    public partial class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        {
        }

        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bag> Bags { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb; Database=InventoryDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bag>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Character>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnType("text");

                entity.Property(e => e.Type).HasColumnType("text");
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
