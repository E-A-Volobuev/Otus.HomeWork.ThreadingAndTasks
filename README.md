# Otus.HomeWork.ThreadingAndTasks
## Идея
Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
Замерьте время выполнения кода (класс Stopwatch и с помощью Benchmark).

## Функционал
Программа реализована в чистой архитектуре с использованием DependencyInjection.
Для чтения файлов с локальной папки применены многопоточность и асинхронность.
Измерение времени выполнения кода реализовано с ипользованием класса Stopwatch.
Дополнительно в решение добавлен проект бенчмарков для замера производительности (Время выполнения кода и потребление памяти).
Вывод бенчмарков:
![alt text]([https://github.com/E-A-Volobuev/Otus.MqRabbit/blob/master/%D0%93%D0%BB%D0%B0%D0%B2%D0%BD%D0%BE%D0%B5%20%D0%BC%D0%B5%D0%BD%D1%8E.png](https://github.com/E-A-Volobuev/Otus.HomeWork.ThreadingAndTasks/blob/master/BenchmarkResult.png)https://github.com/E-A-Volobuev/Otus.HomeWork.ThreadingAndTasks/blob/master/BenchmarkResult.png)
