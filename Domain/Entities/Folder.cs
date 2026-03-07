namespace dropbox_backend.Domain.Entities;

public class Folder
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ModifiedDate { get; set; } = string.Empty;
    public int InsideFiles { get; set; }
    public int SharedUsersCount { get; set; }
    public List<SharedUser> SharedUsers { get; set; } = new();
}
