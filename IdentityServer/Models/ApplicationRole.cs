using System;
using Microsoft.AspNetCore.Identity;

namespace IdentityServerAspNetIdentity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationRole : IdentityRole<Guid>
    {
    }
}