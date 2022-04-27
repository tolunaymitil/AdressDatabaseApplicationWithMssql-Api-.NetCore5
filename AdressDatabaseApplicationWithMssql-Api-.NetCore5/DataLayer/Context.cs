using AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdressDatabaseApplicationWithMssql_Api_.NetCore5.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=DatabaseApi2;integrated security=true;");
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Person> Persons { get; set; }


    }
}
