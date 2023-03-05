using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Domain.Common;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILoggerFactory _loggerFactory;



        /// <summary>
        /// Constructor for ApplicationDbContext
        /// </summary>
        /// <param name="options">Options for the DbContext</param>
        /// <param name="dateTime">Service for getting the current date and time</param>
        /// <param name="loggerFactory">Factory for creating loggers</param>
        /// <returns>
        /// An instance of ApplicationDbContext
        /// </returns>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _loggerFactory = loggerFactory;
        }

        public DbSet<Position> Positions { get; set; }



        /// <summary>
        /// Overrides the SaveChangesAsync method to set the Created and LastModified properties of entities.
        /// </summary>
        /// <returns>
        /// A Task that represents the asynchronous operation.
        /// </returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



        /// <summary>
        /// Overrides the OnModelCreating method to seed the database with mock data. 
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var _mockData = this.Database.GetService<IMockService>();
            var seedPositions = _mockData.SeedPositions(1000);
            builder.Entity<Position>().HasData(seedPositions);

            base.OnModelCreating(builder);
        }



        /// <summary>
        /// Configures the DbContextOptionsBuilder with a LoggerFactory.
        /// </summary>
        /// <param name="optionsBuilder">The DbContextOptionsBuilder to configure.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}