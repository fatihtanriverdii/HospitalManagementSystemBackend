namespace HospitalManagementSystem.Shared.Exceptions
{
    public class DuplicateResourceException : Exception
    {
        public DuplicateResourceException(string message) : base(message) { }
    }
}
