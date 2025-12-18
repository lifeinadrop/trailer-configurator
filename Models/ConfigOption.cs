namespace TcTeardrops.Configurator.Models;

public class ConfigOption
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty; // e.g., "Exterior", "Interior"
    public string Group { get; set; } = string.Empty; // e.g., "Color", "Wheels" - for disjoint selection
}
