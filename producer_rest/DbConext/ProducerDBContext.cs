using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using producer_rest.Models;

namespace producer_rest.DbConext
{
    public class ProducerDBContext : DbContext
    {

        public ProducerDBContext(DbContextOptions<ProducerDBContext> options)
            : base(options)
        {

        }

        public DbSet<Producer> Producer { get; set; }
    }
}
