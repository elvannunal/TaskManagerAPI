using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TaskManagerAPI.Application.Abstractions.Services.Configurations;
using TaskManagerAPI.Application.CustomAttributes;
using TaskManagerAPI.Application.Dto.Configuration;
using Action = TaskManagerAPI.Application.Dto.Configuration.Action;

namespace TaskManagerAPI.Infrastructure.Configuration;

public class AuthorizeService :IAuthorizeService
{
    public List<Menu> GetAuthorizeDefinitionEndPoints(Type assemblyType)
    {
       
        Assembly assembly = Assembly.GetAssembly(assemblyType);
        
        var controllers= assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
        
        List<Menu> menus = new();
        
        if (controllers != null)
        {
            foreach (var controller in controllers)
            {
                var actions = controller.GetMethods().Where(m =>
                    m.IsDefined(typeof(AuthorizeDefinitionAttribute), true));
                
                if (actions != null)
                    foreach (var action in actions)
                    {
                       var attributes= action.GetCustomAttributes(true);
                       if (attributes != null)
                       {
                           Menu menu = null;
                          
                           var authorizeDefinitionAttr = attributes.FirstOrDefault(
                               a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                           if (!menus.Any(m => m.Name == authorizeDefinitionAttr.Menu))
                           {
                               menu = new() { Name = authorizeDefinitionAttr.Menu };
                               menus.Add(menu);
                           }
                           else
                               menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttr.Menu);

                           Action _action = new()
                           {
                               ActionType = authorizeDefinitionAttr.ActionType,
                               Defination = authorizeDefinitionAttr.Definition
                           };
                          var httpAttributes=attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                          if (httpAttributes != null)
                          {
                              _action.HttpType = httpAttributes.HttpMethods.First();
                          }
                          else
                              _action.HttpType = "GET";

                          menu.Actions.Add(_action);
                           
                       }

                    }
            }     
        }
        return menus;
        
    }
}