
using Services.Abstractions;
using Services.Contracts;

namespace Services.Implementations;

public class TextService : ITextService
{
    /// <summary>
    ///  считаем количество пробелов и обновляем объекты , считанные из файлов
    /// </summary>
    /// <param name="infoFiles"></param>
    /// <returns></returns>
    public async Task<CurrentFileInfo[]> UpdateCountsHelperAsync(CurrentFileInfo[] infoFiles)
    {
        foreach (CurrentFileInfo info in infoFiles)
            info.CountWhitespace = GetWhitespaceCount(info.Text);
        return infoFiles;
    }

    /// <summary>
    /// считаем количество пробелов в строке
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private int GetWhitespaceCount(string text)
    {
        return text.Count(x => x == ' ');
    }
}

