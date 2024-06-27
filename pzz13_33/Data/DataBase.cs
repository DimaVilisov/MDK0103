using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pzz13_33.Data
{
    internal class DataBase : DbContext
    {
        #region Таблицы
        public DbSet<User> Users { get; set; }
        public DbSet<Tovar> Tovars { get; set; }
        
        #endregion

        #region Конструторы
        public DataBase()
        {
            if (File.Exists("testDB.db3") != true)
            {
                Database.EnsureCreated();
            }
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"FileName=testDB.db3");
        }
    }
}