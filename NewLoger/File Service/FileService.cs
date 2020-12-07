namespace NewLoger.File_Service
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Class for working with files.
    /// </summary>
    public class FileService
    {
        private static readonly Lazy<FileService> Lazy = new Lazy<FileService>(() => new FileService());
        private readonly string fileName;
        private readonly string diractoryName = "Logs\\";
        private StreamWriter streamWriter;

        private FileService()
        {
            this.DiractoryCheck();
            this.fileName = $"{DateTime.UtcNow.ToString("hh:mm:ss dd:MM:yyyy")}.txt";
            this.streamWriter = new StreamWriter($"{this.diractoryName}{this.fileName}", true);
            this.CheckFiles();
        }

        /// <summary>
        /// Return our singleton.
        /// </summary>
        /// <returns>ref.</returns>
        public static FileService GetInstance()
        {
            return Lazy.Value;
        }

        /// <summary>
        /// Method for input log text into file.
        /// </summary>
        /// <param name="log">log text.</param>
        public void Input(string log)
        {
            this.streamWriter.WriteLine(log);
        }

        private void DiractoryCheck()
        {
            if (!Directory.Exists(this.diractoryName))
            {
                Directory.CreateDirectory(this.diractoryName);
            }
        }

        private void CheckFiles()
        {
            var filesPath = Directory.GetFiles(this.diractoryName, $"*.txt", SearchOption.TopDirectoryOnly);
            if (filesPath.Length > 0)
            {
                var files = new List<FileInfo>();

                foreach (string path in filesPath)
                {
                    files.Add(new FileInfo(path));
                }

                for (var i = 0; i < files.Count; i++)
                {
                    if (DateTime.UtcNow - files[i].CreationTimeUtc > TimeSpan.FromDays(2) || i >= 2)
                    {
                        File.Delete(files[i].FullName);
                    }
                }
            }
        }
    }
}
