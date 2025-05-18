namespace Application.DTOs
{
    public class MissedTaskNotification
    {
        public string Message { get; set; }
        public List<MissedTaskDto> Tasks { get; set; }
    }
}
