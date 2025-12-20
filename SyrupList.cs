using System;
using System.Collections.Generic;

namespace CafeList;

internal class SyrupList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }

    private SyrupList(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static IReadOnlyList<SyrupList> BuildMenu()
    {
        return new List<SyrupList>
        {
            new SyrupList("Vanilla Syrup", "Sweet and fragrant"),
            new SyrupList("Caramel Syrup", "Rich and buttery"),
            new SyrupList("Hazelnut Syrup", "Nutty and sweet"),
            new SyrupList("Peppermint Syrup", "Cool and refreshing"),
            new SyrupList("Cinnamon Syrup", "Warm and spicy"),
            new SyrupList("Toffee Syrup", "Sweet and creamy"),
            new SyrupList("Raspberry Syrup", "Fruity and tart"),
            new SyrupList("Coconut Syrup", "Tropical and sweet"),
            new SyrupList("Almond Syrup", "Nutty and rich"),
            new SyrupList("Maple Syrup", "Sweet and earthy")
        };
    }
}
