namespace UserManagementTest.Models;

public class Role
{
    public Guid Id { get; set; }  // CHAR(36) in MySQL
    public string Name { get; set; } = default!;

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    public IEnumerable<User>? Users { get; set; }
}