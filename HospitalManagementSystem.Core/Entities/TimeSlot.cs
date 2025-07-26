namespace HospitalManagementSystem.Core.Entities
{
    public class TimeSlot
    {
        public long Id { get; set; }
        public TimeOnly Time {  get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
