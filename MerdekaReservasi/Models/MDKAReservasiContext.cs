using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MerdekaReservasi.Models
{
    public partial class MDKAReservasiContext : DbContext
    {
        public MDKAReservasiContext()
        {
        }

        public MDKAReservasiContext(DbContextOptions<MDKAReservasiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblMRuangan> TblMRuangans { get; set; }
        public virtual DbSet<TblMStatus> TblMStatuses { get; set; }
        public virtual DbSet<TblTReservasi> TblTReservasis { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(local);Database=MDKAReservasi;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblMRuangan>(entity =>
            {
                entity.HasKey(e => e.RuanganPk);

                entity.ToTable("tblM_Ruangan");

                entity.Property(e => e.RuanganPk).HasColumnName("Ruangan_PK");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NamaRuangan).HasMaxLength(200);

                entity.Property(e => e.StatusFk).HasColumnName("Status_FK");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMStatus>(entity =>
            {
                entity.HasKey(e => e.StatusPk);

                entity.ToTable("tblM_Status");

                entity.Property(e => e.StatusPk).HasColumnName("Status_PK");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NamaStatus).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTReservasi>(entity =>
            {
                entity.HasKey(e => e.ReservasiPk);

                entity.ToTable("tblT_Reservasi");

                entity.Property(e => e.ReservasiPk).HasColumnName("Reservasi_PK");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RuanganFk).HasColumnName("Ruangan_FK");

                entity.Property(e => e.TanggalReservasi).HasColumnType("date");

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
