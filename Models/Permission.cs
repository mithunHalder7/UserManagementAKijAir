namespace UserManagementTest.Models;

public class Permission
{
    public Guid Id { get; set; }  // CHAR(36) in MySQL
    public string Code { get; set; } = default!;      // e.g. CanEditUser
    public string Module { get; set; } = default!;    // e.g. User, Booking, Payment
    public string Action { get; set; } = default!;    // e.g. View, Edit, Delete

    public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}