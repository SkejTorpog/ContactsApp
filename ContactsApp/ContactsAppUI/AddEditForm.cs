using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class AddEditForm : Form
    {
        private Contact _contact = new Contact();
        

        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set 
            {
                _contact = value;
                if (value != null)
                {
                    NameTextBox.Text = value.Name;
                    SurnameTextBox.Text = value.Surname;
                    BirthdayDateTimePicker.Value = value.BirthDateTime;
                    PhoneTextBox.Text = value.Number.Number.ToString();
                    MailTextBox.Text = value.Mail;
                    VkIdTextBox.Text = value.VkID.ToString();
                }
            }
        }
        public AddEditForm()
        {
            InitializeComponent();
            _contact.BirthDateTime = new DateTime(2000, 1, 1);
            
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            
            SurnameTextBox.BackColor = Color.White;
            try
            {
               
                _contact.Surname = this.SurnameTextBox.Text;
                OkButton.Enabled = true;

            }
            catch
            {
                SurnameTextBox.BackColor = Color.LightPink;
                //OkButton.Enabled = false;
            }
            ErrorCheck();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            NameTextBox.BackColor = Color.White;
            try
            {
                _contact.Name = NameTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                NameTextBox.BackColor = Color.LightPink;
                //OkButton.Enabled = false;
            }
            ErrorCheck();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            DialogResult = DialogResult.OK;
            this.Close(); 
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
     
            DialogResult = DialogResult.Cancel;
            
            this.Close();
        }

        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _contact.BirthDateTime = BirthdayDateTimePicker.Value;
                OkButton.Enabled = true;
            }
            catch
            {
                BirthdayDateTimePicker.CalendarTitleBackColor = Color.LightPink;
                //OkButton.Enabled = false;
                Console.WriteLine(BirthdayDateTimePicker.CalendarTitleBackColor);
            }
            ErrorCheck();
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = Color.White;
            try
            {
                _contact.Number = new PhoneNumber( Int64.Parse(PhoneTextBox.Text));
                OkButton.Enabled = true;
            }
            catch
            {
                PhoneTextBox.BackColor = Color.LightPink;
                //OkButton.Enabled = false;
            }
            ErrorCheck();
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            MailTextBox.BackColor = Color.White;
            try
            {
                _contact.Mail = MailTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                MailTextBox.BackColor = Color.LightPink;
                //OkButton.Enabled = false;
            }
            ErrorCheck();
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            VkIdTextBox.BackColor = Color.White;
            try
            {
                _contact.VkID = Convert.ToInt64(VkIdTextBox.Text);
                OkButton.Enabled = true;
            }
            catch
            {
                VkIdTextBox.BackColor = Color.LightPink;
                //OkButton.Enabled = false;
            }
            ErrorCheck();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            ErrorCheck();

        }

        private void ErrorCheck()
        {
            if (NameTextBox.BackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            if (SurnameTextBox.BackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            if (PhoneTextBox.BackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            if (BirthdayDateTimePicker.CalendarTitleBackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            if (MailTextBox.BackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            if (VkIdTextBox.BackColor == Color.LightPink)
            {
                OkButton.Enabled = false;
            }
            //////////////
            if (SurnameTextBox.Text.Length == 0)
            {
                OkButton.Enabled = false;
            }
            if (NameTextBox.Text.Length == 0)
            {
                OkButton.Enabled = false;
            }
            if (PhoneTextBox.Text.Length == 0)
            {
                OkButton.Enabled = false;
            }
            if (MailTextBox.Text.Length == 0)
            {
                OkButton.Enabled = false;
            }
            if (VkIdTextBox.Text.Length == 0)
            {
                OkButton.Enabled = false;
            }
        }

    }
}
