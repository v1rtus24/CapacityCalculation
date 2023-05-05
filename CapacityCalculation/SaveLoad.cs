using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapacityCalculation
{
    public class SaveLoad
    {
        /// <summary>
        /// Возвращает и задает путь по умолчанию к файлу>. 
        /// </summary>
        public static string FilePath { get; set; } = Environment.GetFolderPath(
            Environment.SpecialFolder.Personal) + @"\CapacityCalc\";

        /// <summary>
        /// Метод сохранения данных в файл
        /// </summary>
        /// <param name="files"></param>
        public static void SaveToFile<T>(T files, string filePath) where T: List<Cabinet>
        {
            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            }
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, files);
            }
        }

        /// <summary>
        /// Метод загрузки данных из файла
        /// </summary>
        /// <returns></returns>
        //public static Project LoadFromFile(string filePath)
        //{
        //    if (!File.Exists(filePath))
        //    {
        //        return new Project();
        //    }
        //    try
        //    {
        //        JsonSerializer serializer = new JsonSerializer();
        //        //Открываем поток для чтения из файла с указанием пути
        //        using (StreamReader sr = new StreamReader(filePath))
        //        using (JsonReader reader = new JsonTextReader(sr))
        //        {
        //            //Вызываем десериализацию и явно преобразуем результат в целевой тип данных
        //            return (Project)serializer.Deserialize<Project>(reader);
        //        }
        //    }
        //    catch
        //    {
        //        return new Project();
        //    }
        //}
    }
}
