using Neyiyelim.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Neyiyelim.Context
{
    public class RestorantContext:DbContext
    {
        public RestorantContext() : base("cn1") 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RestorantContext>());
        }
        public DbSet<Restorant> Restorants { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Receipts> Receipts { get; set; }
        public DbSet<ReceiptCategory> receiptCategories { get; set; }

    }

      
}