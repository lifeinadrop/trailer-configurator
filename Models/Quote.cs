using System.Collections.Generic;
using System.Linq;

namespace TcTeardrops.Configurator.Models;

public class Quote
{
    public TrailerModel? SelectedModel { get; set; }
    public decimal BasePrice => SelectedModel?.BasePrice ?? 0m;
    public List<ConfigOption> SelectedOptions { get; set; } = new();

    public decimal TotalPrice => BasePrice + SelectedOptions.Sum(o => o.Price);

    public void ToggleOption(ConfigOption option)
    {
        var existing = SelectedOptions.FirstOrDefault(o => o.Id == option.Id);
        if (existing != null)
        {
            SelectedOptions.Remove(existing);
        }
        else
        {
            // If the option belongs to a group (e.g. "Color"), remove other options from that group first
            if (!string.IsNullOrEmpty(option.Group))
            {
                var othersInGroup = SelectedOptions.Where(o => o.Group == option.Group && o.Group != "").ToList();
                foreach (var other in othersInGroup)
                {
                    SelectedOptions.Remove(other);
                }
            }
            SelectedOptions.Add(option);
        }
    }

    public bool HasOption(string optionId)
    {
        return SelectedOptions.Any(o => o.Id == optionId);
    }
}
