using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class CommunalWazeContext : DbContext
{
    public CommunalWazeContext()
    {
    }

    public CommunalWazeContext(DbContextOptions<CommunalWazeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportsCategory> ReportsCategories { get; set; }

    public virtual DbSet<SaveSearch> SaveSearches { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(" Server= DESKTOP-S16FV2M\\SQLEXPRESS; Database= CommunalWaze;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Hebrew_100_CI_AS");

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.CodeReport);

            entity.ToTable("reports");

            entity.Property(e => e.CodeReport).HasColumnName("code_report");
            entity.Property(e => e.Content)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.FormattedAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("formatted_address");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Lat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lng");
            entity.Property(e => e.Temporary).HasColumnName("temporary");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_reportsCategories");

            entity.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reports_users");
        });

        modelBuilder.Entity<ReportsCategory>(entity =>
        {
            entity.HasKey(e => e.IdCategory);

            entity.ToTable("reportsCategories");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.ColorCategory)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("color_category");
            entity.Property(e => e.NameCategory)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name_category");
            entity.Property(e => e.NameCategoryEn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name_category_en");
        });

        modelBuilder.Entity<SaveSearch>(entity =>
        {
            entity.HasKey(e => e.SearchId);

            entity.ToTable("saveSearch");

            entity.Property(e => e.SearchId).HasColumnName("search_id");
            entity.Property(e => e.FormattedAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("formatted_address");
            entity.Property(e => e.Lat)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("lat");
            entity.Property(e => e.Lng)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("lng");
            entity.Property(e => e.NameSearch)
                .HasMaxLength(30)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("name_search");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.SaveSearches)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_saveSearch_users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_user");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.EMail)
                .HasMaxLength(25)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("e_mail");
            entity.Property(e => e.FirstName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .UseCollation("Hebrew_CI_AS")
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
