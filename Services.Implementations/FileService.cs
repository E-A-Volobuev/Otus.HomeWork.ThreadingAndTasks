using Services.Abstractions;
using Services.Contracts;
using Services.Exceptions;

namespace Services.Implementations;

public class FileService : IFileService
{
    public string[] GetFilesByFolder(string path)
    {
        if (Directory.Exists(path))
            return Directory.GetFiles(path);

        throw new DataReadException("Каталог не существует");
    }
    /// <summary>
    /// параллельно читаем файлы из папки
    /// </summary>
    /// <param name="filesByFolder"></param>
    /// <returns></returns>
    public async Task<CurrentFileInfo[]> GetTextArrayHelperAsync(string[] filesByFolder)
    {
        List<Task<CurrentFileInfo>> tasks = new();
        foreach (string file in filesByFolder)
            tasks.Add(GetTextByFileAsync(file));
        return await Task.WhenAll(tasks);
    }
    /// считываем текст из файла
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private async Task<CurrentFileInfo> GetTextByFileAsync(string path)
    {
        try
        {
            // чтение файла
            CurrentFileInfo info = new() { Path = path, Text = await File.ReadAllTextAsync(path) };
            return info;
        }
        catch (Exception)
        {
            throw new DataReadException(string.Concat("Ошибка чтения файла: ", path));
        }
    }
}

