using dropbox_backend.Application.DTOs;
using dropbox_backend.Domain.Entities;
namespace dropbox_backend.Application.Services;
public static class Mapper {
    public static FolderDto ToDto(Folder entity) => new() { Id = entity.Id, Name = entity.Name, ModifiedDate = entity.ModifiedDate, InsideFiles = entity.InsideFiles, SharedUsersCount = entity.SharedUsersCount, SharedUsers = entity.SharedUsers.Select(ToDto).ToList() };
    public static Folder ToEntity(FolderDto dto) => new() { Id = dto.Id, Name = dto.Name, ModifiedDate = dto.ModifiedDate, InsideFiles = dto.InsideFiles, SharedUsersCount = dto.SharedUsersCount, SharedUsers = dto.SharedUsers.Select(ToEntity).ToList() };
    public static NavigationItemDto ToDto(NavigationItem entity) => new() { Id = entity.Id, Label = entity.Label, Icon = entity.Icon, Order = entity.Order };
    public static RecentFileDto ToDto(RecentFile entity) => new() { Id = entity.Id, Name = entity.Name, Size = entity.Size, ModifiedDate = entity.ModifiedDate, Type = entity.Type, Icon = entity.Icon, SharedUsersCount = entity.SharedUsersCount, SharedUsers = entity.SharedUsers.Select(ToDto).ToList() };
    public static RecentFile ToEntity(RecentFileDto dto) => new() { Id = dto.Id, Name = dto.Name, Size = dto.Size, ModifiedDate = dto.ModifiedDate, Type = dto.Type, Icon = dto.Icon, SharedUsersCount = dto.SharedUsersCount, SharedUsers = dto.SharedUsers.Select(ToEntity).ToList() };
    public static SharedUserDto ToDto(SharedUser entity) => new() { Id = entity.Id, Name = entity.Name, Avatar = entity.Avatar };
    public static SharedUser ToEntity(SharedUserDto dto) => new() { Id = dto.Id, Name = dto.Name, Avatar = dto.Avatar };
    public static StorageInfoDto ToDto(StorageInfo entity) => new() { Id = entity.Id, Used = entity.Used, Total = entity.Total, Unit = entity.Unit, Percentage = entity.Percentage };
    public static StorageInfo ToEntity(StorageInfoDto dto) => new() { Id = dto.Id, Used = dto.Used, Total = dto.Total, Unit = dto.Unit, Percentage = dto.Percentage };
    public static UserProfileDto ToDto(UserProfile entity) => new() { Id = entity.Id, Name = entity.Name, Avatar = entity.Avatar };
    public static UserProfile ToEntity(UserProfileDto dto) => new() { Id = dto.Id, Name = dto.Name, Avatar = dto.Avatar };
}
