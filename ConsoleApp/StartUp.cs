using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using Services.Constants;
using Services.Contracts;
using Services.Exceptions;

namespace ConsoleApp;

//TODO:добавить бенчмарки
public class StartUp : BackgroundService
{
    private readonly IFileService _fileService;
    private readonly ITextService _textService;
    private readonly ILogger<StartUp> _logger;

    public StartUp(IFileService fileService, ITextService textService, ILogger<StartUp> logger)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _textService = textService ?? throw new ArgumentNullException(nameof(textService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            try
            {
                string path = GetPathByFolder();
                string[] filesByFolder = _fileService.GetFilesByFolder(path);
                //var watch = new Stopwatch();
                //watch.Start();
                CurrentFileInfo[] infoFilesArray = await _fileService.GetTextArrayHelperAsync(filesByFolder);
                infoFilesArray = await _textService.UpdateCountsHelperAsync(infoFilesArray);
                //watch.Stop();

                ShowResult(infoFilesArray);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Path: {ex.StackTrace}  Time:{DateTime.Now.ToLongTimeString()} " +
                                 $"Detail :{ex.Message}");
                if (ex is DataReadException)
                    Console.WriteLine(ex.Message);
                
            }
        }
    }

    private void ShowResult(CurrentFileInfo[] infoFilesArray)
    {
        Console.WriteLine("Количество пробелов в файлах:\n");
        foreach (CurrentFileInfo info in infoFilesArray)
            Console.WriteLine(string.Concat(info.Path, " : ", info.CountWhitespace));
    }
    private string GetPathByFolder()
    {
        Console.WriteLine("Программа считывает файлы параллельно из указанной папки и подсчитывает количество пробелов.\n");
        Console.WriteLine("Для выхода из приложения введите: \"Exit\"");
        Console.WriteLine("Укажите путь к папке:\n");

        string path= Console.ReadLine();
        if (path.ToLower() == ServicesConstants.ExitConstant)
            Environment.Exit(0);

        return path;
    }
}

