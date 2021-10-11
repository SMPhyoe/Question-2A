using Microsoft.EntityFrameworkCore;
using producerest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace producerest.DbContext
{
    public class ProducerDBContext : DbContext
    {
        public ProducerDBContext(DbContextOptions<ProducerDBContext> options)
            : base(options)
        {
           
        }

        public DbSet<ProducerModel> ProducerModel { get; set; }
    }
}
