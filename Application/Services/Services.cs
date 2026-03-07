using dropbox_backend.Application.DTOs;
using dropbox_backend.Application.Interfaces;
using dropbox_backend.Domain.Entities;

namespace dropbox_backend.Application.Services;

public static class Mapper
{
    public static FolderDto ToDto(Folder entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        ModifiedDate = entity.ModifiedDate,
        InsideFiles = entity.InsideFiles,
        SharedUsersCount = entity.SharedUsersCount,
        SharedUsers = entity.SharedUsers.Select(ToDto).ToList()
    };
    public static Folder ToEntity(FolderDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        ModifiedDate = dto.ModifiedDate,
        InsideFiles = dto.InsideFiles,
        SharedUsersCount = dto.SharedUsersCount,
        SharedUsers = dto.SharedUsers.Select(ToEntity).ToList()
    };

    public static NavigationItemDto ToDto(NavigationItem entity) => new()
    {
        Id = entity.Id,
        Label = entity.Label,
        Icon = entity.Icon,
        Order = entity.Order
    };

    public static RecentFileDto ToDto(RecentFile entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Size = entity.Size,
        ModifiedDate = entity.ModifiedDate,
        Type = entity.Type,
        Icon = entity.Icon,
        SharedUsersCount = entity.SharedUsersCount,
        SharedUsers = entity.SharedUsers.Select(ToDto).ToList()
    };
    public static RecentFile ToEntity(RecentFileDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Size = dto.Size,
        ModifiedDate = dto.ModifiedDate,
        Type = dto.Type,
        Icon = dto.Icon,
        SharedUsersCount = dto.SharedUsersCount,
        SharedUsers = dto.SharedUsers.Select(ToEntity).ToList()
    };

    public static SharedUserDto ToDto(SharedUser entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Avatar = entity.Avatar
    };
    public static SharedUser ToEntity(SharedUserDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Avatar = dto.Avatar
    };

    public static StorageInfoDto ToDto(StorageInfo entity) => new()
    {
        Id = entity.Id,
        Used = entity.Used,
        Total = entity.Total,
        Unit = entity.Unit,
        Percentage = entity.Percentage
    };
    public static StorageInfo ToEntity(StorageInfoDto dto) => new()
    {
        Id = dto.Id,
        Used = dto.Used,
        Total = dto.Total,
        Unit = dto.Unit,
        Percentage = dto.Percentage
    };

    public static UserProfileDto ToDto(UserProfile entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Avatar = entity.Avatar
    };
    public static UserProfile ToEntity(UserProfileDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Avatar = dto.Avatar
    };
}

public class FolderService : IFolderService
{
    private readonly IFolderRepository _repository;
    public FolderService(IFolderRepository repository) => _repository = repository;

    public async Task<IEnumerable<FolderDto>> GetAllFoldersAsync() => 
        (await _repository.GetAllAsync()).Select(Mapper.ToDto);

    public async Task<FolderDto?> GetFolderByIdAsync(int id)
    {
        var folder = await _repository.GetByIdAsync(id);
        return folder == null ? null : Mapper.ToDto(folder);
    }

    public async Task<FolderDto> CreateFolderAsync(FolderDto folderDto)
    {
        var folder = Mapper.ToEntity(folderDto);
        await _repository.AddAsync(folder);
        return Mapper.ToDto(folder);
    }

    public async Task<bool> UpdateFolderAsync(int id, FolderDto folderDto)
    {
        if (id != folderDto.Id) return false;
        if (!await _repository.ExistsAsync(id)) return false;
        await _repository.UpdateAsync(Mapper.ToEntity(folderDto));
        return true;
    }

    public async Task<bool> DeleteFolderAsync(int id)
    {
        var folder = await _repository.GetByIdAsync(id);
        if (folder == null) return false;
        await _repository.DeleteAsync(folder);
        return true;
    }
}

public class NavigationService : INavigationService
{
    private readonly INavigationRepository _repository;
    public NavigationService(INavigationRepository repository) => _repository = repository;
    public async Task<IEnumerable<NavigationItemDto>> GetNavigationAsync() => 
        (await _repository.GetAllAsync()).Select(Mapper.ToDto);
}

public class RecentFileService : IRecentFileService
{
    private readonly IRecentFileRepository _repository;
    public RecentFileService(IRecentFileRepository repository) => _repository = repository;

    public async Task<IEnumerable<RecentFileDto>> GetAllRecentFilesAsync() => 
        (await _repository.GetAllAsync()).Select(Mapper.ToDto);

    public async Task<RecentFileDto?> GetRecentFileByIdAsync(int id)
    {
        var file = await _repository.GetByIdAsync(id);
        return file == null ? null : Mapper.ToDto(file);
    }

    public async Task<RecentFileDto> CreateRecentFileAsync(RecentFileDto fileDto)
    {
        var file = Mapper.ToEntity(fileDto);
        await _repository.AddAsync(file);
        return Mapper.ToDto(file);
    }

    public async Task<bool> UpdateRecentFileAsync(int id, RecentFileDto fileDto)
    {
        if (id != fileDto.Id) return false;
        if (!await _repository.ExistsAsync(id)) return false;
        await _repository.UpdateAsync(Mapper.ToEntity(fileDto));
        return true;
    }

    public async Task<bool> DeleteRecentFileAsync(int id)
    {
        var file = await _repository.GetByIdAsync(id);
        if (file == null) return false;
        await _repository.DeleteAsync(file);
        return true;
    }
}

public class StorageService : IStorageService
{
    private readonly IStorageRepository _repository;
    public StorageService(IStorageRepository repository) => _repository = repository;
    public async Task<StorageInfoDto?> GetStorageInfoAsync()
    {
        var info = await _repository.GetAsync();
        return info == null ? null : Mapper.ToDto(info);
    }
    public async Task<bool> UpdateStorageInfoAsync(StorageInfoDto storageDto)
    {
        var info = await _repository.GetAsync();
        if (info == null) return false;
        info.Used = storageDto.Used;
        info.Total = storageDto.Total;
        info.Unit = storageDto.Unit;
        info.Percentage = storageDto.Percentage;
        await _repository.UpdateAsync(info);
        return true;
    }
}

public class UserProfileService : IUserProfileService
{
    private readonly IUserProfileRepository _repository;
    public UserProfileService(IUserProfileRepository repository) => _repository = repository;
    public async Task<UserProfileDto?> GetUserProfileAsync()
    {
        var info = await _repository.GetAsync();
        return info == null ? null : Mapper.ToDto(info);
    }
    public async Task<bool> UpdateUserProfileAsync(UserProfileDto profileDto)
    {
        var info = await _repository.GetAsync();
        if (info == null) return false;
        info.Name = profileDto.Name;
        info.Avatar = profileDto.Avatar;
        await _repository.UpdateAsync(info);
        return true;
    }
}
