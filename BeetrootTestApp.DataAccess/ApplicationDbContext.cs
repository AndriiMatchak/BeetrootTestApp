using BeetrootTestApp.DataAccess.EntitesModel;
using Microsoft.EntityFrameworkCore;

namespace BeetrootTestApp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region Entities

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Sender> Senders { get; set; }

        #endregion

        #region ModelBuilder

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sender>()
                .HasMany(e => e.Messages)
                .WithOne(e => e.Sender)
                .OnDelete(DeleteBehavior.NoAction);
        }

        #endregion
    }
}
