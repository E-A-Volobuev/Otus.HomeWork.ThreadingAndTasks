
namespace Services.Contracts;

public class CurrentFileInfo
{
    /// <summary>
    /// путь к файлу
    /// </summary>
    public string Path { get; set; }
    /// <summary>
    /// текст внутри файла
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// количество пробелов
    /// </summary>
    public int CountWhitespace { get; set; }
}

