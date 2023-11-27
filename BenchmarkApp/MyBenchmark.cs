
using BenchmarkDotNet.Attributes;
using Services.Contracts;
using Services.Implementations;

namespace BenchmarkApp;

[MemoryDiagnoser]
public class MyBenchmark
{
    private const string _path = @"C:\Users\evgeniy.volobuev\Desktop\тест";
    private readonly FileService _fileService = new ();
    private readonly TextService _textService = new();

    [Benchmark]
    public void ReadFiles()
    {
        string[] allFiles = _fileService.GetFilesByFolder(_path);
        CurrentFileInfo[] initialize = _fileService.GetTextArrayHelperAsync(allFiles).GetAwaiter().GetResult();
        CurrentFileInfo[] result = _textService.UpdateCountsHelperAsync(initialize).GetAwaiter().GetResult();
    }
}

