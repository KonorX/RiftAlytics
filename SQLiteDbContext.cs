using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RiftAlytics
{
    public class SQLiteDbContext: DbContext
    {
        public DbSet<SummonerData> SummonerData { get; set; }

        private string _dbPath;
            
        public SQLiteDbContext()
        {
            var folder=Environment.CurrentDirectory;
            _dbPath = System.IO.Path.Combine(folder, "mydb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={_dbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SummonerData>().HasKey(u=> u.Puuid);
        }
    }
}
