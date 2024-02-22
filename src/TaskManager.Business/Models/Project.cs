using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public List<TaskJob> Tasks { get; set; }
        public Guid UserId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
