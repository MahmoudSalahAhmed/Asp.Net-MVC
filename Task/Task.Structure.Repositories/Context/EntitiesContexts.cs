

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.Repositories
{
    public class EntitiesContexts :DbContext
    {
        public EntitiesContexts () :base("name=OrmanTask")
        { }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
