using FrippesFlow.Models;

public class CostCalculation
{
    public decimal IngredientCost(SalesEntry entry, IngredientPer10k ingredients, ProductionCost prodCost)
    {
        var ingredientPerFralla = entry.AmountSold / 10000m;

        decimal milkCost = ingredientPerFralla * (decimal)ingredients.Milk * (decimal)prodCost.MilkPerLitre;
        decimal flourCost = ingredientPerFralla * (decimal)ingredients.Flour * (decimal)prodCost.FlourPerKg;
        decimal yeastCost = ingredientPerFralla * (decimal)ingredients.Yeast * (decimal)prodCost.YeastPerKg;
        decimal butterCost = ingredientPerFralla * (decimal)ingredients.Butter * (decimal)prodCost.ButterPerKg;
        decimal saltCost = ingredientPerFralla * (decimal)ingredients.Salt * (decimal)prodCost.SaltPerKg;
        decimal waterCost = ingredientPerFralla * (decimal)ingredients.Water * (decimal)prodCost.WaterPerM3;

        decimal totIngredientCost = milkCost + flourCost + yeastCost + butterCost + saltCost + waterCost;

        return totIngredientCost;
    }
}