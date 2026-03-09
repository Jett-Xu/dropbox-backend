using System.Text.Json.Serialization;

namespace dropbox_backend.Application.DTOs;

public class SharedUserDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}
