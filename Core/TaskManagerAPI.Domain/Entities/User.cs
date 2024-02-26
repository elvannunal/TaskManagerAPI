using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Domain.Common;

namespace TaskManagerAPI.Domain.Entities;

public class User : IdentityUser<string>
{
    public string NameSurname { get; set; }
    public ICollection<Team> Teams { get; set; }
}