using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    public class EFDbContext : DbContext
    {
        //Консруктор в який передаємо рядок підключення до бази даних
        public EFDbContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<User> Users { get; set; }
       

    }
}
