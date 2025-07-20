namespace HospitalManagementSystem.Core.Entities
{
    public class DoctorWorkingHour
    {
        public long Id { get; set; }
        public long DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
