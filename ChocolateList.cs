using System;
using System.Collections.Generic;

namespace CafeList;

internal class ChocolateList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }

    private ChocolateList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static IReadOnlyList<ChocolateList> BuildMenu()
    {
        return new List<ChocolateList>
        {
            new ChocolateList("Hot Chocolate", "Rich and creamy"),
            new ChocolateList("Mocha", "Chocolate and coffee blend"),
            new ChocolateList("White Chocolate", "Sweet and smooth"),
            new ChocolateList("Dark Chocolate", "Intense and bold"),
            new ChocolateList("Peppermint Hot Chocolate", "Minty and festive"),
            new ChocolateList("Salted Caramel Hot Chocolate", "Sweet and salty"),
            new ChocolateList("Spiced Hot Chocolate", "Warm and aromatic"),
            new ChocolateList("Hazelnut Hot Chocolate", "Nutty and delicious"),
            new ChocolateList("Orange Hot Chocolate", "Citrusy and sweet"),
            new ChocolateList("Chili Hot Chocolate", "Spicy and bold")
        };
    }
}
