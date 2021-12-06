using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        private Contact _contact = new Contact();
        private Color _backgroundColor = Color.White;
        private Color _warningBackgroundColor = Color.LightPink;
        
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
                    MailTextBox.Text = value.EMail;
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
            SurnameTextBox.BackColor = _backgroundColor;
            try
            {               
                _contact.Surname = this.SurnameTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                SurnameTextBox.BackColor = _warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            NameTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.Name = NameTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                NameTextBox.BackColor = _warningBackgroundColor;                
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
            BirthdayDateTimePicker.CalendarTitleBackColor = _backgroundColor;
            try
            {
                _contact.DateOfBirth = BirthdayDateTimePicker.Value;
                OkButton.Enabled = true;
            }
            catch
            {
                BirthdayDateTimePicker.CalendarTitleBackColor = _warningBackgroundColor;                
                Console.WriteLine(BirthdayDateTimePicker.CalendarTitleBackColor);
            }
            ErrorCheck();
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.Number = new PhoneNumber( Int64.Parse(PhoneTextBox.Text));
                OkButton.Enabled = true;
            }
            catch
            {
                PhoneTextBox.BackColor = _warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            MailTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.EMail = MailTextBox.Text;
                OkButton.Enabled = true;
            }
            catch
            {
                MailTextBox.BackColor = _warningBackgroundColor;                
            }
            ErrorCheck();
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            VkIdTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.VkID = Convert.ToInt64(VkIdTextBox.Text);
                OkButton.Enabled = true;
            }
            catch
            {
                VkIdTextBox.BackColor = _warningBackgroundColor;                
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

            if (NameTextBox.BackColor == _warningBackgroundColor ||
                    SurnameTextBox.BackColor == _warningBackgroundColor ||
                    PhoneTextBox.BackColor == _warningBackgroundColor ||
                    BirthdayDateTimePicker.CalendarTitleBackColor == _warningBackgroundColor ||
                    MailTextBox.BackColor == _warningBackgroundColor ||
                    VkIdTextBox.BackColor == _warningBackgroundColor
                )
            {
                OkButton.Enabled = false;
            }
           
            //-----------------------
            if (SurnameTextBox.Text.Length == 0 ||
                    NameTextBox.Text.Length == 0||
                    PhoneTextBox.Text.Length == 0 ||
                    MailTextBox.Text.Length == 0 ||
                    VkIdTextBox.Text.Length == 0
                )
            {
                OkButton.Enabled = false;
            }
           
        }
    }
}
