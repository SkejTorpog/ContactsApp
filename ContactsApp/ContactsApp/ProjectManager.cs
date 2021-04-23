using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;

namespace ContactsApp
{
    /// <summary>
    /// Класс, сериализующий список контактов
    /// </summary>
    public static class ProjectManager
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

            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(filename))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                return (Project)serializer.Deserialize<Project>(reader);
            }

        }
    }
}
