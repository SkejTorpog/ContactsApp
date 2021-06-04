using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;

namespace ContactsApp1
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

        //------------Edit last version-------------
        private void EditContactButton_Click(object sender, EventArgs e)
        {
            Contact selectedData = new Contact();
            Contact unupdatedData = new Contact();
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт");
                return;
            }
            if (FindTextBox.Text.Length == 0)
            {
                selectedData = (Contact)prog.contactsList[selectedIndex].Clone();
            }
            else
            {
                selectedData = (Contact)list[selectedIndex].Clone();
                unupdatedData = (Contact)list[selectedIndex].Clone();
            }

            AddEditForm form = new AddEditForm();
            form.Contact = selectedData;
            form.ShowDialog();
            var updatedData = form.Contact;

            if (form.DialogResult == DialogResult.OK)
            {
                if (FindTextBox.Text.Length == 0)
                {
                    prog.contactsList.RemoveAt(selectedIndex);
                    prog.contactsList.Insert(selectedIndex, updatedData);
                    prog.Sortirovka();
                    RefreshContactListBox();
                }
                if (FindTextBox.Text.Length != 0)
                {
                    var index = list.BinarySearch(unupdatedData);
                    list.RemoveAt(index);
                    list.Insert(index, updatedData);
                    index = prog.contactsList.BinarySearch(unupdatedData);
                    prog.contactsList.RemoveAt(index);
                    prog.contactsList.Insert(index, updatedData);
                    prog.Sortirovka();

                    var text = FindTextBox.Text;
                    FindTextBox.Text = null;
                    FindTextBox.Text = text;
                }
                ProjectManager.SaveToFile(prog, filename);
            }
        }
    }
}
