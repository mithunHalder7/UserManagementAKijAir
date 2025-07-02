namespace UserManagementTest.Models;

public class User
{
    public Guid Id { get; set; }  // CHAR(36) in MySQL
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public Guid RoleId { get; set; }

    // Navigation
    public Role Role { get; set; } = default!;
}