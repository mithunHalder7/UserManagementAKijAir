using Microsoft.EntityFrameworkCore;
using UserManagementTest.Models;

namespace UserManagemenTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // Configure the relationships using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define foreign key relationships and composite primary key for RolePermission
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });  // Composite primary key
            
            // Define foreign key relationships and any additional constraints
            // Relationship between User and Role (one-to-many)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if role is deleted

            // Relationship between RolePermission and Role (many-to-one)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if role is deleted

            // Relationship between RolePermission and Permission (many-to-one)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if permission is deleted

            // Optional: Adding Unique Index on Permission Code
            modelBuilder.Entity<Permission>()
                .HasIndex(p => p.Code)
                .IsUnique();
        }
    }
}
