using Microsoft.EntityFrameworkCore;


namespace DataEntities
{
    public class DataBase:DbContext
    {

        public DataBase(DbContextOptions opts):base(opts)
        {

        }
        public DbSet<SignInUserData> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder Mb)
        {
            base.OnModelCreating(Mb);
            Mb.Entity<SignInUserData>().ToTable("Registered Users");
            Mb.Entity<SignInUserData>().HasData(new SignInUserData()
            {
                Id=Guid.NewGuid(),
                FirstName="David",
                LastName="Elvis",
                Email="daveelvis.369@gmail.com",
                PhoneNumber="07823622281",
                Course="Asp.net",
                Password="See9lu$9lu$"



            });
            

        }

    }
}