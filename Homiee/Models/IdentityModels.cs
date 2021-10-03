using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Homiee.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<UserComment> UserComments { get; set; }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<MobileBanking> MobileBankings { get; set; }
        public DbSet<HostsToGuestsReview> HostsToGuestsReviews { get; set; }
        public DbSet<GuestsToHostsReview> GuestsToHostsReviews { get; set; }
        public DbSet<GuestsToHotelsReview> GuestsToHotelsReviews { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Bank> Banks { get; set; }

        public DbSet<HostPostInfo> HostPostInfoes { get; set; }

        public DbSet<HotelInfo> HotelInfoes { get; set; }

        public DbSet<HotelAddress> HotelAddresses { get; set; }

        public ApplicationDbContext()
            : base("DBConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /*public System.Data.Entity.DbSet<Homiee.Models.HostingInfo> HostingInfoes { get; set; }*/
    }
}