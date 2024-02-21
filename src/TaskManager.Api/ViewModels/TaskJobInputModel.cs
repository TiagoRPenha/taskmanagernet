using TaskManager.Business.Models.Enums;

namespace TaskManager.Api.ViewModels
{
    public class TaskJobInputModel
    {
        public TaskJobInputModel(string title, string description, DateTime dueDate, Status status, Priority priority, Guid projectId)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            ProjectId = projectId;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public Status Status { get; private set; }
        public Priority Priority { get; private set; }
        public Guid ProjectId { get; set; }
    }
}
