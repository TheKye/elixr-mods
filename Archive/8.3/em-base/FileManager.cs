namespace Eco.EM
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;
    public static class FileManager<T> where T : class, new()
    {
        public static bool WriteToFile(T input, string SavePath, string FileName)
        {
            try
            {
                var stringContent = Eco.Core.Serialization.SerializationUtils.SerializeRawJsonIndented(input);
                
                FileManager.WriteToFile(stringContent, SavePath, FileName);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("FileManager: " + e.Message);

                return false;
            }
        }

        public static T ReadFromFile(string SavePath, string FileName)
        {
            T content = new T();
            
            var stringContent = FileManager.ReadFromFile(SavePath, FileName);

            if (string.IsNullOrWhiteSpace(stringContent))
                return new T();
            else
                content = Eco.Core.Serialization.SerializationUtils.DeserializeJson<T>(stringContent);

            return content;
        }
    }

    public class FileManager
    {
        const string format = ".EM";
        const string ecoFormat = ".eco";

        public static void WriteToFile(string Input, string SavePath, string FileName)
        {
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);

            if (!FileName.EndsWith(format))
                FileName += format;

            using (var file = new StreamWriter(Path.Combine(SavePath, FileName)))
            {
                file.Write(Input);
            }
        }

        public static string ReadFromFile(string SavePath, string FileName)
        {
            if (!FileName.EndsWith(format) && !FileName.EndsWith(ecoFormat))
                FileName += format;

            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
                return string.Empty;
            }

            if (!File.Exists(Path.Combine(SavePath, FileName)))
                return string.Empty;

            var content = string.Empty;

            using (var file = new StreamReader(Path.Combine(SavePath, FileName)))
            {
                content = file.ReadToEnd();
                file.Close();
                file.Dispose();
            }

            return content;
        }
    }
}
