using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NewspaperSubscription.Models
{
    public partial class NewsSubDBContext : DbContext
    {
        public NewsSubDBContext()
        {
        }

        public NewsSubDBContext(DbContextOptions<NewsSubDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerCredential> CustomerCredentials { get; set; } = null!;
        public virtual DbSet<NewsPaper> NewsPapers { get; set; } = null!;
        public virtual DbSet<Subscription> Subscriptions { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        public virtual DbSet<VendorCredential> VendorCredentials { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=NewsSubDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Admin__F3DBC573AE7AA3F1");

                entity.ToTable("Admin");

                entity.Property(e => e.Username)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cityname");

                entity.Property(e => e.Citystate)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("citystate");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Customeraddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customeraddress");

                entity.Property(e => e.Customercity).HasColumnName("customercity");

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customername");

                entity.HasOne(d => d.CustomercityNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Customercity)
                    .HasConstraintName("FK__Customers__custo__300424B4");
            });

            modelBuilder.Entity<CustomerCredential>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Customer__F3DBC573F2FBE04C");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.CustomerCredentials)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK__CustomerC__custo__32E0915F");
            });

            modelBuilder.Entity<NewsPaper>(entity =>
            {
                entity.Property(e => e.Newspaperid).HasColumnName("newspaperid");

                entity.Property(e => e.Monthlysubscription).HasColumnName("monthlysubscription");

                entity.Property(e => e.Newspaperlanguage)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("newspaperlanguage");

                entity.Property(e => e.Newspapername)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("newspapername");

                entity.Property(e => e.Newspaperprice).HasColumnName("newspaperprice");

                entity.Property(e => e.Weeklysubscription).HasColumnName("weeklysubscription");

                entity.Property(e => e.Yearlysubscription).HasColumnName("yearlysubscription");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.Subscriptionid).HasColumnName("subscriptionid");

                entity.Property(e => e.Customer).HasColumnName("customer");

                entity.Property(e => e.Newspaper).HasColumnName("newspaper");

                entity.Property(e => e.Subscriptionstartdate)
                    .HasColumnType("date")
                    .HasColumnName("subscriptionstartdate");

                entity.Property(e => e.Subscriptiontype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("subscriptiontype");

                entity.Property(e => e.Vendor).HasColumnName("vendor");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.Customer)
                    .HasConstraintName("FK__Subscript__custo__44FF419A");

                entity.HasOne(d => d.NewspaperNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.Newspaper)
                    .HasConstraintName("FK__Subscript__newsp__45F365D3");

                entity.HasOne(d => d.VendorNavigation)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.Vendor)
                    .HasConstraintName("FK__Subscript__vendo__46E78A0C");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Vendorid).HasColumnName("vendorid");

                entity.Property(e => e.Vendorcity).HasColumnName("vendorcity");

                entity.Property(e => e.Vendorname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("vendorname");

                entity.HasOne(d => d.VendorcityNavigation)
                    .WithMany(p => p.Vendors)
                    .HasForeignKey(d => d.Vendorcity)
                    .HasConstraintName("FK__Vendors__vendorc__286302EC");
            });

            modelBuilder.Entity<VendorCredential>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__VendorCr__F3DBC5734BE9ECE1");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Vendor).HasColumnName("vendor");

                entity.HasOne(d => d.VendorNavigation)
                    .WithMany(p => p.VendorCredentials)
                    .HasForeignKey(d => d.Vendor)
                    .HasConstraintName("FK__VendorCre__vendo__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
