using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Models
{
    public class TaskJob : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
