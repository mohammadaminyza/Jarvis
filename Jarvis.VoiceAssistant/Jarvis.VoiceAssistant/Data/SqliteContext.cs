using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Jarvis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace Jarvis.VoiceAssistant.Data
{
    public class SqliteContext : DbContext
    {
        private string _dbPath = "";

        public SqliteContext(string dbPath)
        {
            _dbPath = dbPath;

            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        public DbSet<Command> Commands { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = _dbPath;

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
