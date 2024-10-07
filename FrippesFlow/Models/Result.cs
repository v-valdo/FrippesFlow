using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrippesFlow.Models
{
public class Result
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public double ProductionCost { get; set; }
    public double TotalIncome { get; set; }
}

}