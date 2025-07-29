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
		public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<TimeSlot> TimeSlots { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Department - Doctor (1-M)
			modelBuilder.Entity<Doctor>()
				.HasOne(d => d.Department)
				.WithMany(dep => dep.Doctors)
				.HasForeignKey(d => d.DepartmentId);


            //Department
            modelBuilder.Entity<Department>()
                .HasData(
                    new Department { Id = 1, Name = "Acil Servis" },
                    new Department { Id = 2, Name = "Ağız ve Diş Sağlığı" },
                    new Department { Id = 3, Name = "Aile Hekimliği" },
                    new Department { Id = 4, Name = "Anesteziyoloji ve Reanimasyon" },
                    new Department { Id = 5, Name = "Beyin ve Sinir Cerrahisi" },
                    new Department { Id = 6, Name = "Biyokimya" },
                    new Department { Id = 7, Name = "Çocuk Alerjisi" },
                    new Department { Id = 8, Name = "Çocuk Cerrahisi" },
                    new Department { Id = 9, Name = "Çocuk Endokrinolojisi" },
                    new Department { Id = 10, Name = "Çocuk Gastroenterolojisi" },
                    new Department { Id = 11, Name = "Çocuk Hematolojisi" },
                    new Department { Id = 12, Name = "Çocuk Kardiyolojisi" },
                    new Department { Id = 13, Name = "Çocuk Nefrolojisi" },
                    new Department { Id = 14, Name = "Çocuk Nörolojisi" },
                    new Department { Id = 15, Name = "Çocuk Onkolojisi" },
                    new Department { Id = 16, Name = "Çocuk Psikiyatrisi" },
                    new Department { Id = 17, Name = "Çocuk Sağlığı ve Hastalıkları" },
                    new Department { Id = 18, Name = "Çocuk Ürolojisi" },
                    new Department { Id = 19, Name = "Cildiye" },
                    new Department { Id = 20, Name = "Dahiliye" },
                    new Department { Id = 21, Name = "Dermatoloji" },
                    new Department { Id = 22, Name = "Endokrinoloji ve Metabolizma" },
                    new Department { Id = 23, Name = "Enfeksiyon Hastalıkları" },
                    new Department { Id = 24, Name = "Fizik Tedavi ve Rehabilitasyon" },
                    new Department { Id = 25, Name = "Gastroenteroloji" },
                    new Department { Id = 26, Name = "Genel Cerrahi" },
                    new Department { Id = 27, Name = "Geriatri" },
                    new Department { Id = 28, Name = "Göz Hastalıkları" },
                    new Department { Id = 29, Name = "Göğüs Cerrahisi" },
                    new Department { Id = 30, Name = "Göğüs Hastalıkları" },
                    new Department { Id = 31, Name = "Hematoloji" },
                    new Department { Id = 32, Name = "İmmünoloji" },
                    new Department { Id = 33, Name = "Kadın Hastalıkları ve Doğum" },
                    new Department { Id = 34, Name = "Kalp ve Damar Cerrahisi" },
                    new Department { Id = 35, Name = "Kardiyoloji" },
                    new Department { Id = 36, Name = "Kulak Burun Boğaz" },
                    new Department { Id = 37, Name = "Nefroloji" },
                    new Department { Id = 38, Name = "Neonatoloji" },
                    new Department { Id = 39, Name = "Nöroloji" },
                    new Department { Id = 40, Name = "Nükleer Tıp" },
                    new Department { Id = 41, Name = "Onkoloji" },
                    new Department { Id = 42, Name = "Ortopedi ve Travmatoloji" },
                    new Department { Id = 43, Name = "Patoloji" },
                    new Department { Id = 44, Name = "Plastik, Rekonstrüktif ve Estetik Cerrahi" },
                    new Department { Id = 45, Name = "Psikiyatri" },
                    new Department { Id = 46, Name = "Psikoloji" },
                    new Department { Id = 47, Name = "Radyasyon Onkolojisi" },
                    new Department { Id = 48, Name = "Radyoloji" },
                    new Department { Id = 49, Name = "Romatoloji" },
                    new Department { Id = 50, Name = "Ruh Sağlığı ve Hastalıkları" },
                    new Department { Id = 51, Name = "Spor Hekimliği" },
                    new Department { Id = 52, Name = "Tıbbi Genetik" },
                    new Department { Id = 53, Name = "Tıbbi Mikrobiyoloji" },
                    new Department { Id = 54, Name = "Tıbbi Onkoloji" },
                    new Department { Id = 55, Name = "Üroloji" },
                    new Department { Id = 56, Name = "Yenidoğan Yoğun Bakım" },
                    new Department { Id = 57, Name = "Yoğun Bakım" }
                );

            //Appointment
            modelBuilder.Entity<Appointment>()
				.HasKey(r =>  r.Id);
			modelBuilder.Entity<Appointment>()
				.HasOne(r => r.Patient)
				.WithMany(p => p.Appointments)
				.HasForeignKey(r => r.PatientId);
			modelBuilder.Entity<Appointment>()
				.HasOne(r => r.Doctor)
				.WithMany(d => d.Appointments)
				.HasForeignKey(r => r.DoctorId);
			modelBuilder.Entity<Appointment>()
				.Property(r => r.CreatedAt)
				.HasDefaultValueSql("NOW()");
            modelBuilder.Entity<Appointment>()
                .Property(a => a.Status)
                .HasConversion<string>()
                .HasMaxLength(20);
            modelBuilder.Entity<Appointment>()
                .HasCheckConstraint(
                    name: "CHK_Appointment_Date_Range",
                    sql: "\"Date\" >= CURRENT_DATE AND \"Date\" <= (CURRENT_DATE + INTERVAL '1 month')"
                );

            //TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .HasMany(ts => ts.Appointments)
                .WithOne(a => a.TimeSlot)
                .HasForeignKey(a => a.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TimeSlot>()
                .HasData(
                    new TimeSlot { Id = 1, Time = new TimeOnly(8, 0) },
                    new TimeSlot { Id = 2, Time = new TimeOnly(8, 30) },
                    new TimeSlot { Id = 3, Time = new TimeOnly(9, 0) },
                    new TimeSlot { Id = 4, Time = new TimeOnly(9, 30) },
                    new TimeSlot { Id = 5, Time = new TimeOnly(10, 0) },
                    new TimeSlot { Id = 6, Time = new TimeOnly(10, 30) },
                    new TimeSlot { Id = 7, Time = new TimeOnly(11, 0) },
                    new TimeSlot { Id = 8, Time = new TimeOnly(11, 30) },
                    new TimeSlot { Id = 9, Time = new TimeOnly(12, 0) },
                    new TimeSlot { Id = 10, Time = new TimeOnly(12, 30) },
                    new TimeSlot { Id = 11, Time = new TimeOnly(13, 0) },
                    new TimeSlot { Id = 12, Time = new TimeOnly(13, 30) },
                    new TimeSlot { Id = 13, Time = new TimeOnly(14, 0) },
                    new TimeSlot { Id = 14, Time = new TimeOnly(14, 30) },
                    new TimeSlot { Id = 15, Time = new TimeOnly(15, 0) },
                    new TimeSlot { Id = 16, Time = new TimeOnly(15, 30) },
                    new TimeSlot { Id = 17, Time = new TimeOnly(16, 0) },
                    new TimeSlot { Id = 18, Time = new TimeOnly(16, 30) },
                    new TimeSlot { Id = 19, Time = new TimeOnly(17, 0) }
                );


            //User.Role
            modelBuilder.Entity<User>()
				.Property(u => u.Role)
				.HasConversion<string>()
				.HasMaxLength(20);
		}
	}
}
