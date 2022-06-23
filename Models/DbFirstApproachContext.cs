using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TRAIN_MASTER_WITH_DB_1ST_APPROACH.Models
{
    public partial class DbFirstApproachContext : DbContext
    {
        public DbFirstApproachContext()
        {
        }

        public DbFirstApproachContext(DbContextOptions<DbFirstApproachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Trainday> Traindays { get; set; } = null!;
        public virtual DbSet<Traindetail> Traindetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3CUF5I;Initial Catalog=DbFirstApproach;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainday>(entity =>
            {
                entity.HasKey(e => e.TrainNo)
                    .HasName("PK__TRAINDAY__8ED1D8CD916F3FA3");

                entity.ToTable("TRAINDAYS");

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.Property(e => e.Friday).HasColumnName("FRIDAY");

                entity.Property(e => e.Monday).HasColumnName("MONDAY");

                entity.Property(e => e.Saturday).HasColumnName("SATURDAY");

                entity.Property(e => e.Sunday).HasColumnName("SUNDAY");

                entity.Property(e => e.Thursday).HasColumnName("THURSDAY");

                entity.Property(e => e.Tuesday).HasColumnName("TUESDAY");

                entity.Property(e => e.Wednesday).HasColumnName("WEDNESDAY");
            });

            modelBuilder.Entity<Traindetail>(entity =>
            {
                entity.HasKey(e => e.TrainNo)
                    .HasName("PK__TRAINDET__8ED1D8CD1B6FC7BC");

                entity.ToTable("TRAINDETAILS");

                entity.Property(e => e.TrainNo).ValueGeneratedNever();

                entity.Property(e => e.FromStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToStation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
