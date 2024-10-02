namespace TaskManagementApp.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int StateId { get; set; }

        public StateEntity? State { get; set; }

    }
}
