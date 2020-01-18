using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataAccess.Context
{
    public class WorkScheduleContext : DbContext
    {
        public WorkScheduleContext() { }
        public WorkScheduleContext(DbContextOptions<WorkScheduleContext> options)
            : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<PersonShift> PersonShifts { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shift>()
                .HasOne(s => s.Type)
                .WithMany(t => t.Shifts)
                .HasForeignKey(s => s.TypeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PersonShift>()
                .HasOne(ps => ps.Person)
                .WithMany(p => p.Shifts)
                .HasForeignKey(ps => ps.PersonId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PersonShift>()
                .HasOne(ps => ps.Shift)
                .WithMany(s => s.People)
                .HasForeignKey(ps => ps.ShiftId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<User>()
                .HasOne(ps => ps.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(ps => ps.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Position)
                .WithMany(po => po.People)
                .HasForeignKey(p => p.PositionId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<PersonShift>()
                .HasKey(ps => new { ps.PersonId, ps.ShiftId });
            modelBuilder.Entity<Person>()
                .HasOne<User>(p => p.User)
                .WithOne(u => u.Person)
                .HasForeignKey<User>(u => u.PersonId);
            modelBuilder.Entity<User>()
                .HasOne<Person>(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PersonId);

            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = 1,
                    Name = "ROLE_ADMIN",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Role
                {
                    Id = 2,
                    Name = "ROLE_USER",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }) ;
            
            modelBuilder.Entity<Position>()
                .HasData(new Position
                {
                    Id = 1,
                    Name = "Manager",
                    Description = "Manages stuff",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Position
                {
                    Id = 2,
                    Name = "Worker",
                    Description = "Does the simple work",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
            modelBuilder.Entity<ShiftType>()
                .HasData(new ShiftType
                {
                    Id = 1,
                    Name = "First",
                    Description = "From 8 to 16",
                    Start = new DateTime(2000,1,1,8,0,0),
                    End = new DateTime(2000,1,1,16,0,0),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new ShiftType
                {
                    Id = 2,
                    Name = "Second",
                    Description = "From 16 to 24",
                    Start = new DateTime(2000, 1, 1, 16, 0, 0),
                    End = new DateTime(2000, 1, 2, 0, 0, 0),
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
            modelBuilder.Entity<Person>()
                .HasData(new Person
                {
                    Id = 1,
                    FirstName = "Georgi",
                    LastName = "Petrov",
                    DateOfBirth = new DateTime(1953, 2, 25),
                    PositionId = 1,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Person
                {
                    Id = 2,
                    FirstName = "Petyr",
                    LastName = "Georgiev",
                    DateOfBirth = new DateTime(1996, 5, 13),
                    PositionId = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Person
                {
                    Id = 3,
                    FirstName = "Ana",
                    LastName = "Velikova",
                    DateOfBirth = new DateTime(1990, 7, 4),
                    PositionId = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1,
                    Username = "Georgi5",
                    Email = "georgi@gmail.com",
                    Password = "1234567890",
                    RoleId = 1,
                    PersonId = 1,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new User
                {
                    Id = 2,
                    Username = "Pesheca",
                    Email = "pesho@gmail.com",
                    Password = "peshopesho",
                    RoleId = 2,
                    PersonId = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
            modelBuilder.Entity<Shift>()
                .HasData(new Shift
                {
                    Id = 1,
                    TypeId = 1,
                    Date = new DateTime(2020,1,10),
                    MoneyMade = 100,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Shift
                {
                    Id = 2,
                    TypeId = 2,
                    Date = new DateTime(2020, 1, 10),
                    MoneyMade = 200,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Shift
                {
                    Id = 3,
                    TypeId = 1,
                    Date = new DateTime(2020, 1, 11),
                    MoneyMade = 85,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new Shift
                {
                    Id = 4,
                    TypeId = 2,
                    Date = new DateTime(2020, 1, 11),
                    MoneyMade = 70,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
            modelBuilder.Entity<PersonShift>()
                .HasData(new PersonShift
                {
                    Id = 1,
                    PersonId = 1,
                    ShiftId = 1,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new PersonShift
                {
                    Id = 2,
                    PersonId = 2,
                    ShiftId = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new PersonShift
                {
                    Id = 3,
                    PersonId = 3,
                    ShiftId = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new PersonShift
                {
                    Id = 4,
                    PersonId = 3,
                    ShiftId = 3,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new PersonShift
                {
                    Id = 5,
                    PersonId = 1,
                    ShiftId = 4,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                }, new PersonShift
                {
                    Id = 6,
                    PersonId = 2,
                    ShiftId = 4,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                });
        }
        public override int SaveChanges()
        {
            SaveTime();
            return base.SaveChanges();
        }
        public void SaveTime()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Deleted)
                    ((BaseEntity)entry.Entity).DeletedOn = DateTime.Now;
                else
                {
                    ((BaseEntity)entry.Entity).ModifiedOn = DateTime.Now;
                    if (entry.State == EntityState.Added)
                        ((BaseEntity)entry.Entity).CreatedOn = DateTime.Now;
                }
            }
        }
    }
    class StoreContextFactory : IDesignTimeDbContextFactory<WorkScheduleContext>
    {
        public WorkScheduleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WorkScheduleContext>();

            return new WorkScheduleContext(optionsBuilder.Options);
        }
    }
}
