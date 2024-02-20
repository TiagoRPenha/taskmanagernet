namespace TaskManager.Business.Models
{
    public class TaskJobAudit : Entity
    {
        public Guid UserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public string FieldChange { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
