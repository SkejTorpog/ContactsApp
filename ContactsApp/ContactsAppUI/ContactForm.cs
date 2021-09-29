using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        private Contact _contact = new Contact();
        private Color backgroundColor = Color.White;
        private Color warningBackgroundColor = Color.LightPink;
        

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
                    BirthdayDateTimePicker.Value = value.DateOfBirth;
                    PhoneTextBox.Text = value.Number.Number.ToString();
                    MailTextBox.Text = value.Mail;
                    VkIdTextBox.Text = value.VkID.ToString();
                }
            }
        }
        public ContactForm()
        {
            InitializeComponent();
            _contact.DateOfBirth = new DateTime(2000, 1, 1);
            
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            // Color.White вынести в константу, для удобного редактирования в будущем
            SurnameTextBox.BackColor = backgroundColor;
            try
            {
               
                _contact.Surname = this.SurnameTextBox.Text;
                OkButton.Enabled = true;

            }
            catch
            {
                SurnameTextBox.BackColor = warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            NameTextBox.BackColor = backgroundColor;
            try
            {
                _contact.Name = NameTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                NameTextBox.BackColor = warningBackgroundColor;                
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
                _contact.DateOfBirth = BirthdayDateTimePicker.Value;
                OkButton.Enabled = true;
            }
            catch
            {
                BirthdayDateTimePicker.CalendarTitleBackColor = warningBackgroundColor;                
                Console.WriteLine(BirthdayDateTimePicker.CalendarTitleBackColor);
            }
            ErrorCheck();
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = backgroundColor;
            try
            {
                _contact.Number = new PhoneNumber( Int64.Parse(PhoneTextBox.Text));
                OkButton.Enabled = true;
            }
            catch
            {
                PhoneTextBox.BackColor = warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            MailTextBox.BackColor = backgroundColor;
            try
            {
                _contact.Mail = MailTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                MailTextBox.BackColor = warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            VkIdTextBox.BackColor = backgroundColor;
            try
            {
                _contact.VkID = Convert.ToInt64(VkIdTextBox.Text);
                OkButton.Enabled = true;
            }
            catch
            {
                VkIdTextBox.BackColor = warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            ErrorCheck();

        }

        private void ErrorCheck()
        {
            OkButton.Enabled = true;
            // Сделать через один if с переносом строки. 
            if (NameTextBox.BackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            if (SurnameTextBox.BackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            if (PhoneTextBox.BackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            if (BirthdayDateTimePicker.CalendarTitleBackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            if (MailTextBox.BackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            if (VkIdTextBox.BackColor == warningBackgroundColor)
            {
                OkButton.Enabled = false;
            }
            //------------ Блокировка кнопки-----------
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
