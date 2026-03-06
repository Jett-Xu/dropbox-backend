namespace dropbox_backend.Models;

public class RecentFile
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string ModifiedDate { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int SharedUsersCount { get; set; }
    public List<SharedUser> SharedUsers { get; set; } = new();
}
