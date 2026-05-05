using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PerpustakaanAPP.Data.Access.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<AreaBook> AreaBooks { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Racks> Racks { get; set; }
        public virtual DbSet<Storages> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaBook>(entity =>
            {
                entity.HasKey(e => e.Areaid).HasName("PK__AREABOOKS__BBFED9530576C52C");
                entity.ToTable("AREABOOKS");

                entity.Property(e => e.Areaid).HasColumnName("AREAID");
                entity.Property(e => e.Areacode).HasMaxLength(50).HasColumnName("AREACODE");
                entity.Property(e => e.Areaname).HasMaxLength(200).HasColumnName("AREANAME");
                entity.Property(e => e.Areadescription).HasMaxLength(250).HasColumnName("AREADESCRIPTION");
                entity.Property(e => e.Isactive).HasDefaultValue(true).HasColumnName("ISACTIVE");
                entity.Property(e => e.Createdate).HasColumnType("datetime").HasColumnName("CREATEDATE");
                entity.Property(e => e.Createby).HasMaxLength(100).HasColumnName("CREATEBY");
                entity.Property(e => e.Modifydate).HasColumnType("datetime").HasColumnName("MODIFYDATE");
                entity.Property(e => e.Modifyby).HasMaxLength(100).HasColumnName("MODIFYBY");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.Bookid).HasName("PK__BOOKS__6E1C5AE3D2A1AB08");
                entity.ToTable("BOOKS");

                entity.Property(e => e.Bookid).HasColumnName("BOOKID");
                entity.Property(e => e.Author).HasMaxLength(50).HasColumnName("AUTHOR");
                entity.Property(e => e.Bookname).HasMaxLength(50).HasColumnName("BOOKNAME");
                entity.Property(e => e.Description).HasMaxLength(500).HasColumnName("DESCRIPTION");
                entity.Property(e => e.Pagebook).HasColumnName("PAGEBOOK");
                entity.Property(e => e.Publisher).HasMaxLength(50).HasColumnName("PUBLISHER");
                entity.Property(e => e.Releasedate).HasColumnName("RELEASEDATE");
            });

            modelBuilder.Entity<Racks>(entity =>
            {
                entity.HasKey(e => e.Rackid).HasName("PK__RACKS__40D623AD2D62BDD8");
                entity.ToTable("RACKS");

                entity.HasIndex(e => e.Rackcode, "UQ__RACKS__024E9E6C6EE84207").IsUnique();

                entity.Property(e => e.Rackid).HasColumnName("RACKID");
                entity.Property(e => e.Areaid).HasColumnName("AREAID");
                entity.Property(e => e.Capacity).HasColumnName("CAPACITY");
                entity.Property(e => e.Rackcode).HasMaxLength(50).HasColumnName("RACKCODE");
                entity.Property(e => e.Rackname).HasMaxLength(200).HasColumnName("RACKNAME");
                entity.Property(e => e.Rackdescription).HasMaxLength(255).HasColumnName("RACKDESCRIPTION");
                entity.Property(e => e.Isactive).HasDefaultValue(true).HasColumnName("ISACTIVE");
                entity.Property(e => e.Createdate).HasColumnType("datetime").HasColumnName("CREATEDATE");
                entity.Property(e => e.Createby).HasMaxLength(100).HasColumnName("CREATEBY");
                entity.Property(e => e.Modifydate).HasColumnType("datetime").HasColumnName("MODIFYDATE");
                entity.Property(e => e.Modifyby).HasMaxLength(100).HasColumnName("MODIFYBY");

                entity.HasOne(d => d.Area).WithMany(p => p.Racks)
                    .HasForeignKey(d => d.Areaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RACKS__AREAID__60A75C0F");
            });

            modelBuilder.Entity<Storages>(entity =>
            {
                entity.HasKey(e => e.Storageid).HasName("PK__STORAGES__4D028923B43F6B26");
                entity.ToTable("STORAGES");

                entity.Property(e => e.Storageid).HasColumnName("STORAGEID");
                entity.Property(e => e.Bookid).HasColumnName("BOOKID");
                entity.Property(e => e.Rackid).HasColumnName("RACKID");

                entity.HasOne(d => d.BooksNavigation).WithMany(p => p.Storages)
                    .HasForeignKey(d => d.Bookid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STORAGES__BOOKS__656C112C");

                entity.HasOne(d => d.RacksNavigation).WithMany(p => p.Storages)
                    .HasForeignKey(d => d.Rackid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STORAGES__RACKS__66603565");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        // Audit otomatis
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => (e.Entity is AreaBook || e.Entity is Racks) &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.Entity is Books book)
                {
                    if (entry.State == EntityState.Added)
                    {
                        book.Createdate = DateTime.Now;
                        book.Createby = Environment.UserName;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        book.Modifydate = DateTime.Now;
                        book.Modifyby = Environment.UserName;
                    }
                }

                if (entry.Entity is AreaBook area)
                {
                    if (entry.State == EntityState.Added)
                    {
                        area.Createdate = DateTime.Now;
                        area.Createby = Environment.UserName; 
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        area.Modifydate = DateTime.Now;
                        area.Modifyby = Environment.UserName;
                    }
                }

                if (entry.Entity is Racks rack)
                {
                    if (entry.State == EntityState.Added)
                    {
                        rack.Createdate = DateTime.Now;
                        rack.Createby = Environment.UserName;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        rack.Modifydate = DateTime.Now;
                        rack.Modifyby = Environment.UserName;
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
