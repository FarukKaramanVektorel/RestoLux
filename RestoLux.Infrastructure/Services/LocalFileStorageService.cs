using RestoLux.Domain.Interfaces;

namespace RestoLux.Infrastructure.Services;

public class LocalFileStorageService : IFileStorageService
{
    private readonly string _rootPath;

    public LocalFileStorageService(string rootPath)
    {
        _rootPath = rootPath;
        Directory.CreateDirectory(_rootPath);
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType, string? folder = null, CancellationToken cancellationToken = default)
    {
        var targetFolder = string.IsNullOrWhiteSpace(folder) ? _rootPath : Path.Combine(_rootPath, folder);
        Directory.CreateDirectory(targetFolder);

        var safeName = $"{Guid.NewGuid():N}{Path.GetExtension(fileName)}";
        var fullPath = Path.Combine(targetFolder, safeName);

        using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, useAsync: true))
        {
            await fileStream.CopyToAsync(fs, cancellationToken);
        }

        var relative = string.IsNullOrWhiteSpace(folder) ? safeName : $"{folder}/{safeName}";
        return relative.Replace('\\', '/');
    }

    public Task DeleteFileAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var full = Path.Combine(_rootPath, filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
        if (File.Exists(full))
            File.Delete(full);
        return Task.CompletedTask;
    }

    public Task<bool> FileExistsAsync(string filePath, CancellationToken cancellationToken = default)
    {
        var full = Path.Combine(_rootPath, filePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
        return Task.FromResult(File.Exists(full));
    }

    public string GetFileUrl(string filePath)
    {
        return "/uploads/" + filePath.TrimStart('/').Replace('\\', '/');
    }
}