using Microsoft.EntityFrameworkCore;
using Lab.Models;

namespace Lab.Data
{
    /// <summary>
    /// Для нормальной интерптерации SQL таблиц в си шарпе.
    /// OnModelCreating нужен для интерпретации данных из одной таблицы в другую
    /// </summary>

    public class AppDbContext : DbContext
    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.IdPatients);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Doctor)
                .WithMany()
                .HasForeignKey(a => a.IdDoctor);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Patients> Patients { get; set; }
    
        public DbSet<Doctors> Doctors { get; set; }
    
        public DbSet<Specialties> Specialties { get; set; }
    
        public DbSet<Appointments> Appointments { get; set; }
    
        public DbSet<Visits> Visits { get; set; }
    
        public DbSet<Diagnoses> Diagnoses { get; set; }
    
        public DbSet<VisitDiagnoses> VisitDiagnoses { get; set; }
    }

}
