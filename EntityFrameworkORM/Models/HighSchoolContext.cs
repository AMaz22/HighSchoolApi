using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkORM.Models
{
    public partial class HighSchoolContext : DbContext
    {
        public HighSchoolContext()
        {
        }

        public HighSchoolContext(DbContextOptions<HighSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AveragesGrade> AveragesGrades { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectsCatalog> SubjectsCatalogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AveragesGrade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageGradeScore).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectCatalogId).HasColumnName("SubjectCatalogID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AveragesGrades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__AveragesG__Stude__35BCFE0A");

                entity.HasOne(d => d.SubjectCatalog)
                    .WithMany(p => p.AveragesGrades)
                    .HasForeignKey(d => d.SubjectCatalogId)
                    .HasConstraintName("FK__AveragesG__Subje__36B12243");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Catalogs)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Catalogs__ClassI__267ABA7A");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassCicle).HasMaxLength(25);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.NameOfClass).HasMaxLength(20);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GradeDate).HasColumnType("datetime");

                entity.Property(e => e.GradeScore).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubjectCatalogId).HasColumnName("SubjectCatalogID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Grades__StudentI__32E0915F");

                entity.HasOne(d => d.SubjectCatalog)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectCatalogId)
                    .HasConstraintName("FK__Grades__SubjectC__31EC6D26");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatalogId).HasColumnName("CatalogID");

                entity.Property(e => e.FullName).HasMaxLength(20);

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("FK__Students__Catalo__29572725");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SubjectName).HasMaxLength(20);
            });

            modelBuilder.Entity<SubjectsCatalog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CatalogId).HasColumnName("CatalogID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Catalog)
                    .WithMany(p => p.SubjectsCatalogs)
                    .HasForeignKey(d => d.CatalogId)
                    .HasConstraintName("FK__SubjectsC__Catal__2E1BDC42");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectsCatalogs)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__SubjectsC__Subje__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
