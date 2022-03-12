using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QUIZ.Models
{
    public partial class QUIZContext : DbContext
    {
        public QUIZContext()
        {
        }

        public QUIZContext(DbContextOptions<QUIZContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=QuizSKP.mssql.somee.com;Initial Catalog=QuizSKP;Integrated Security=False;Persist Security Info=False;User ID=asraj23_SQLLogin_1;Password=hqjjannu4f");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.CorrectAnswer)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Option4)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_ToCategory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
