using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Application.Dto;

public class CreateTeamDto
{
    public string TeamName { get; set; }
    public int TeamId { get; set; }

}