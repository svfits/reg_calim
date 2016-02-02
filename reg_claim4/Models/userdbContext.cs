using System.Data.Entity;

namespace reg_claim4.Models
{
    public class userdbContext : System.Data.Entity.DbContext
    {
        //   public userdbContext() : 
        //   public DbSet<Username> User { get; set; }      
        public DbSet<claim> ClaimeName { get; set; }
        public DbSet<logs> logs { get; set; }
    }
}
