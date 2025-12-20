using System;
using System.Collections.Generic;

namespace CafeList;

internal class ColdDrinkList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }

    private ColdDrinkList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static IReadOnlyList<ColdDrinkList> BuildMenu()
    {
        return new List<ColdDrinkList>
        {
            new ColdDrinkList("Iced Latte", "Cold and creamy"),
            new ColdDrinkList("Iced Mocha", "Chocolate and coffee on ice"),
            new ColdDrinkList("Cold Brew", "Smooth and strong"),
            new ColdDrinkList("Frappuccino", "Blended and frosty"),
            new ColdDrinkList("Iced Americano", "Espresso with cold water"),
            new ColdDrinkList("Iced Cappuccino", "Frothy and cold"),
            new ColdDrinkList("Iced Macchiato", "Espresso with cold milk"),
            new ColdDrinkList("Iced Chai Latte", "Spiced tea with cold milk"),
            new ColdDrinkList("Bubble Tea", "Tea with tapioca pearls")
        };
    }
}
