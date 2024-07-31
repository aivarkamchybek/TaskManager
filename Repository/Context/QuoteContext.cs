using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class QuoteContext : DbContext
    {
        public QuoteContext() : base("QuoteContext")
        {
        }
        public DbSet<Quote> Quotes {  get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
