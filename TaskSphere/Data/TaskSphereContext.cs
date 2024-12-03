using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskSphere.Models;
using Task = TaskSphere.Models.Task;

namespace TaskSphere.Data;

public partial class TaskSphereContext : DbContext
{
    public TaskSphereContext()
    {
    }

    public TaskSphereContext(DbContextOptions<TaskSphereContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TaskSphere;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2B96118CC6");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryDescription).HasMaxLength(50);
            entity.Property(e => e.CategoryName).HasMaxLength(35);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D187DF426A");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.TaskDescription).HasMaxLength(255);
            entity.Property(e => e.TaskName).HasMaxLength(35);
            entity.Property(e => e.TaskStatus).HasDefaultValue(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__CategoryI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
