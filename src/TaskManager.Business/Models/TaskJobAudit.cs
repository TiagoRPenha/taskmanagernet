using Microsoft.EntityFrameworkCore;

namespace TaskManager.Business.Models
{
    public class TaskJobAudit : Entity
    {
        public string UserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FieldChange { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Type { get; set; }
        public string? Comment { get; set; }

        public void UpdateDateModified(EntityState state)
        {
             UpdateDate = DateTime.Now;
        }
    }
}
