using System.Text.Json.Serialization;

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

public class NavigationItemDto
{
    public string Id { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    [JsonIgnore]
    public int Order { get; set; }
}

public class RecentFileDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string ModifiedDate { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int SharedUsersCount { get; set; }
    public List<SharedUserDto> SharedUsers { get; set; } = new();
}

public class SharedUserDto
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}

public class StorageInfoDto
{
    public int Id { get; set; }
    public int Used { get; set; }
    public int Total { get; set; }
    public string Unit { get; set; } = string.Empty;
    public int Percentage { get; set; }
}

public class UserProfileDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}
