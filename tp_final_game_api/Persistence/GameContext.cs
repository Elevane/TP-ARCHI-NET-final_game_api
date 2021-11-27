using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using tp_final_game_api.Persistence.Models;
namespace tp_final_game_api.Persistence
{
    public class GameContext : DbContext
    {
        private readonly string _connectionString;
        public GameContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();  
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(item =>
            {
                item.ToTable("question");
                item.HasKey(question => question.Id);
                item.HasOne(question => question.Categorie);
                item.HasMany(question => question.Reponses);
            });
            modelBuilder.Entity<Categorie>(item =>
            {
                item.HasKey(categorie => categorie.Id);
            });

            modelBuilder.Entity<Reponse>(item =>
            {
                item.HasKey(reponse => reponse.Id);
            });

        }
    }
}
