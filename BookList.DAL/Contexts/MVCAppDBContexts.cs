using Booklets.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklets.DAL.Contexts
{
    public class MVCAppDBContexts : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        //    optionsBuilder.UseSqlServer("Server = . ; Database = MVCBookletsDb ; Trusted_Connection = true");

        public MVCAppDBContexts(DbContextOptions<MVCAppDBContexts> options) : base(options)

        {

        }
        public DbSet<Booklet> Booklets { get; set; }
        public DbSet<BookletSales> BookletSales { get; set; }

    }
}
