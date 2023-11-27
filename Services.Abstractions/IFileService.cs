using Services.Contracts;

namespace Services.Abstractions;

public interface IFileService
{
    /// <summary>
    /// получаем все файлы из каталога
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    string[] GetFilesByFolder(string path);

    /// <summary>
    /// параллельно читаем файлы из папки
    /// </summary>
    /// <param name="filesByFolder"></param>
    /// <returns></returns>
    Task<CurrentFileInfo[]> GetTextArrayHelperAsync(string[] filesByFolder);

}

