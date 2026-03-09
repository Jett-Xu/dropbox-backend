namespace dropbox_backend.Application.DTOs;

public class FolderDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ModifiedDate { get; set; } = string.Empty;
    public int InsideFiles { get; set; }
    public int SharedUsersCount { get; set; }
    public List<SharedUserDto> SharedUsers { get; set; } = new();
}
