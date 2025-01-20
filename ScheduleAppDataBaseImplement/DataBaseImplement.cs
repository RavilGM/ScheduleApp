using Microsoft.EntityFrameworkCore;
using ScheduleAppContracts.StoragesContracts.dbModels;

namespace ScheduleAppDataBaseImplement 
{
    internal class DataBaseImplement : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=RavilPC\SQLEXPRESS;Initial Catalog=TestCoursWork2;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<User> Users { get; set; }
        
    }
}
