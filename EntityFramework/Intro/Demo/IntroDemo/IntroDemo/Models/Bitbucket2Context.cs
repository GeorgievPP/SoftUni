using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IntroDemo.Models
{
    public partial class Bitbucket2Context : DbContext
    {
        public Bitbucket2Context()
        {
        }

        public Bitbucket2Context(DbContextOptions<Bitbucket2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Commit> Commits { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<RepositoriesContributor> RepositoriesContributors { get; set; }
        public virtual DbSet<Repository> Repositories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Bitbucket2;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Commit>(entity =>
            {
                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Contributor)
                    .WithMany(p => p.Commits)
                    .HasForeignKey(d => d.ContributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commits__Contrib__571DF1D5");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Commits)
                    .HasForeignKey(d => d.IssueId)
                    .HasConstraintName("FK__Commits__IssueId__5535A963");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.Commits)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Commits__Reposit__5629CD9C");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Commit)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CommitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Files__CommitId__5AEE82B9");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Files__ParentId__59FA5E80");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.Property(e => e.IssueStatus)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Assignee)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.AssigneeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__Assignee__52593CB8");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Issues__Reposito__5165187F");
            });

            modelBuilder.Entity<RepositoriesContributor>(entity =>
            {
                entity.HasKey(e => new { e.RepositoryId, e.ContributorId })
                    .HasName("PK__Reposito__39C28C90AA8003A5");

                entity.HasOne(d => d.Contributor)
                    .WithMany(p => p.RepositoriesContributors)
                    .HasForeignKey(d => d.ContributorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Repositor__Contr__4E88ABD4");

                entity.HasOne(d => d.Repository)
                    .WithMany(p => p.RepositoriesContributors)
                    .HasForeignKey(d => d.RepositoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Repositor__Repos__4D94879B");
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
