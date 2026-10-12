
namespace LazuritApp.modelConfiguration
{
    public class LazuritContext : DbContext
    {
        static LazuritContext()
        {
            Database.Setinitializer(new LazuritDbInitializer());
        }
        public LazuritContext() :
        base("name=LazuritContext")
        { }

        public DbSet<Passenger>
        Passenger
        {
            get; set;
        }

        public DbSet<Flights>
        Flights
        {
            get; set;
        }

        public DbSet<Booking>
        Booking {get; set;}

        public DbSet<BoardingPass>
        BoardingPass
        {
            get; set;
        }

        public DbSet<BonusAccount>
        BonusAccount{get; set;}
}

protected override void
OnModeCreating(DbModeBuildermodelBuilder)
{
    modelBuilder.Conventions.Remove<PluralizingTableNameconvention>();
    modelBuilder.Entity<Passenger>()
    .HasOptional(p => p.BonusAccount)
    .WithRequired(b => b.Passanger);
    modelBuilder.Entity<Booking>()
    .HasRequired(b => b.Passanger)
    .WithMany(p => p.Booking)
    .HasForeignKey(b => b.PassengerId);
    modelBuilder.Entity<Booking>()
    .HasRequired(b => b / Flights)
    .WithMany(f => f.Bookings)
    .HasForeignKey(b => b / FlightsId);
}
    }
}

