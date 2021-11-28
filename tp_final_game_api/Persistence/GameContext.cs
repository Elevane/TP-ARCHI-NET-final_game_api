using Microsoft.EntityFrameworkCore;
using tp_final_game_api.Persistence.Models;
namespace tp_final_game_api.Persistence
{
    public class GameContext : DbContext
    {
       
        public GameContext(DbContextOptions options ) : base( options )
        {
           
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Reponse> Reponses { get; set; }
        public DbSet<Categorie> Categories { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(item =>
            {
                item.ToTable("question");
                item.HasKey(question => question.Id);
                item.HasOne(question => question.Categorie).WithMany().HasForeignKey(question => question.CategorieId);

                item.HasMany(question => question.Reponses).WithOne(reponse => reponse.Question);
            });
            modelBuilder.Entity<Categorie>(item =>
            {
                item.ToTable("categorie");
                item.HasKey(categorie => categorie.Id);
            });

            modelBuilder.Entity<Reponse>(item =>
            {
                item.ToTable("reponse");
                item.HasKey(reponse => reponse.Id);
            });

        }
    }
}
