namespace LibraryManagmentSystem.Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }

    public Role(int roleId, string roleName)
    {
        RoleId = roleId;
        RoleName = roleName;
    }
}