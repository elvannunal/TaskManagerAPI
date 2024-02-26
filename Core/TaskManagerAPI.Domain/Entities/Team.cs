using TaskManagerAPI.Domain.Common;

namespace TaskManagerAPI.Domain.Entities;

using TaskManagerAPI.Domain.Common;

    public class Team : BaseEntity
    {
        public int TeamId { get; set; }
        
        public string TeamName { get; set; }
        
        public string? TeamLeadId { get; set; }
        public User? TeamLead { get; set; }
       
        public ICollection<User>? Members { get; set; }
        
        public ICollection<UserTask>? Tasks { get; set; }
    }
