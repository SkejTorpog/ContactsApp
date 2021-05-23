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
            //ProjectManager.SaveToFile(prog,filename);
            //prog = ProjectManager.LoadFromFile(filename);
            if (ProjectManager.LoadFromFile(filename) == null)
            {
                
                ProjectManager.SaveToFile(prog, filename);
            }
            else 
            {
                prog = ProjectManager.LoadFromFile(filename);
                // Цикл для вывода всех сохраненных в файле контактов на ЛистБокс
                for (int i = 0; i < prog.contactsList.Count; i++)
                {
                    ContactsListBox.Items.Add(prog.contactsList[i].Surname);
                }
            }
            //prog.contactsList.Add((new Contact("Ivanov", "Sergey", new PhoneNumber(71234567891), new DateTime(2001, 11, 5), "IvSerg@mail.ru", 3455334)));
            //prog.contactsList.Add((new Contact("Petrov", "Oleg", new PhoneNumber(71234567891), new DateTime(2001, 4, 18), "IvOleg@mail.ru", 3455334)));
            //prog.contactsList.Add((new Contact("Gribnov", "Obrek", new PhoneNumber(71234567891), new DateTime(2001, 4, 5), "IvObrek@mail.ru", 3455334)));
            //prog.contactsList.Add((new Contact("Panov", "Alek", new PhoneNumber(71234567891), new DateTime(2001, 10, 2), "IvAlek@mail.ru", 3455334)));
            //prog.contactsList.Add((new Contact("Gribanov", "Aleg", new PhoneNumber(71234567891), new DateTime(2001, 9, 4), "IvAleg@mail.ru", 3455334)));

            //ContactsListBox.Items.Add(new Contact("Ivanov", "Sergey", new PhoneNumber(71234567891), new DateTime(2001, 11, 5), "IvSerg@mail.ru", 3455334).Surname);
            //ContactsListBox.Items.Add(new Contact("Petrov", "Oleg", new PhoneNumber(71234567891), new DateTime(2001, 4, 18), "IvOleg@mail.ru", 3455334).Surname);
            //ContactsListBox.Items.Add(new Contact("Gribnov", "Obrek", new PhoneNumber(71234567891), new DateTime(2001, 4, 5), "IvObrek@mail.ru", 3455334).Surname);
            //ContactsListBox.Items.Add(new Contact("Panov", "Alek", new PhoneNumber(71234567891), new DateTime(2001, 10, 2), "IvAlek@mail.ru", 3455334).Surname);
            //ContactsListBox.Items.Add(new Contact("Gribanov", "Aleg", new PhoneNumber(71234567891), new DateTime(2001, 9, 4), "IvAleg@mail.ru", 3455334).Surname);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            AddEditForm form1 = new AddEditForm();
            form1.ShowDialog();

            
            var surname = form1.Contact.Surname;
            if (form1.DialogResult == DialogResult.OK)
            {
                ContactsListBox.Items.Add(surname);
                prog.contactsList.Add(form1.Contact);
                //Сохранение после добавления контакта
                ProjectManager.SaveToFile(prog, filename); 
            }
            
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            //SurnameTextBox.Text = prog.contactsList[ContactsListBox.SelectedIndex]
        }
        
        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {     
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1 )   // Не реагировать, если индекс ListBox = -1
            {
               
                return;
            }
            SurnameTextBox.Text = prog.contactsList[selectedIndex].Surname;
            NameTextBox.Text = prog.contactsList[selectedIndex].Name;
            BirthdayDateTimePicker.Value = prog.contactsList[selectedIndex].BirthDateTime ;
            PhoneTextBox.Text = prog.contactsList[selectedIndex].Number.Number.ToString();
            MailTextBox.Text = prog.contactsList[selectedIndex].Mail;
            VkIdTextBox.Text ="id" + prog.contactsList[selectedIndex].VkID.ToString() ;          
        }

        private void EditContactButton_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1 )
            {
                MessageBox.Show("Выберите контакт");
                return;     
            }

            // Сохраняем исходные значения
            var nameIfCancel = prog.contactsList[selectedIndex].Name;
            var surnameIfCancel = prog.contactsList[selectedIndex].Surname;
            var numberIfCancel = prog.contactsList[selectedIndex].Number.Number;
            var dateIfCancel = prog.contactsList[selectedIndex].BirthDateTime;
            var mailIfCancel = prog.contactsList[selectedIndex].Mail;
            var vkIdIfCancel = prog.contactsList[selectedIndex].VkID;

            AddEditForm form1 = new AddEditForm();
            form1.Contact = prog.contactsList[selectedIndex];
            form1.ShowDialog();
           
            if (form1.DialogResult == DialogResult.OK)
            {
                var updatedData = form1.Contact;
                ContactsListBox.Items.RemoveAt(selectedIndex);
                prog.contactsList.RemoveAt(selectedIndex);

                prog.contactsList.Insert(selectedIndex, updatedData);
                ContactsListBox.Items.Insert(selectedIndex, updatedData.Surname);
                //Сохранение после редактирования контакта
                ProjectManager.SaveToFile(prog, filename);         
            }
            else
            {
                // Возвращаем исходные
                prog.contactsList[selectedIndex].Name = nameIfCancel;
                prog.contactsList[selectedIndex].Surname = surnameIfCancel;
                prog.contactsList[selectedIndex].Number.Number = numberIfCancel;
                prog.contactsList[selectedIndex].BirthDateTime = dateIfCancel;
                prog.contactsList[selectedIndex].Mail = mailIfCancel;
                prog.contactsList[selectedIndex].VkID = vkIdIfCancel;               
            }
            
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
        
        private void RemoveContactButton_Click(object sender, EventArgs e)
        {

            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали контакт");
                return;
            }
            DialogResult result = MessageBox.Show("Do you really want to delete " + prog.contactsList[selectedIndex].Surname, "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                prog.contactsList.RemoveAt(selectedIndex);
                ContactsListBox.Items.RemoveAt(selectedIndex);
                //Сохранение после удаления
                ProjectManager.SaveToFile(prog, filename);
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

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        
    }


}
