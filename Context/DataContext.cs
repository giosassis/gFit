using gFit.Models;
using Microsoft.EntityFrameworkCore;
namespace gFit.Context
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            /// apaga TODO O banco de dados
            Database.EnsureDeleted();
            /// cria o banco de dadods
            Database.EnsureCreated();
            // só uso em teste para criar as models no banco,
            // poupa tempo de usar o EntityFramework
            // TODO: REMOVER EM PROD
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategory { get; set; }
        public DbSet<ExerciseImage> ExerciseImage { get; set; }
        public DbSet<Muscle> Muscle { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<TrainingSeries> TrainingSeries { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Personal>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Address>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<Equipment>()
               .HasKey(p => p.Id);

            //
            modelBuilder.Entity<Exercise>()
               .HasKey(p => p.Id);
            
            modelBuilder.Entity<ExerciseImage>()
               .HasKey(p => p.Id);

            //modelBuilder.Entity<Exercise>()
            //    .HasOne(x => x.ExerciseImage)
            //    .WithOne(x => x.Exercise)
            //    ;
            
            //modelBuilder.Entity<ExerciseImage>()
            //   .HasOne(p => p.Exercise)
            //   .WithOne(x => x.ExerciseImage);

            //

            modelBuilder.Entity<ExerciseCategory>()
               .HasKey(p => p.Id);


            modelBuilder.Entity<Muscle>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<TrainingSeries>()
               .HasKey(p => p.Id);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    } 
}
