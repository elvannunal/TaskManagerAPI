using TaskManagerAPI.Application.Enums;

namespace TaskManagerAPI.Application.Dto.Configuration;

public class Action
{
    public string ActionType { get; set; }
    public string HttpType { get; set; }
    public string Defination { get; set; }
    public string Code { get; set; }
}