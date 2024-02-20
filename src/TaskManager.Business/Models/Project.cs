namespace TaskManager.Business.Models
{
    public class Project : Entity
    {
        public string Name { get; private set; }
        public List<TaskJob> Tasks { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
