using HospitalManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Department> Departments { get; set; } = null!;
		public DbSet<Doctor> Doctors { get; set; } = null!;
		public DbSet<Patient> Patients { get; set; } = null!;
		public DbSet<Registration> Registrations { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Department - Doctor (1-M)
			modelBuilder.Entity<Doctor>()
				.HasOne(d => d.Department)
				.WithMany(dep => dep.Doctors)
				.HasForeignKey(d => d.DepartmentId);

			//Registration
			modelBuilder.Entity<Registration>()
				.HasKey(r =>  r.Id);
			modelBuilder.Entity<Registration>()
				.HasOne(r => r.Patient)
				.WithMany(p => p.Registrations)
				.HasForeignKey(r => r.PatientId);
			modelBuilder.Entity<Registration>()
				.HasOne(r => r.Doctor)
				.WithMany(d => d.Registrations)
				.HasForeignKey(r => r.DoctorId);
			modelBuilder.Entity<Registration>()
				.Property(r => r.CreatedAt)
				.HasDefaultValueSql("NOW()");

			//User.Role
			modelBuilder.Entity<User>()
				.Property(u => u.Role)
				.HasConversion<string>()
				.HasMaxLength(20);
		}
	}
}
