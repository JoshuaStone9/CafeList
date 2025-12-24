using System;
using System.Collections.Generic;

namespace CafeList;

internal class FoodList : IMenuItem
{
    public string Name { get; }
    public string Description { get; }
    public bool IsVegan { get; }
    public bool IsVegetarian => IsVegan;
    public bool IsGlutenFree { get; }

    private FoodList(
        string name,
        string description,
        bool isVegan = false,
        bool isGlutenFree = false)
    {
        Name = name;
        Description = description;
        IsVegan = isVegan;
        IsGlutenFree = isGlutenFree;
    }

    public static IReadOnlyList<FoodList> BuildMenu()
    {
        return new List<FoodList>
        {
            new FoodList("Croissant", "Buttery and flaky"),
            new FoodList("Muffin", "Soft and sweet"),
            new FoodList("Bagel", "Chewy and dense"),
            new FoodList("Scone", "Crumbly and rich"),
            new FoodList("Sandwich", "Savory and filling"),
            new FoodList("Salad", "Fresh and healthy", isVegan: true),
            new FoodList("Quiche", "Creamy and savory", isGlutenFree: true),
            new FoodList("Wrap", "Convenient and tasty"),
            new FoodList("Pastry", "Sweet and indulgent"),
            new FoodList("Cake", "Decadent and delightful"),
            new FoodList("Fruit Bowl", "Assorted fresh fruits", isVegan: true, isGlutenFree: true),
            new FoodList("Yogurt Parfait", "Layers of yogurt, granola, and fruit"),
            new FoodList("Vegan Burger", "Plant-based and flavorful", isVegan: true)
        };
    }
    public string VeganStatus
    {
        get
        {

            return IsVegan ? "You Are A Vegan" : "You Are Not Vegan";

        }
    }


    public string GlutenFreeStatus
    {
        get
        {
            return IsGlutenFree ? "You Are Gluten Free" : "You Are Not Gluten Free";
        }
    }

    public string VegetarianStatus
    {
        get
        {
            return IsVegetarian ? "You Are Vegetarian" : "You Are Not Vegetarian";
        }
    }




}
