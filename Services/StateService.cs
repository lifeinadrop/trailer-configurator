using System;
using System.Collections.Generic;
using TcTeardrops.Configurator.Models;

namespace TcTeardrops.Configurator.Services;

public class StateService
{
    public Quote CurrentQuote { get; private set; } = new();
    public event Action? OnChange;

    public void ToggleOption(ConfigOption option)
    {
        CurrentQuote.ToggleOption(option);
        NotifyStateChanged();
    }

    public void SelectModel(TrailerModel model)
    {
        CurrentQuote.SelectedModel = model;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();

    public List<TrailerModel> AvailableModels { get; } = new()
    {
        new TrailerModel { Id = "oasis", Name = "Oasis", BasePrice = 8500m, Description = "Lightweight and simple. Perfect for beginners.", ImageUrl = "images/exterior.png" },
        new TrailerModel { Id = "original", Name = "Original", BasePrice = 11000m, Description = "The classic teardrop shape and features.", ImageUrl = "images/exterior.png" },
        new TrailerModel { Id = "overland", Name = "Overland", BasePrice = 14500m, Description = "Built tough for off-road adventures.", ImageUrl = "images/exterior.png" },
        new TrailerModel { Id = "adventure", Name = "Adventure Edition", BasePrice = 12500m, Description = "Loaded with popular features.", ImageUrl = "images/exterior.png" },
        new TrailerModel { Id = "offroad-exp", Name = "Off-Road Expedition", BasePrice = 16000m, Description = "Extreme durability for extreme locations.", ImageUrl = "images/exterior.png" },
        new TrailerModel { Id = "tcterrain", Name = "TC Terrain", BasePrice = 20000m, Description = "The newest, most rugged member of the family.", ImageUrl = "images/exterior.png" }
    };

    // Data Store for Options (In a real app, this would come from an API)
    public List<ConfigOption> AvailableOptions { get; } = new()
    {
        // --- Exterior ---
        // Colors
        new ConfigOption { Id = "ext-col-white", Name = "Polar White", Category = "Exterior", Group = "Color", Price = 0, Description = "Standard clean white finish.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "ext-col-silver", Name = "Silver Frost", Category = "Exterior", Group = "Color", Price = 450, Description = "Metallic silver aluminum finish.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "ext-col-charcoal", Name = "Charcoal Grey", Category = "Exterior", Group = "Color", Price = 450, Description = "Dark metallic grey finish.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "ext-col-black", Name = "Midnight Black", Category = "Exterior", Group = "Color", Price = 450, Description = "Stealthy matte black finish.", ImageUrl = "images/exterior.png" },

        // Side Protection
        new ConfigOption { Id = "ext-side-diamond", Name = "Diamond Plate Sides", Category = "Exterior", Group = "Protection", Price = 600, Description = "Rugged diamond plate protection for side walls.", ImageUrl = "images/exterior.png" },
        
        // Wheels
        new ConfigOption { Id = "ext-whl-std", Name = "Standard Wheels", Category = "Exterior", Group = "Wheels", Price = 0, Description = "14 inch steel wheels with radial tires.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "ext-whl-offroad", Name = "Off-Road Allow Wheels", Category = "Exterior", Group = "Wheels", Price = 800, Description = "15-inch rugged alloy wheels with A/T tires.", ImageUrl = "images/exterior.png" },

        // Toolbox
        new ConfigOption { Id = "ext-box-front", Name = "Front Storage Box", Category = "Exterior", Group = "", Price = 550, Description = "Aluminum tongue box for extra storage.", ImageUrl = "images/exterior.png" },

        // --- Interior ---
        // Mattress
        new ConfigOption { Id = "int-mat-std", Name = "Standard Mattress", Category = "Interior", Group = "Mattress", Price = 0, Description = "4-inch high density foam.", ImageUrl = "images/interior.png" },
        new ConfigOption { Id = "int-mat-mem", Name = "Memory Foam Upgrade", Category = "Interior", Group = "Mattress", Price = 300, Description = "Upgraded 6-inch memory foam queen mattress.", ImageUrl = "images/interior.png" },

        // Cabinetry
        new ConfigOption { Id = "int-cab-std", Name = "Standard Shelving", Category = "Interior", Group = "Cabinets", Price = 0, Description = "Simple open shelving unit.", ImageUrl = "images/interior.png" },
        new ConfigOption { Id = "int-cab-wood", Name = "Hardwood Cabinetry", Category = "Interior", Group = "Cabinets", Price = 1200, Description = "Hand-crafted birch cabinetry with doors.", ImageUrl = "images/interior.png" },
        
        // --- Kitchen ---
        new ConfigOption { Id = "kit-st-2b", Name = "2-Burner Stove", Category = "Kitchen", Group = "Stove", Price = 250, Description = "Slide-out stainless steel propane stove.", ImageUrl = "images/kitchen.png" },
        new ConfigOption { Id = "kit-sink", Name = "Stainless Sink", Category = "Kitchen", Group = "", Price = 200, Description = "Integrated sink with hand pump.", ImageUrl = "images/kitchen.png" },
        new ConfigOption { Id = "kit-cool-yeti", Name = "Yeti Cooler Slide", Category = "Kitchen", Group = "", Price = 150, Description = "Heavy duty slide for your cooler.", ImageUrl = "images/kitchen.png" },
        new ConfigOption { Id = "kit-table", Name = "Detachable Table", Category = "Kitchen", Group = "", Price = 125, Description = "Side mounted table for extra prep space.", ImageUrl = "images/kitchen.png" },

        // --- Accessories ---
        new ConfigOption { Id = "acc-roof-rack", Name = "Roof Rack System", Category = "Accessories", Group = "", Price = 650, Description = "Thule tracks and crossbars (200lb dynamic load).", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "acc-awning", Name = "Side Awning", Category = "Accessories", Group = "Awning", Price = 400, Description = "6ft x 8ft retractable awning.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "acc-awning-270", Name = "270 Degree Awning", Category = "Accessories", Group = "Awning", Price = 1100, Description = "Massive 270 degree coverage around rear.", ImageUrl = "images/exterior.png" },
        new ConfigOption { Id = "acc-solar", Name = "100W Solar Panel", Category = "Accessories", Group = "", Price = 350, Description = "Roof mounted flexible solar with controller.", ImageUrl = "images/exterior.png" },
    };
}
