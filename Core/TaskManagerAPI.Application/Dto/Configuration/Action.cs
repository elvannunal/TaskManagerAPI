using TaskManagerAPI.Application.Enums;

namespace TaskManagerAPI.Application.Dto.Configuration;

public class Action
{
    public ActionType ActionType { get; set; }
    public string HttpType { get; set; }
    public string Defination { get; set; }
}