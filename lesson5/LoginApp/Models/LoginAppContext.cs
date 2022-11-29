using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginApp.Models;

public partial class LoginAppContext : DbContext
{
    public LoginAppContext()
    {
    }

    public LoginAppContext(DbContextOptions<LoginAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CT2E4DM\\SQL2022;Database=LoginApp; Trust Server Certificate=true;User Id=sa;Password=NTQ@solution01");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07042EB0F0");

            entity.ToTable("User");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
