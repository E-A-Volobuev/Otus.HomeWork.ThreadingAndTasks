
using Services.Contracts;

namespace Services.Abstractions;

public interface ITextService
{
    /// <summary>
    ///  считаем количество пробелов и обновляем объекты , считанные из файлов
    /// </summary>
    /// <param name="infoFiles"></param>
    /// <returns></returns>
    Task<CurrentFileInfo[]> UpdateCountsHelperAsync(CurrentFileInfo[] infoFiles);
}

