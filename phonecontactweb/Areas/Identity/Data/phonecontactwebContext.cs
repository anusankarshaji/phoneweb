using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using phonecontactweb.Areas.Identity.Data;
using phonecontactweb.Models;

namespace phonecontactweb.Data;

public class phonecontactwebContext : IdentityDbContext<phonecontactwebUser>
{
    public phonecontactwebContext(DbContextOptions<phonecontactwebContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<phonecontactweb.Models.Contactbook> Contactbook { get; set; } = default!;

   

}
