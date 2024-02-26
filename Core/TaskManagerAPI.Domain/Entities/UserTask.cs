using TaskManagerAPI.Domain.Common;

namespace TaskManagerAPI.Domain.Entities;

public class UserTask : BaseEntity
{
    public string UserTaskName { get; set; }
    public string Description { get; set; }
    public ICollection<SubTask>? SubTasks { get; set; } = new List<SubTask>();
    public TaskStatus? Status { get; set; }
    public Guid? AssigneeId { get; set; }
    public User? Assignee { get; set; }
    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }
}
