using System;
using System.Collections.Generic;

namespace CafeList;

internal class CoffeeList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }

    private CoffeeList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static IReadOnlyList<CoffeeList> BuildMenu()
    {
        return new List<CoffeeList>
        {
            new CoffeeList("Espresso", "Strong and bold"),
            new CoffeeList("Latte", "Smooth and creamy"),
            new CoffeeList("Cappuccino", "Frothy and rich"),
            new CoffeeList("Americano", "Diluted espresso"),
            new CoffeeList("Mocha", "Chocolate flavored"),
            new CoffeeList("Macchiato", "Espresso with a dash of milk"),
            new CoffeeList("Flat White", "Velvety microfoam"),
            new CoffeeList("Ristretto", "Short and intense"),
            new CoffeeList("Cortado", "Espresso cut with milk"),
            new CoffeeList("Affogato", "Espresso with ice cream")
        };
    }
}
