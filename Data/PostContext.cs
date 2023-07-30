using Microsoft.EntityFrameworkCore;
using PostApp.Helpers;
using PostApp.Tables;
using System.Collections.Generic;
using System.Linq;

namespace PostApp.Data
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        {
        }

        public DbSet<Klientai> Klientai { get; set; }
        public DbSet<LogEntries> LogEntries { get; set; }

        public List<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>().ToList();
        }

        public async Task<int> AddEntitiesToDatabaseAsync<TEntity>(ICollection<TEntity> collection, EqualityComparer<TEntity> comparer) where TEntity : class
        {
            var currentElements = this.GetAll<TEntity>();

            var newElements = collection.Except(currentElements, comparer);

            this.AddRange(newElements);
            return await this.SaveChangesAsync();
        }

        public void AddEntitiesToDatabase<TEntity>(ICollection<TEntity> collection, EqualityComparer<TEntity>? comparer = null) where TEntity : class
        {
            var currentElements = this.GetAll<TEntity>();

            if(comparer != null)
            {
                var newElements = collection.Except(currentElements, comparer);
                this.AddRange(newElements);
            }
            else
            {
                this.AddRange(collection);
            }

            this.SaveChanges();
        }

        public async Task<int> UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var entityToUpdate = this.GetAll<TEntity>().Where(s => s.Equals(entity));

            if(entityToUpdate != null)
            {
                this.Update(entity);
                return await this.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(message: "No such entity exists", paramName: nameof(entity));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Klientai>().ToTable("Klientai");
            modelBuilder.Entity<LogEntries>().ToTable("LogEntries");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .LogTo(Console.WriteLine)
                .EnableDetailedErrors();
    }
}
