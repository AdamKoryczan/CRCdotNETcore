using DotNetCoreWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebApi.DBContexts
{
    public class MeasurementContext : DbContext
    {
        public MeasurementContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Measurement> Measurements { get; set; }
    }
}
