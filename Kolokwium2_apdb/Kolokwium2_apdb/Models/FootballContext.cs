using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_apdb.Models
{
    public class FootballContext : DbContext
    {

        public DbSet<Championship> Championships { get; set; }
        public DbSet<ChampionshipTeam> ChampionshipTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerTeaM> PlayerTeams { get; set; }
        public DbSet<Team> Teams { get; set; }


        public FootballContext() { }

        public FootballContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>(opt =>
            {
                opt.HasKey(p => p.IdTeam);
                opt.Property(p => p.IdTeam).ValueGeneratedOnAdd();
                opt.Property(p => p.TeamName).HasMaxLength(30).IsRequired();


                opt.HasMany(p => p.Championship)
               .WithOne(p => p.Team)
               .HasForeignKey(p => p.IdTeam);

                opt.HasMany(p => p.PlayerTeam)
               .WithOne(p => p.Team)
               .HasForeignKey(p => p.IdTeam);
            });

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasKey(p => p.IdPlayer);
                opt.Property(p => p.IdPlayer).ValueGeneratedOnAdd();
                opt.Property(p => p.FirstName).HasMaxLength(30).IsRequired();
                opt.Property(p => p.LastName).HasMaxLength(50).IsRequired();

            });


            modelBuilder.Entity<PlayerTeaM>(opt =>
            {
                opt.HasKey(p => new { p.IdPlayer, p.IdTeam });
                opt.Property(p => p.Comment).HasMaxLength(300);

              

            });

            modelBuilder.Entity<Championship>(opt =>
            {
                opt.HasKey(p => p.IdChampionship);
                opt.Property(p => p.IdChampionship).ValueGeneratedOnAdd();

                opt.Property(p => p.OfficialName).HasMaxLength(100).IsRequired();

                opt.HasMany(p => p.ChampionshipTeam) .WithOne(p => p.Championship).HasForeignKey(p => p.IdChampionship);


            });


            modelBuilder.Entity<ChampionshipTeam>(opt =>
            {
                opt.HasKey(p => new { p.IdChampionship, p.IdTeam });


            });






        }


        }


}
