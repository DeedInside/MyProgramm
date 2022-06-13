using Microsoft.EntityFrameworkCore;

namespace MyProgramm.Model.DataBase
{
    class ApplicationContext : DbContext
    {
        public DbSet<exercises> Exercisesdb { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ExercisesLocalDB;Trusted_Connection=True;");
            
        }
    }
}
