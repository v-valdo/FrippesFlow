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
        public DbSet<ProductionCost> ProductionCosts { get; set; }
        public DbSet<IngredientPer10k> IngredientsPer10k { get; set; }
        public DbSet<MonthlyExpense> MonthlyExpenses { get; set; }
        public DbSet<Result> Results { get; set; }
        
        public FrippesFlowContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}