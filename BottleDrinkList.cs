using System;
using System.Collections.Generic;

namespace CafeList;

internal class BottleDrinkList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }

    private BottleDrinkList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static IReadOnlyList<BottleDrinkList> BuildMenu()
    {
        return new List<BottleDrinkList>
        {
            new BottleDrinkList("Sparkling Water", "Carbonated and refreshing"),
            new BottleDrinkList("Bottled Iced Tea", "Chilled and flavorful"),
            new BottleDrinkList("Bottled Lemonade", "Sweet and tangy"),
            new BottleDrinkList("Kombucha", "Fermented and fizzy"),
            new BottleDrinkList("Cold Pressed Juice", "Fresh and nutritious"),
            new BottleDrinkList("Energy Drink", "Energizing and bold"),
            new BottleDrinkList("Flavored Water", "Infused and tasty"),
            new BottleDrinkList("Coconut Water", "Hydrating and natural"),
            new BottleDrinkList("Sports Drink", "Replenishing and refreshing")
        };
    }
}
