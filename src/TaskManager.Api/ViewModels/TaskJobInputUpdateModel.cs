using TaskManager.Business.Models.Enums;

namespace TaskManager.Api.ViewModels
{
    public class TaskJobInputUpdateModel
    {
        public TaskJobInputUpdateModel(string title, string description, string? comment, DateTime dueDate, Status status)
        {
            Title = title;
            Description = description;
            Comment = comment;
            DueDate = dueDate;
            Status = status;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string? Comment { get; private set; }
        public DateTime DueDate { get; private set; }
        public Status Status { get; private set; }
    }
}
