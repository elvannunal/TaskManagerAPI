using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TaskManagerAPI.Application.Abstractions.Services.Configurations;
using TaskManagerAPI.Application.CustomAttributes;
using TaskManagerAPI.Application.Dto.Configuration;
using TaskManagerAPI.Application.Enums;
using Action = TaskManagerAPI.Application.Dto.Configuration.Action;

namespace TaskManagerAPI.Infrastructure.Configuration;

public class AuthorizeService :IAuthorizeService
{
    // Bu metod, verilen bir assembly'nin türlerini tarayarak yetkilendirme tanımlarını elde etmeyi sağlar.
    public List<Menu> GetAuthorizeDefinitionEndPoints(Type assemblyType)
    {
        // Verilen assembly türünden bir Assembly nesnesi elde edilir.
        Assembly assembly = Assembly.GetAssembly(assemblyType);
        
        // Assembly içerisinde ControllerBase'den türetilmiş controller türlerini alır.
        var controllers= assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
        
        // Menü listesi oluşturulur.
        List<Menu> menus = new();
        
        // Eğer assembly boş değilse devam edilir..
        if (controllers != null)
        {
            // Elde edilen her bir controller için işlem yapılır.
            foreach (var controller in controllers)
            {
                // Controller üzerinde AuthorizeDefinitionAttribute ile işaretlenmiş metotlar alınır.
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
                           
                           // Menü var mı kontrol edilir, yoksa oluşturulur ve listeye eklenir.
                           if (!menus.Any(m => m.Name == authorizeDefinitionAttr.Menu))
                           {
                               menu = new() { Name = authorizeDefinitionAttr.Menu };
                               menus.Add(menu);
                           }
                           else
                               menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttr.Menu);

                           
                           // Action oluşturulur ve bilgileri doldurulur.
                           Action _action = new()
                           {
                               ActionType = Enum.GetName(typeof(ActionType),authorizeDefinitionAttr.ActionType),
                               Defination = authorizeDefinitionAttr.Definition
                           };
                           
                           // Metotun HTTP tipi alınır (GET, POST, PUT, DELETE).
                          var httpAttributes=attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                          if (httpAttributes != null)
                          {
                              //varsa olanlar alınır
                              _action.HttpType = httpAttributes.HttpMethods.First();
                          }
                          else
                          //yoksa direkt olarak get kabul edilir
                              _action.HttpType = "GET";

                          _action.Code =
                              $"{_action.HttpType.ToLower()}.{_action.ActionType.ToLower()}.{_action.Defination.Replace(" ", "")}";

                          menu.Actions.Add(_action);
                           
                       }

                    }
            }     
        }
        return menus;
        
    }
}