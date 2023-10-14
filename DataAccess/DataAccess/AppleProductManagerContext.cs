using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class AppleProductManagerContext : DbContext
    {
        public AppleProductManagerContext()
        {
        }

        public AppleProductManagerContext(DbContextOptions<AppleProductManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-85JP501Q;database=AppleProductManager;uid=sa;pwd=Chihai4242;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("accounts");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("fullname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("phone");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_account_type");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("account_type");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("date")
                    .HasColumnName("orderdate");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("money")
                    .HasColumnName("totalprice");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_accounts");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Productid)
                    .ValueGeneratedNever()
                    .HasColumnName("productid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Sold).HasColumnName("sold");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
