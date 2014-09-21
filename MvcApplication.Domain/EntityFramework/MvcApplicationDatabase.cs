using MvcApplication.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Domain.EntityFramework
{
    public class MvcApplicationDatabase : DbContext
    {
        public MvcApplicationDatabase()
            : base("ConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // To stop Pluralizing Table Name Convention
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
