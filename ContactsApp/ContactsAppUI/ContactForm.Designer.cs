namespace ContactsAppUI
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactForm));
            this.VkIdTextBox = new System.Windows.Forms.TextBox();
            this.MailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.VkLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.BirthdayLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.BirthdayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // VkIdTextBox
            // 
            resources.ApplyResources(this.VkIdTextBox, "VkIdTextBox");
            this.VkIdTextBox.Name = "VkIdTextBox";
            this.VkIdTextBox.TextChanged += new System.EventHandler(this.VkIdTextBox_TextChanged);
            // 
            // MailTextBox
            // 
            resources.ApplyResources(this.MailTextBox, "MailTextBox");
            this.MailTextBox.Name = "MailTextBox";
            this.MailTextBox.TextChanged += new System.EventHandler(this.MailTextBox_TextChanged);
            // 
            // PhoneTextBox
            // 
            resources.ApplyResources(this.PhoneTextBox, "PhoneTextBox");
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.TextChanged += new System.EventHandler(this.PhoneTextBox_TextChanged);
            // 
            // NameTextBox
            // 
            resources.ApplyResources(this.NameTextBox, "NameTextBox");
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // SurnameTextBox
            // 
            resources.ApplyResources(this.SurnameTextBox, "SurnameTextBox");
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.TextChanged += new System.EventHandler(this.SurnameTextBox_TextChanged);
            // 
            // VkLabel
            // 
            resources.ApplyResources(this.VkLabel, "VkLabel");
            this.VkLabel.Name = "VkLabel";
            // 
            // EmailLabel
            // 
            resources.ApplyResources(this.EmailLabel, "EmailLabel");
            this.EmailLabel.Name = "EmailLabel";
            // 
            // PhoneLabel
            // 
            resources.ApplyResources(this.PhoneLabel, "PhoneLabel");
            this.PhoneLabel.Name = "PhoneLabel";
            // 
            // BirthdayLabel
            // 
            resources.ApplyResources(this.BirthdayLabel, "BirthdayLabel");
            this.BirthdayLabel.Name = "BirthdayLabel";
            // 
            // NameLabel
            // 
            resources.ApplyResources(this.NameLabel, "NameLabel");
            this.NameLabel.Name = "NameLabel";
            // 
            // SurnameLabel
            // 
            resources.ApplyResources(this.SurnameLabel, "SurnameLabel");
            this.SurnameLabel.Name = "SurnameLabel";
            // 
            // OkButton
            // 
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BirthdayDateTimePicker
            // 
            resources.ApplyResources(this.BirthdayDateTimePicker, "BirthdayDateTimePicker");
            this.BirthdayDateTimePicker.Name = "BirthdayDateTimePicker";
            this.BirthdayDateTimePicker.ValueChanged += new System.EventHandler(this.BirthdayDateTimePicker_ValueChanged);
            // 
            // ContactForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.BirthdayDateTimePicker);
            this.Controls.Add(this.SurnameLabel);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.VkLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.BirthdayLabel);
            this.Controls.Add(this.MailTextBox);
            this.Controls.Add(this.VkIdTextBox);
            this.Controls.Add(this.PhoneLabel);
            this.Name = "ContactForm";
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox VkIdTextBox;
        private System.Windows.Forms.TextBox MailTextBox;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.Label VkLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label BirthdayLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label SurnameLabel;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DateTimePicker BirthdayDateTimePicker;
    }
}