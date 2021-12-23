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
        private static readonly string defaultFolder = Environment.
            GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ContactsApp";

        public static readonly string  defaultFilename = defaultFolder + "\\ContactsApp.notes";

        /// <summary>
        /// Сериализация
        /// </summary>
        public static void SaveToFile(Project data, string filename)
        {                 
            Directory.CreateDirectory(defaultFolder);
            
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
                    Project projectData = new Project();
                    projectData = (Project)serializer.Deserialize<Project>(reader);
                    if (projectData == null)
                    {
                        Project emptyProject = new Project();
                        return emptyProject;
                    }

                    return projectData;
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
