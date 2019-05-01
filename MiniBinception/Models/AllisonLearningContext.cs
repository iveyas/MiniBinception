using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiniBinception.Models
{
    public partial class AllisonLearningContext : DbContext
    {
        public AllisonLearningContext()
        {
        }

        public AllisonLearningContext(DbContextOptions<AllisonLearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bin> Bin { get; set; }
        public virtual DbSet<BinAlias> BinAlias { get; set; }
        public virtual DbSet<BinAliasFamily> BinAliasFamily { get; set; }
        public virtual DbSet<BinHierarchy> BinHierarchy { get; set; }
        public virtual DbSet<BinItem> BinItem { get; set; }
        public virtual DbSet<BinItemRef> BinItemRef { get; set; }
        public virtual DbSet<BinType> BinType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=AIVEY-L;Database=AllisonLearning;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Bin>(entity =>
            {
                entity.Property(e => e.Activation)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('1970-01-01')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.Termination)
                    .HasColumnType("date")
                    .HasDefaultValueSql("('2999-12-31')");
            });

            modelBuilder.Entity<BinAlias>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.HasOne(d => d.BinAliasFamily)
                    .WithMany(p => p.BinAlias)
                    .HasForeignKey(d => d.BinAliasFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinAlias_BinAliasFamily");

                entity.HasOne(d => d.Bin)
                    .WithMany(p => p.BinAlias)
                    .HasForeignKey(d => d.BinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinAlias_Bin");
            });

            modelBuilder.Entity<BinAliasFamily>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");
            });

            modelBuilder.Entity<BinHierarchy>(entity =>
            {
                entity.HasKey(e => new { e.ParentId, e.BinId });

                entity.Property(e => e.BinHierarchyId).ValueGeneratedOnAdd();

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.HasOne(d => d.Bin)
                    .WithMany(p => p.BinHierarchyBin)
                    .HasForeignKey(d => d.BinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinHierarchy_Bin");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.BinHierarchyParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinHierarchy_Bin1");
            });

            modelBuilder.Entity<BinItem>(entity =>
            {
                entity.Property(e => e.ItemType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.Uic)
                    .HasColumnName("UIC")
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<BinItemRef>(entity =>
            {
                entity.HasKey(e => e.BinItemRefId)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.HasOne(d => d.Bin)
                    .WithMany(p => p.BinItemRef)
                    .HasForeignKey(d => d.BinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinItemRef_Bin");

                entity.HasOne(d => d.BinItem)
                    .WithMany(p => p.BinItemRef)
                    .HasForeignKey(d => d.BinItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BinItemRef_BinItem");
            });

            modelBuilder.Entity<BinType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SysCreated).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysCreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.SysLastModified).HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.SysLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_name())");
            });
        }
    }
}
