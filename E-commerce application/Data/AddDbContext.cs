

using E_commerce_application.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorID,
                am.MovieID

            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(m => m.Actors_Movies).HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(m => m.Actors_Movies).HasForeignKey(m => m.ActorID);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie>  Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }



        //add order table 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShopingCartItm> ShopingCartItms { get; set; }
    }
}