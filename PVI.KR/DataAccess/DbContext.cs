using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PVI.KR.DataAccess.Entities;

namespace PVI.KR.DataAccess
{
    public class ImgDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ImgDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminRoleId = Guid.Parse("2c5e174e-3b0e-446f-86af-483d56fd7210");
            var userRoleId = Guid.Parse("2c7e4450-50da-4641-90d2-7b7b7c6e16b8");
            var adminId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9");


            modelBuilder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole<Guid>
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER".ToUpper()
                });


            var hasher = new PasswordHasher<User>();


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = adminId,
                    UserName = "Admin",
                    FirstName = "Admin",
                    LastName = "Admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "Password1!")
                }
            );


            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                }
            );
        }
    }
}
