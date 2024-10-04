// För att redigera leverantörskostnader och ingrediensbehov
// Uppdatera vördena i Bread.cs och Ingredients.cs för körning

Console.Write("Ange antal bullar: ");
int bullar = int.Parse(Console.ReadLine());

Console.Write("Ange datum (yyyy-mm-dd): ");
string inputDatum = Console.ReadLine();
DateTime datum = DateTime.ParseExact(inputDatum, "yyyy-MM-dd", null);

decimal milkCost = (bullar / 10000m) * Ingredients.milkPer10000 * Prices.milkPricePerL;
decimal flourCost = (bullar / 10000m) * Ingredients.flourPer10000 * Prices.flourPricePerKg;
decimal yeastCost = (bullar / 10000m) * Ingredients.yeastPer10000 * Prices.yeastPricePerKg;
decimal butterCost = (bullar / 10000m) * Ingredients.butterPer10000 * Prices.butterPricePerKg;
decimal saltCost = (bullar / 10000m) * Ingredients.saltPer10000 * Prices.saltPricePerKg;
decimal waterCost = (bullar / 10000m) * Ingredients.waterPer10000 * Prices.waterPricePerM3;

decimal ingrediensKostnadTotalt = milkCost + flourCost + yeastCost + butterCost + saltCost + waterCost;

decimal personalKostnadPerBulle = 0.80m;
decimal elUtrustningPerBulle = 0.20m;
decimal intaktPerBulle = 4.00m;

decimal personalKostnadTotalt = bullar * personalKostnadPerBulle;
decimal elUtrustningTotalt = bullar * elUtrustningPerBulle;
decimal produktionsKostnadTotalt = ingrediensKostnadTotalt + personalKostnadTotalt + elUtrustningTotalt;
decimal intaktTotalt = bullar * intaktPerBulle;

decimal marginal = intaktTotalt - produktionsKostnadTotalt;

Console.WriteLine($"\n{datum.ToString("yyyy-MM-dd")}: {bullar:N0} bullar");
Console.WriteLine($"Ingredienskostnader: {ingrediensKostnadTotalt:N0}:-");
Console.WriteLine($"Personalkostnad: {personalKostnadTotalt:N0}:-");
Console.WriteLine($"El och utrustning: {elUtrustningTotalt:N0}:-");
Console.WriteLine($"Produktionskostnad: {produktionsKostnadTotalt:N0}:-");
Console.WriteLine($"Intäkt tot.: {intaktTotalt:N0}:-");
Console.WriteLine($"\nMarginal (4kr per fralla): {marginal:N0}:-");