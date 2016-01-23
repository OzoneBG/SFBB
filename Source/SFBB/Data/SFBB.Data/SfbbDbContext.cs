namespace SFBB.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SFBB.Data.Models;

    public class SfbbDbContext : IdentityDbContext<User>
    {
        public SfbbDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static SfbbDbContext Create()
        {
            return new SfbbDbContext();
        }
    }
}
