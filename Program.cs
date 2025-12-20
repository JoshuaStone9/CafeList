using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QRCoder;

namespace CafeList;

internal static class Program
{
    static void Main(string[] args)
    {
        var coffeeMenu = CoffeeList.BuildMenu();
        var chocolateMenu = ChocolateList.BuildMenu();
        var coldDrinkMenu = ColdDrinkList.BuildMenu();
        var syrupMenu = SyrupList.BuildMenu();
        var bottleDrinkMenu = BottleDrinkList.BuildMenu();
        var foodMenu = FoodList.BuildMenu();
        
        Console.WriteLine("======================");
        Console.WriteLine("WELCOME TO THE BEST CAFE!");
        Console.WriteLine("======================\n");
        PrintMenu("Coffee Menu", coffeeMenu);
        PrintMenu("Chocolate Menu", chocolateMenu);
        PrintMenu("Cold Drink Menu", coldDrinkMenu);
        PrintMenu("Syrup Menu", syrupMenu);
        PrintMenu("Bottled Drinks", bottleDrinkMenu);
        PrintMenu("Food Menu", foodMenu);
        PrintMenu("Vegan Options", foodMenu.Where(f => f.IsVegan));

        var qrPath = GenerateBlankSiteQr();
        Console.WriteLine($"Scan QR Code To Order: {qrPath}");
    }

    private static void PrintMenu(string title, IEnumerable<IMenuItem> items)
    {
        Console.WriteLine($"{title}\n");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name} - {item.Description}");
        }
        Console.WriteLine();
    }

    private static string GenerateBlankSiteQr()
    {
        const string url = "https://blank.org/";
        using var qrGenerator = new QRCodeGenerator();
        using QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        using var qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrBytes = qrCode.GetGraphic(20);

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "blank-site-qr.png");
        File.WriteAllBytes(outputPath, qrBytes);
        return outputPath;
    }
}
