using System.Runtime.Serialization;

namespace Services.Exceptions;

    /// <summary>
    /// Класс исключений для информирования об ошибке при считывании данных из файлов
    /// </summary>
    public class DataReadException : Exception
    {
        public DataReadException()
        {
        }

        public DataReadException(string message)
            : base(message)
        {
        }

        public DataReadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataReadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

