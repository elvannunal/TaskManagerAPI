using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using TaskManagerAPI.Application.Abstractions.Services;
using TaskManagerAPI.Domain.Entities;

namespace TaskManagerAPI.Persistence.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<UserRole> _roleManager;

    public RoleService(RoleManager<UserRole> roleManager)
    {
        _roleManager = roleManager; 
    }

    public IDictionary<string, string> GetAllRoles()
    {
        return _roleManager.Roles.ToDictionary(role => role.Id, role => role.Name);
    }

    public async Task<(string id, string name)> GetRoleById(string id)
    {
        string role=await _roleManager.GetRoleIdAsync(new(){Id = id});
        return (id, role);
    }

    public async Task<bool> CreateRole(string name)
    {
       IdentityResult ıdentityResult= await _roleManager.CreateAsync(new() { Name = name });
       return ıdentityResult.Succeeded;
    }

    public async Task<bool> DeleteRole(string name)
    {
        IdentityResult result =await _roleManager.DeleteAsync(new(){Name = name});
        return result.Succeeded;
    }

    public async Task<bool> UpdateRole(string id, string name)
    {
        IdentityResult result = await _roleManager.UpdateAsync(new() { Id = id, Name = name });
        return result.Succeeded;
    }
}