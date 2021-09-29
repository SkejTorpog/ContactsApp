﻿using ContactsApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ContactsAppUI
{
    // Ошибки в верстке, надо переверстать 
    // Форму редактирования контакта назвать Contact
    // Названия переменных, должны содержать правильные ( list1, list, prog, и тд - никакой конкретики, код должен быть читаемым
    public partial class MainForm : System.Windows.Forms.Form
    {
        Project projectData = new Project();
        List<Contact> contacts = new List<Contact>();
        
        string filename = "..\\..\\My Documents\\ContactsApp.notes"; // должно сохраняться через относительные пути в uppdata

        public MainForm()
        {
            InitializeComponent();
           
            // Выгрузка сохраненных контактов            
            projectData = ProjectManager.LoadFromFile(filename);
            projectData.Sort();
            // Цикл для вывода всех сохраненных в файле контактов на ЛистБокс
            for (int i = 0; i < projectData.contactsList.Count; i++)
            {
                ContactsListBox.Items.Add(projectData.contactsList[i].Surname);
            }            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ContactsListBox.SelectedIndex = 0;
            var birthdayPeople = projectData.ShowBirthdayPeople(DateTime.Now);
            if (birthdayPeople.Count != 0)
            {                
                string[] str = new string[birthdayPeople.Count];
                for (int i = 0; i < birthdayPeople.Count; i++)
                {
                    str[i] = birthdayPeople[i].Surname;
                    BirthDaySurnameLabel.Text = string.Join(",", str );                    
                }
            } 
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAAAA");
            ContactForm form1 = new ContactForm();
            form1.ShowDialog();
            
            var surname = form1.Contact.Surname;
            if (form1.DialogResult == DialogResult.OK)
            {
                //ContactsListBox.Items.Add(surname);                
                projectData.contactsList.Add(form1.Contact);
                projectData.Sort();
                RefreshContactListBox();
                //Сохранение после добавления контакта
                ProjectManager.SaveToFile(projectData, filename); 
            }
            RefreshContactListBox();
        }        

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            Contact selectedData = new Contact();
            Contact unupdatedData = new Contact();
            var selectedIndex = ContactsListBox.SelectedIndex;

            if (selectedIndex == -1 )
            {
                MessageBox.Show("Выберите контакт");
                return;     
            }

            selectedData = FindTextBox.Text.Length == 0 ?
                (Contact)projectData.contactsList[selectedIndex].Clone() : (Contact)contacts[selectedIndex].Clone();
            unupdatedData = FindTextBox.Text.Length == 0 ?
               projectData.contactsList[selectedIndex] : contacts[selectedIndex];
            

            ContactForm form = new ContactForm();
            form.Contact = selectedData;
            form.ShowDialog();           

            if (form.DialogResult == DialogResult.OK)
            {
                var updatedData = form.Contact;
                projectData.contactsList.Remove(unupdatedData);
                projectData.contactsList.Add(updatedData);
                projectData.Sort();
                RefreshContactListBox();                                     
                
                ProjectManager.SaveToFile(projectData, filename);
                ContactsListBox.SelectedIndex = FindTextBox.Text.Length == 0 ?
                    projectData.contactsList.IndexOf(updatedData) : contacts.IndexOf(updatedData);
            }                      
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;          
            if (selectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали контакт");
                return;
            }

            Contact selectedData = new Contact();
            selectedData = FindTextBox.Text.Length != 0 ?
                contacts[selectedIndex] : projectData.contactsList[selectedIndex];
            DialogResult result = MessageBox.Show(
                "Do you really want to delete " + selectedData.Surname, 
                "Delete", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                projectData.contactsList.Remove(selectedData);
                RefreshContactListBox();
                ProjectManager.SaveToFile(projectData, filename);               
            }                      
        }
               
        private void RefreshContactListBox()
        {            
            ContactsListBox.Items.Clear();

            if (FindTextBox.Text.Length == 0)
            {
                for (int i = 0; i < projectData.contactsList.Count; i++)
                {
                    ContactsListBox.Items.Add(projectData.contactsList[i].Surname);
                }
            }
            else
            {
                var findLine = FindTextBox.Text;
                FindTextBox.Text = null;
                FindTextBox.Text = findLine;
            }
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)  // Игнорировать, если индекс = -1
            {
                return;
            }

            var contact = FindTextBox.Text.Length == 0 ?
                projectData.contactsList[selectedIndex] : contacts[selectedIndex];
            
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.DateOfBirth;
            PhoneTextBox.Text = contact.Number.Number.ToString();
            MailTextBox.Text = contact.Mail;
            VkIdTextBox.Text = "id" + contact.VkID.ToString();               
        }

        private void FindTextBox_TextChanged_1(object sender, EventArgs e)
        {
            contacts = projectData.FindContacts(FindTextBox.Text);            
            ContactsListBox.Items.Clear();
            for (int i = 0; i < contacts.Count; i++)
            {
                ContactsListBox.Items.Add(contacts[i].Surname);
            }                        
        }

        private void AddToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddContactButton_Click(sender, e);
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditContactButton_Click(sender, e);
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContactButton_Click(sender, e);
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form2 = new AboutForm();
            form2.Show();
        }

        private void ContactsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContactButton_Click(sender, e);
            }            
        }


        //private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var selectedIndex = ContactsListBox.SelectedIndex;
        //    if (selectedIndex == -1)  // Игнорировать, если индекс = -1
        //    {
        //        return;
        //    }
        //    if (FindTextBox.Text.Length == 0)
        //    {
        //        var contact = projectData.contactsList[selectedIndex];
        //        SurnameTextBox.Text = contact.Surname;
        //        NameTextBox.Text = contact.Name;
        //        BirthdayDateTimePicker.Value = contact.DateOfBirth;
        //        PhoneTextBox.Text = contact.Number.Number.ToString();
        //        MailTextBox.Text = contact.Mail;
        //        VkIdTextBox.Text = "id" + contact.VkID.ToString();
        //    }
        //    else
        //    {
        //        var contact = list[selectedIndex];
        //        SurnameTextBox.Text = contact.Surname;
        //        NameTextBox.Text = contact.Name;
        //        BirthdayDateTimePicker.Value = contact.DateOfBirth;
        //        PhoneTextBox.Text = contact.Number.Number.ToString();
        //        MailTextBox.Text = contact.Mail;
        //        VkIdTextBox.Text = "id" + contact.VkID.ToString();
        //    }
        //}
        //private void EditContactButton_Click(object sender, EventArgs e)
        //{
        //    Contact selectedData = new Contact();
        //    Contact unupdatedData = new Contact();
        //    var selectedIndex = ContactsListBox.SelectedIndex;

        //    if (selectedIndex == -1)
        //    {
        //        MessageBox.Show("Выберите контакт");
        //        return;
        //    }

        //    if (FindTextBox.Text.Length == 0)
        //    {
        //        selectedData = (Contact)projectData.contactsList[selectedIndex].Clone();
        //    }
        //    else
        //    {
        //        selectedData = (Contact)list[selectedIndex].Clone();
        //        unupdatedData = list[selectedIndex];
        //    }

        //    ContactForm form = new ContactForm();
        //    form.Contact = selectedData;
        //    form.ShowDialog();

        //    if (form.DialogResult == DialogResult.OK)
        //    {
        //        var updatedData = form.Contact;
        //        if (FindTextBox.Text.Length == 0)
        //        {
        //            projectData.contactsList.RemoveAt(selectedIndex);
        //            projectData.contactsList.Insert(selectedIndex, updatedData);
        //            projectData.Sort();
        //            RefreshContactListBox();
        //        }
        //        if (FindTextBox.Text.Length != 0)
        //        {
        //            list.Remove(unupdatedData);
        //            list.Add(updatedData);

        //            projectData.contactsList.Remove(unupdatedData);
        //            projectData.contactsList.Add(updatedData);
        //            projectData.Sort();

        //            var text = FindTextBox.Text;
        //            FindTextBox.Text = null;
        //            FindTextBox.Text = text;
        //        }
        //        ProjectManager.SaveToFile(projectData, filename);
        //        ContactsListBox.SelectedIndex = selectedIndex;
        //    }
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        Console.WriteLine(list[i].Surname);
        //    }
        //    Console.WriteLine("______________prog______________");
        //    for (int i = 0; i < projectData.contactsList.Count; i++)
        //    {
        //        Console.WriteLine(projectData.contactsList[i].Surname);
        //    }
        //    Console.WriteLine("______________end______________");
        //}

        //private void RemoveContactButton_Click(object sender, EventArgs e)
        //{
        //    var selectedIndex = ContactsListBox.SelectedIndex;
        //    if (selectedIndex == -1)
        //    {
        //        MessageBox.Show("Вы не выбрали контакт");
        //        return;
        //    }

        //    Contact selectedData = new Contact();
        //    selectedData = FindTextBox.Text.Length != 0 ?
        //        list[selectedIndex] :
        //        projectData.contactsList[selectedIndex];
        //    DialogResult result = MessageBox.Show(
        //        "Do you really want to delete " + selectedData.Surname,
        //        "Delete", MessageBoxButtons.OKCancel);

        //    if (result == DialogResult.OK)
        //    {
        //        if (FindTextBox.Text.Length != 0)
        //        {
        //            list.Remove(selectedData);
        //            ContactsListBox.Items.RemoveAt(selectedIndex);
        //            projectData.contactsList.Remove(selectedData);
        //            //Сохранение после удаления
        //            ProjectManager.SaveToFile(projectData, filename);
        //        }
        //        else
        //        {
        //            projectData.contactsList.RemoveAt(selectedIndex);
        //            ContactsListBox.Items.RemoveAt(selectedIndex);
        //            //Сохранение после удаления
        //            ProjectManager.SaveToFile(projectData, filename);
        //        }
        //    }
        //}
    }
}
