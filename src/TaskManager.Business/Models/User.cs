using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Models
{
    public class User : Entity
    {
        public User(UserProfile profile) 
        { 
            Profile = profile;

            Projects = new List<Project>();
        }
        public UserProfile Profile { get; private set; }
        public List<Project> Projects { get; set; }
    }
}
