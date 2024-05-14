using Microsoft.EntityFrameworkCore;
using PersonInterestAPI.Models;

namespace PersonInterestAPI.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => new { pi.PersonId, pi.InterestId });

            modelBuilder.Entity<PersonInterest>()
                .HasKey(pi => pi.Id);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person)
                .WithMany(p => p.PersonInterests)
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            // Configure Link entity
            modelBuilder.Entity<Link>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Link>()
                .Property(l => l.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Link>()
                .Property(l => l.PersonInterestId)
                .HasColumnName("PersonInterestId"); 

            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest)
                .WithMany(pi => pi.Links)
                .HasForeignKey(l => l.PersonInterestId) 
                .OnDelete(DeleteBehavior.Cascade); 

      modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "John Doe", PhoneNumber = "1234567890" },
                new Person { Id = 2, Name = "Jane Smith", PhoneNumber = "987654321" },
                new Person { Id = 3, Name = "Michael Johnson", PhoneNumber = "5555555555" }
            );

            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Programming", Description = "Creating software applications" },
                new Interest { Id = 2, Title = "Gaming", Description = "Playing video games" },
                new Interest { Id = 3, Title = "Reading", Description = "Reading books and articles" },
                new Interest { Id = 4, Title = "Sports", Description = "Playing sports" }
            );

            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { Id = 2, PersonId = 1, InterestId = 3 },
                new PersonInterest { Id = 3, PersonId = 2, InterestId = 2 },
                new PersonInterest { Id = 4, PersonId = 2, InterestId = 4 },
                new PersonInterest { Id = 5, PersonId = 3, InterestId = 1 },
                new PersonInterest { Id = 6, PersonId = 3, InterestId = 4 }
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, URL = "https://docs.microsoft.com/en-us/dotnet/csharp/", PersonInterestId = 1 },
                new Link { Id = 2, URL = "https://www.udemy.com/topic/programming-languages/", PersonInterestId = 1 },
                new Link { Id = 3, URL = "https://store.steampowered.com/", PersonInterestId = 2 },
                new Link { Id = 4, URL = "https://www.goodreads.com/", PersonInterestId = 3 },
                new Link { Id = 5, URL = "https://www.nba.com/", PersonInterestId = 4 },
                new Link { Id = 6, URL = "https://www.fifa.com/", PersonInterestId = 4 }
            );
        }
    }
}
