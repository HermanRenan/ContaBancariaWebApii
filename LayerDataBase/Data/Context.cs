using LayerDataBase.Model;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LayerDataBase.Data
{
    public class Context : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbBank;Integrated Security=True"); 
        }
    }
}
