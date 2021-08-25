using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace API.Models
{
    public partial class DB_Sector_ZonaContext : DbContext
    {
        public IConfiguration Configuration { get;  }

        public DB_Sector_ZonaContext()
        {
        }

        public DB_Sector_ZonaContext(DbContextOptions<DB_Sector_ZonaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPersona> TblPersonas { get; set; }
        public virtual DbSet<TblSector> TblSectors { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }
        public virtual DbSet<TblZona> TblZonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-UMP3I6SV;Database=DB_Sector_Zona;Trusted_Connection=True");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblPersona>(entity =>
            {
                entity.HasKey(e => e.CodPersona)
                    .HasName("PK__Inscripc__40188ACADD9977E9");

                entity.ToTable("tbl_persona");

                entity.Property(e => e.CodPersona)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_persona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.FecNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fec_nacimiento");

                entity.Property(e => e.NomPersona)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nom_persona");

                entity.Property(e => e.Sueldo)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("sueldo");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.TblPersonas)
                    .HasForeignKey(d => d.CodSector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persona_sector");

                entity.HasOne(d => d.CodZonaNavigation)
                    .WithMany(p => p.TblPersonas)
                    .HasForeignKey(d => d.CodZona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persona_zona");
            });

            modelBuilder.Entity<TblSector>(entity =>
            {
                entity.HasKey(e => e.CodSector);

                entity.ToTable("tbl_sector");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.DesSector)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("des_sector");
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.CodUsuario);

                entity.ToTable("tbl_usuario");

                entity.Property(e => e.CodUsuario).HasColumnName("cod_usuario");

                entity.Property(e => e.NomUsuario)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nom_usuario");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<TblZona>(entity =>
            {
                entity.HasKey(e => e.CodZona);

                entity.ToTable("tbl_zona");

                entity.Property(e => e.CodZona).HasColumnName("cod_zona");

                entity.Property(e => e.CodSector).HasColumnName("cod_sector");

                entity.Property(e => e.DesZona)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("des_zona");

                entity.HasOne(d => d.CodSectorNavigation)
                    .WithMany(p => p.TblZonas)
                    .HasForeignKey(d => d.CodSector)
                    .HasConstraintName("FK_tbl_sector");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
