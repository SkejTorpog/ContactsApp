using ContactsApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ContactsAppUI
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Список контактов
        /// </summary>
        private Project _project = new Project(); 

        /// <summary>
        /// Вспомогательный список контактов, при активной поисковой строке
        /// </summary>
        private List<Contact> _viewedContacts = new List<Contact>(); 
                
        public MainForm()
        {
            InitializeComponent();
           
            // Выгрузка сохраненных контактов            
            _project = ProjectManager.LoadFromFile(ProjectManager.defaultFilename);
            _project.Sort();
            // Цикл для вывода всех сохраненных в файле контактов на ЛистБокс
            for (int i = 0; i < _project.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_project.Contacts[i].Surname);
            }

            if (_project.Contacts.Count != 0)
            {
                ContactsListBox.SelectedIndex = 0;
            }

            var birthdayPeople = _project.ShowBirthdayPeople(DateTime.Now);
            var surnames = birthdayPeople.Select(contact => contact.Surname);
            var allSurnames = string.Join(", ", surnames);
            BirthDaySurnameLabel.Text = allSurnames;
        }
                   
        private void RefreshContactListBox()
        {            
            ContactsListBox.Items.Clear();

            if (FindTextBox.Text.Length == 0)
            {
                for (int i = 0; i < _project.Contacts.Count; i++)
                {
                    ContactsListBox.Items.Add(_project.Contacts[i].Surname);
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
                _project.Contacts[selectedIndex] : 
                _viewedContacts[selectedIndex];
            
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.DateOfBirth;
            PhoneTextBox.Text = contact.Number.Number.ToString();
            MailTextBox.Text = contact.EMail;
            VkIdTextBox.Text = "id" + contact.VkID.ToString();               
        }

        private void FindTextBox_TextChanged_1(object sender, EventArgs e)
        {
            _viewedContacts = _project.FindContacts(FindTextBox.Text);            
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _viewedContacts.Count; i++)
            {
                ContactsListBox.Items.Add(_viewedContacts[i].Surname);
            }                        
        }
        
        private void AddContact()
        {
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();

            if (contactForm.DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(contactForm.Contact);
                _project.Sort();
                RefreshContactListBox();
                //Сохранение после добавления контакта
                ProjectManager.SaveToFile(_project, ProjectManager.defaultFilename);
            }
        }

        private void EditContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт");
                return;
            }

            var contacts = FindTextBox.Text.Length == 0 ?
                _project.Contacts :
                _viewedContacts;

            var selectedData = (Contact)contacts[selectedIndex].Clone();
            var unupdatedData = contacts[selectedIndex];

            ContactForm contactForm = new ContactForm();
            contactForm.Contact = selectedData;
            contactForm.ShowDialog();

            if (contactForm.DialogResult == DialogResult.OK)
            {
                var updatedData = contactForm.Contact;
                _project.Contacts.Remove(unupdatedData);
                _project.Contacts.Add(updatedData);
                _project.Sort();
                RefreshContactListBox();

                ProjectManager.SaveToFile(_project, ProjectManager.defaultFilename);
                ContactsListBox.SelectedIndex = FindTextBox.Text.Length == 0 ?
                   _project.Contacts.IndexOf(updatedData) :
                   _viewedContacts.IndexOf(updatedData);
            }
        }

        private void RemoveContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали контакт");
                return;
            }

            var selectedData = FindTextBox.Text.Length != 0 ?
                _viewedContacts[selectedIndex] : 
                _project.Contacts[selectedIndex];
            DialogResult result = MessageBox.Show(
                "Do you really want to delete " + selectedData.Surname,
                "Delete", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _project.Contacts.Remove(selectedData);
                RefreshContactListBox();
                ProjectManager.SaveToFile(_project, ProjectManager.defaultFilename);
            }
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RemoveContactButton_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void AddToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddContact();
        }

        private void EditToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveContact();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void ContactsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContact();
            }
        }
    }
}
