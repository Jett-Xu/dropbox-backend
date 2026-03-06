using System.Text.Json.Serialization;

namespace dropbox_backend.Models;

public class SharedUser
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;

    [JsonIgnore]
    public int? FolderId { get; set; }
    [JsonIgnore]
    public int? RecentFileId { get; set; }
}
