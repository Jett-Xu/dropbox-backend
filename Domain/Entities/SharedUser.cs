namespace dropbox_backend.Domain.Entities;

public class SharedUser
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
    public int? FolderId { get; set; }
    public int? RecentFileId { get; set; }
}
