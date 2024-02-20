using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Models
{
    public class TaskJob : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string? Comment { get; set; }
        public DateTime DueDate { get; private set; }
        public Status Status { get; private set; }
        public Priority Priority { get; private set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
