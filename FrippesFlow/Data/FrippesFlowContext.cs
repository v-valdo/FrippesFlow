using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using FrippesFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace FrippesFlow.data
{
    public class FrippesFlowContext : DbContext
    {
        public DbSet <SalesEntry> SalesEntries { get; set; }
        public FrippesFlowContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}