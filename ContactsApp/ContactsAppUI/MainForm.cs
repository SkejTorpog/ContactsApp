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
        private Project _projectData = new Project();
        private List<Contact> _contacts = new List<Contact>();
                
        public MainForm()
        {
            InitializeComponent();
           
            // Выгрузка сохраненных контактов            
            _projectData = ProjectManager.LoadFromFile(ProjectManager.defaultFilename);
            _projectData.Sort();
            // Цикл для вывода всех сохраненных в файле контактов на ЛистБокс
            for (int i = 0; i < _projectData.Contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_projectData.Contacts[i].Surname);
            }            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_projectData.Contacts.Count != 0)
            {
                ContactsListBox.SelectedIndex = 0;
            }
            var birthdayPeople = _projectData.ShowBirthdayPeople(DateTime.Now);
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
               
        private void RefreshContactListBox()
        {            
            ContactsListBox.Items.Clear();

            if (FindTextBox.Text.Length == 0)
            {
                for (int i = 0; i < _projectData.Contacts.Count; i++)
                {
                    ContactsListBox.Items.Add(_projectData.Contacts[i].Surname);
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
                _projectData.Contacts[selectedIndex] : 
                _contacts[selectedIndex];
            
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.DateOfBirth;
            PhoneTextBox.Text = contact.Number.Number.ToString();
            MailTextBox.Text = contact.EMail;
            VkIdTextBox.Text = "id" + contact.VkID.ToString();               
        }

        private void FindTextBox_TextChanged_1(object sender, EventArgs e)
        {
            _contacts = _projectData.FindContacts(FindTextBox.Text);            
            ContactsListBox.Items.Clear();
            for (int i = 0; i < _contacts.Count; i++)
            {
                ContactsListBox.Items.Add(_contacts[i].Surname);
            }                        
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

        private void AddContact()
        {
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();

            if (contactForm.DialogResult == DialogResult.OK)
            {
                _projectData.Contacts.Add(contactForm.Contact);
                _projectData.Sort();
                RefreshContactListBox();
                //Сохранение после добавления контакта
                ProjectManager.SaveToFile(_projectData, ProjectManager.defaultFilename);
            }
            RefreshContactListBox();
        }

        private void EditContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Выберите контакт");
                return;
            }

            var selectedData = FindTextBox.Text.Length == 0 ?
                (Contact)_projectData.Contacts[selectedIndex].Clone() :
                (Contact)_contacts[selectedIndex].Clone();
            var unupdatedData = FindTextBox.Text.Length == 0 ?
               _projectData.Contacts[selectedIndex] :
               _contacts[selectedIndex];

            ContactForm contactForm = new ContactForm();
            contactForm.Contact = selectedData;
            contactForm.ShowDialog();

            if (contactForm.DialogResult == DialogResult.OK)
            {
                var updatedData = contactForm.Contact;
                _projectData.Contacts.Remove(unupdatedData);
                _projectData.Contacts.Add(updatedData);
                _projectData.Sort();
                RefreshContactListBox();

                ProjectManager.SaveToFile(_projectData, ProjectManager.defaultFilename);
                ContactsListBox.SelectedIndex = FindTextBox.Text.Length == 0 ?
                    _projectData.Contacts.IndexOf(updatedData) :
                    _contacts.IndexOf(updatedData);
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

            Contact selectedData = new Contact();
            selectedData = FindTextBox.Text.Length != 0 ?
                _contacts[selectedIndex] : 
                _projectData.Contacts[selectedIndex];
            DialogResult result = MessageBox.Show(
                "Do you really want to delete " + selectedData.Surname,
                "Delete", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                _projectData.Contacts.Remove(selectedData);
                RefreshContactListBox();
                ProjectManager.SaveToFile(_projectData, ProjectManager.defaultFilename);
            }
        }        
    }
}
