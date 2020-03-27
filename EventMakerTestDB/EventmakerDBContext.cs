namespace EventMakerTestDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventmakerDBContext : DbContext
    {
        public EventmakerDBContext()
            : base("name=EventmakerDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Place)
                .IsUnicode(false);
        }
    }
}
