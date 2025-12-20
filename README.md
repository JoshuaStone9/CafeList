# CafeList Project
A small C# console app that assembles curated café menu sections (coffee, chocolate, cold drinks, syrups, bottled drinks, and food), tags dietary-friendly choices, prints them to the console, and generates a QR code pointing at a placeholder ordering site.

## Table of Contents
- [Overview](#overview)
- [High-Level Architecture](#high-level-architecture)
- [Data Model](#data-model)
- [Control Flow](#control-flow)
- [QR Code Integration](#qr-code-integration)
- [Local Assets (blank-site-qrpng)](#local-assets-blank-site-qrpng)
- [Configuration & Environment](#configuration--environment)
- [How to Run](#how-to-run)
- [Potential Improvements](#potential-improvements)

## Overview
This project is a console based menu showcase with multiple beverage and food sections. Each category is stored in its own class and every entry includes a name and description, with food entries optionally marked vegan or gluten free. The app prints the sections with consistent formatting and highlights vegan options in a dedicated list then produces a QR code image so guests can scan to reach a blank placeholder page.

You can:

- Build static menu sections for coffee, chocolate drinks, cold drinks, bottled options, syrups and food.
- Display all sections in a single console run with consistent formatting.
- Highlight vegan food choices automatically.
- Generate a QR code asset (`blank-site-qr.png`) that points to https://blank.org as a stand-in ordering link.

All menu data currently lives directly in code, making the project easy to reason about and extend.

## High-Level Architecture
Everything lives inside the `CafeList` namespace with `Program` orchestrating the flow.

You can think of it roughly in layers:

**Presentation / UI Layer (Console)**  
`Program` formats headings, prints menu lines and outputs the QR code file path.

**Domain Logic (Menu Building)**  
The static `BuildMenu()` factories on classes like `CoffeeList`, `ColdDrinkList` and `FoodList` build strongly typed lists of menu items, while a `PrintMenu` helper renders them.

**Shared Abstraction (IMenuItem)**  
The `IMenuItem` interface ensures that every menu entry exposes `Name` and `Description`, enabling the printing logic to operate across categories.

**Asset Generation Layer (QRCoder)**  
`GenerateBlankSiteQr()` uses the QRCoder package to render a PNG pointing to https://blank.org/ and save it locally.

## Data Model
The app uses small immutable objects backed by lists

**IMenuItem**  
Interface describing `Name` and `Description`. All menu entry classes implement it.

**CoffeeList / ChocolateList / ColdDrinkList / SyrupList / BottleDrinkList**  
Each type represents a menu category with hard-coded options exposed through a static `BuildMenu()` method returning `IReadOnlyList<T>`.

**FoodList**  
Extends `IMenuItem` with `IsVegan`, `IsVegetarian` and `IsGlutenFree` to support dietary filtering.

Example:

```
var coffeeMenu = CoffeeList.BuildMenu();
var syrupMenu = SyrupList.BuildMenu();
var veganOnly = FoodList.BuildMenu().Where(f => f.IsVegan);
```

Meaning: load all category lists, then filter the food list for vegan entries to show separately.

## Control Flow
**Program Startup**
1. Construct every menu category via its static `BuildMenu()` method.
2. Print a welcome banner.
3. Call `PrintMenu` for each category plus a vegan-only view based on `FoodList`.
4. Generate and persist the QR code image, then display its path.

**Menu Rendering**
- `PrintMenu(string title, IEnumerable<IMenuItem> items)` writes a section header followed by `Name - Description` lines.
- The method supports any `IMenuItem`, so adding a new category only requires implementing the interface.

**Asset Generation**
- `GenerateBlankSiteQr()` handles QR creation, file writing, and path return.

## QR Code Integration
QR codes are produced using the [QRCoder](https://www.nuget.org/packages/QRCoder) package:

1. Instantiate `QRCodeGenerator` and create a code for the constant URL (`https://blank.org/`).
2. Render it via `PngByteQRCode` at a scale of 20.
3. Write the resulting bytes to `blank-site-qr.png` in the current working directory.

This provides a ready-to-scan artifact even though the menus themselves are console-based.

## Local Assets (blank-site-qr.png)
Rather than storing menu data in files, the project only writes one artifact: the generated QR code image. Each run overwrites `blank-site-qr.png` in the repo root (or execution directory), ensuring the asset always reflects the latest build. Deleting the file is safe because the app will recreate it on the next execution.

This is an aspect which I will be extending in order to produce one static qr code when the menu if fully initiated.

## Configuration & Environment
- Target framework: `.NET 9.0`
- Dependencies: `QRCoder` NuGet package (handled via `CafeList.csproj`)
- No environment variables or app settings are required; all data is static.

Optional tooling:

- Any terminal that can run `dotnet` CLI commands.
- A console capable of rendering UTF-8 text (default on most systems).

## How to Run
```bash
dotnet restore
dotnet run
```

Running the app prints every menu section to the console and writes `blank-site-qr.png` next to the executable.

## Potential Improvements
- Load menu data from JSON or a database instead of hard-coded lists.
- Add prices, allergens, and seasonal availability metadata.
- Provide interactive filtering (e.g., choose vegan, decaf, or iced) via command-line prompts.
- Parameterize the QR target URL or integrate with a real ordering site.
- Export menus to HTML/PDF for easier sharing in addition to console output.
