namespace NewLoger.Logger
{
    using System;
    using NewLoger.Enum;
    using NewLoger.File_Service;

    /// <summary>
    /// Logger class.
    /// </summary>
    public class Loger
    {
        private static readonly Lazy<Loger> LazyLog = new Lazy<Loger>(() => new Loger());
        private readonly FileService fileService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Loger"/> class.
        /// Initialising file service to work with it.
        /// </summary>
        private Loger()
        {
            this.fileService = FileService.GetInstance();
        }

        /// <summary>
        /// Det referens to legger.
        /// </summary>
        /// <returns>logger.</returns>
        public static Loger GetInstance()
        {
            return LazyLog.Value;
        }

        /// <summary>
        /// Method to log messages.
        /// </summary>
        /// <param name="type">log type..</param>
        /// <param name="message">text of message.</param>
        /// <param name="ex">text of smessage.</param>
        public void Log(LogType type, string message, Exception ex = null)
        {
            if (ex != null)
            {
                message = $"{message}{ex.Message}";
            }

            string log = $"{DateTime.UtcNow.ToString("hh:mm:ss")}:{type}:{message}";
            this.fileService.Input(log);
            Console.WriteLine(log);
        }
    }
}
