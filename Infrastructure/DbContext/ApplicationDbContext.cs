namespace Infrastructure.DbContext
{
    using Domains.Entities;
    using Domains.Identity;
    using Infrastructure.Configurations;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private string roleId = Guid.NewGuid().ToString();
        private string userId = Guid.NewGuid().ToString();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = roleId
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userId,
                UserName = "Admin",
                NormalizedUserName = "Admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123*")

            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = roleId
            });

            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }
        public DbSet<Ticket> Tickets { get; set; }
   
    }
}
