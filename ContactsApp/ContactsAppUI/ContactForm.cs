using System;
using System.Drawing;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUI
{    
    public partial class ContactForm : Form
    {        
        private Contact _contact = new Contact();
        private readonly Color _backgroundColor = Color.White; 
        private readonly Color _warningBackgroundColor = Color.LightPink;

        //Поля, для проверки корректности текстбоксов
        private bool _nameIsCorrect = false;
        private bool _surnameIsCorrect = false;
        private bool _birthdayDateIsCorrect = true;
        private bool _phoneIsCorrect = false;
        private bool _emailIsCorrect = false;
        private bool _vkIdIsCorrect = false;
        
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
                _surnameIsCorrect = true;
            }
            catch
            {
                SurnameTextBox.BackColor = _warningBackgroundColor;
                _surnameIsCorrect = false;
            }
            ErrorCheck();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            NameTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.Name = NameTextBox.Text;
                _nameIsCorrect = true;
            }
            catch
            {
                NameTextBox.BackColor = _warningBackgroundColor;
                _nameIsCorrect = false;
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
                _birthdayDateIsCorrect = true;
            }
            catch
            {
                BirthdayDateTimePicker.CalendarTitleBackColor = _warningBackgroundColor;
                _birthdayDateIsCorrect = false;
            }
            ErrorCheck();
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            PhoneTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.Number = new PhoneNumber( Int64.Parse(PhoneTextBox.Text));
                _phoneIsCorrect = true;
            }
            catch
            {
                PhoneTextBox.BackColor = _warningBackgroundColor;
                _phoneIsCorrect = false;
            }
            ErrorCheck();
        }

        private void MailTextBox_TextChanged(object sender, EventArgs e)
        {
            MailTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.EMail = MailTextBox.Text;
                _emailIsCorrect = true;
            }
            catch
            {
                MailTextBox.BackColor = _warningBackgroundColor;
                _emailIsCorrect = false;
            }
            ErrorCheck();
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            VkIdTextBox.BackColor = _backgroundColor;
            try
            {
                _contact.VkID = Convert.ToInt64(VkIdTextBox.Text);
                _vkIdIsCorrect = true;
            }
            catch
            {
                VkIdTextBox.BackColor = _warningBackgroundColor;
                _vkIdIsCorrect = false;
            }
            ErrorCheck();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            ErrorCheck();
        }

        /// <summary>
        /// Метод для блокировки кнопки Ок, если есть ошибки в текст боксах
        /// </summary>
        private void ErrorCheck()
        {
            OkButton.Enabled = true;

            if (_nameIsCorrect == false ||
                _surnameIsCorrect == false ||
                _phoneIsCorrect == false ||
                _birthdayDateIsCorrect == false ||
                _emailIsCorrect == false ||
                _vkIdIsCorrect == false)
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
