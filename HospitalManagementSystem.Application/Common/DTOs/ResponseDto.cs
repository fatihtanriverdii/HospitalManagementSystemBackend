namespace HospitalManagementSystem.Application.Common.DTOs
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = null!;
        public T? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
