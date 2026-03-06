using System.Text.Json.Serialization;

namespace dropbox_backend.Models;

public class NavigationItem
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    
    [JsonIgnore]
    public int Order { get; set; }
}
