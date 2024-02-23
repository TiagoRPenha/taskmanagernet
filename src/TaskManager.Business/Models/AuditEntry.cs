using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;
using TaskManager.Business.Models.Enums;

namespace TaskManager.Business.Models
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry) => Entry = entry;

        public EntityEntry Entry { get; }
        public string UserId { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new();
        public Dictionary<string, object> OldValues { get; } = new();
        public Dictionary<string, object> NewValues { get; } = new();
        public AuditType AuditType { get; set; }
        public List<string> ChangedColumns { get; } = new();
        public string Comment { get; set; }

        public TaskJobAudit ToAudit()
        {
            var audit = new TaskJobAudit
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid().ToString(),
                Type = AuditType.ToString(),
                UpdateDate = DateTime.Now,
                OldValue = OldValues.Count == 0 ? "" : JsonSerializer.Serialize(OldValues),
                NewValue = NewValues.Count == 0 ? "" : JsonSerializer.Serialize(NewValues),
                FieldChange = ChangedColumns.Count == 0 ? "" : JsonSerializer.Serialize(ChangedColumns),
                Comment = Comment
            };

            return audit;
        }
    }
}
