using System;
using System.IO;
using Newtonsoft.Json;


namespace ContactsApp
{
    /// <summary>
    /// Класс, сериализующий список контактов
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        /// Сериализация
        /// </summary>
        public static void SaveToFile(Project data, string filename)
        {

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Дессериализация
        /// </summary>
        public static Project LoadFromFile(string filename)
        {  

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (StreamReader sr = new StreamReader(filename))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                Project prog = new Project();
                prog = (Project)serializer.Deserialize<Project>(reader);                
                if (prog == null)             
                {
                    Project emptyProject = new Project();
                    return emptyProject;
                }
                //return (Project)serializer.Deserialize<Project>(reader); Почему не работает?
                // И выдает ошибку, если использовать (Project)serializer... вместо prog 
                return prog;
                }
            }
            catch (Exception e)
            {
                Project emptyProject = new Project();
                Console.WriteLine(e.Message);
                return emptyProject;
            }
        }
    }
}
