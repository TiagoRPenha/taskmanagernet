using AutoMapper;
using TaskManager.Business.Models.Enums;

namespace TaskManager.Api.ViewModels
{
    public class ProjectInputModel
    {
        public ProjectInputModel(string name, Guid userId, UserProfile profile)
        {
            Name = name;
            UserId = userId;
            Profile = profile;
        }

        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public UserProfile Profile { get; private set; }
    }
}
