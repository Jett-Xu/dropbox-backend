using System.Text.Json.Serialization;

namespace dropbox_backend.Application.DTOs;

public class NavigationItemDto
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    [JsonIgnore]
    public int Order { get; set; }
}
