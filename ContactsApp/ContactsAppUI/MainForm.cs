using ContactsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading;

namespace ContactsAppUI
{
    
    public partial class MainForm : System.Windows.Forms.Form
    {
        Project prog = new Project();
        List<Contact> list = new List<Contact>(200);
        
        string filename = "C:\\Users\\AlischRak9\\Desktop\\teta.notes";
        public MainForm()
        {
            InitializeComponent();
           
            NameTextBox.ReadOnly = true;
            SurnameTextBox.ReadOnly = true;
            BirthdayDateTimePicker.Enabled = false;            
            PhoneTextBox.ReadOnly = true;
            MailTextBox.ReadOnly = true;
            VkIdTextBox.ReadOnly = true;

            // Выгрузка сохраненных контактов            
            prog = ProjectManager.LoadFromFile(filename);
            prog.Assort();
            // Цикл для вывода всех сохраненных в файле контактов на ЛистБокс
            for (int i = 0; i < prog.contactsList.Count; i++)
            {
                ContactsListBox.Items.Add(prog.contactsList[i].Surname);
            }            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ContactsListBox.SelectedIndex = 0;
            var list1 = prog.ShowBirthdayPeople(DateTime.Now);
            if (list1.Count != 0)
            {
                Console.WriteLine(list1.Count);
                for (int i = 0; i < list1.Count; i++)
                {
                    if (i != list1.Count-1)
                    {
                        BirthDaySurnameLabel.Text = BirthDaySurnameLabel.Text + list1[i].Surname + ", ";
                    }
                    else
                    {                        
                        BirthDaySurnameLabel.Text = BirthDaySurnameLabel.Text + list1[i].Surname;
                    }
                }
            } 
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void AddContactButton_Click(object sender, EventArgs e)
        {                        
            AddEditForm form1 = new AddEditForm();
            form1.ShowDialog();
            
            var surname = form1.Contact.Surname;
            if (form1.DialogResult == DialogResult.OK)
            {
                //ContactsListBox.Items.Add(surname);                
                prog.contactsList.Add(form1.Contact);
                prog.Assort();
                RefreshContactListBox();
                //Сохранение после добавления контакта
                ProjectManager.SaveToFile(prog, filename); 
            }
            if (FindTextBox.Text.Length != 0)
            {
                var text = FindTextBox.Text;
                FindTextBox.Text = null;
                FindTextBox.Text = text;
            }
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
            if (FindTextBox.Text.Length == 0)
            {
                selectedData = (Contact)prog.contactsList[selectedIndex].Clone();
            }
            else
            {
                selectedData = (Contact)list[selectedIndex].Clone();
                unupdatedData = list[selectedIndex];
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
                    prog.Assort();
                    RefreshContactListBox();
                }
                if (FindTextBox.Text.Length != 0)
                {                                                                                              
                    list.Remove(unupdatedData);
                    list.Add(updatedData);
                    
                    prog.contactsList.Remove(unupdatedData);
                    prog.contactsList.Add(updatedData);
                    prog.Assort();

                    var text = FindTextBox.Text;
                    FindTextBox.Text = null;
                    FindTextBox.Text = text;                    
                }
                ProjectManager.SaveToFile(prog, filename);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Surname);
            }
            Console.WriteLine("______________prog______________");
            for (int i = 0; i < prog.contactsList.Count; i++)
            {
                Console.WriteLine(prog.contactsList[i].Surname);
            }
            Console.WriteLine("______________end______________");
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
            selectedData = FindTextBox.Text.Length != 0 ? list[selectedIndex] : prog.contactsList[selectedIndex];
            DialogResult result = MessageBox.Show("Do you really want to delete " + selectedData.Surname, "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (FindTextBox.Text.Length != 0)
                {                  
                    
                    list.Remove(selectedData);
                    ContactsListBox.Items.RemoveAt(selectedIndex);                    
                    prog.contactsList.Remove(selectedData);
                    //Сохранение после удаления
                    ProjectManager.SaveToFile(prog, filename);
                }
                else
                {
                    prog.contactsList.RemoveAt(selectedIndex);
                    ContactsListBox.Items.RemoveAt(selectedIndex);
                    //Сохранение после удаления
                    ProjectManager.SaveToFile(prog, filename);
                }
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
            SendKeys.Send("%{F4}");  // Иммитация нажатия клавишь Alt + F4, для закрытия программы
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form2 = new AboutForm();
            form2.Show();
        }

        private void RefreshContactListBox()
        {
            ContactsListBox.Items.Clear();
            for (int i = 0; i < prog.contactsList.Count; i++)
            {
                ContactsListBox.Items.Add(prog.contactsList[i].Surname);                
            }
        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)  // Игнорировать, если индекс = -1
            {
                return;
            }
            if (FindTextBox.Text.Length == 0)
            {
                SurnameTextBox.Text = prog.contactsList[selectedIndex].Surname;
                NameTextBox.Text = prog.contactsList[selectedIndex].Name;
                BirthdayDateTimePicker.Value = prog.contactsList[selectedIndex].BirthDateTime;
                PhoneTextBox.Text = prog.contactsList[selectedIndex].Number.Number.ToString();
                MailTextBox.Text = prog.contactsList[selectedIndex].Mail;
                VkIdTextBox.Text = "id" + prog.contactsList[selectedIndex].VkID.ToString();
            }
            else
            {
                SurnameTextBox.Text = list[selectedIndex].Surname;
                NameTextBox.Text = list[selectedIndex].Name;
                BirthdayDateTimePicker.Value = list[selectedIndex].BirthDateTime;
                PhoneTextBox.Text = list[selectedIndex].Number.Number.ToString();
                MailTextBox.Text = list[selectedIndex].Mail;
                VkIdTextBox.Text = "id" + list[selectedIndex].VkID.ToString();
            }    
        }

        private void FindTextBox_TextChanged_1(object sender, EventArgs e)
        {                     
            list = prog.Assort(FindTextBox.Text);
            ContactsListBox.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                ContactsListBox.Items.Add(list[i].Surname);
            }                        
        }

        private void ContactsListBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveContactButton_Click(sender, e);
            }            
        }       
    }
}
