using Microsoft.EntityFrameworkCore;

namespace API.Data.Entities
{
    public partial class DataBaseContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ApiUser>().Property(x => x.Id)
            //modelBuilder.HasDefaultSchema("")
        }
    }
}
