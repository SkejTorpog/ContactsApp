using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace ContactsApp1
{
    /// <summary>
    /// Класс, хранящий список контактов
    /// </summary>
    public class Project
    {
       
        public List<Contact> contactsList = new List<Contact>(200);
    }

    //-------- EditButtonCode---------------------------------------------------------------
    private void EditContactButton_Click(object sender, EventArgs e)
    {
        Contact selectedData = new Contact();
        Contact selectedDataTest = new Contact();
        var selectedIndex = ContactsListBox.SelectedIndex;
        if (selectedIndex == -1)
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
            selectedDataTest = (Contact)list[selectedIndex].Clone();
        }
        //if (FindTextBox.Text.Length != 0)
        //{
        //    selectedData = (Contact)list[selectedIndex].Clone();
        //}

        AddEditForm form = new AddEditForm();
        form.Contact = selectedData;
        form.ShowDialog();
        var updatedData = form.Contact;

        if (form.DialogResult == DialogResult.OK)
        {
            ContactsListBox.Items.RemoveAt(selectedIndex);
            if (FindTextBox.Text.Length == 0)
            {
                prog.contactsList.RemoveAt(selectedIndex);

                prog.contactsList.Insert(selectedIndex, updatedData);
                ContactsListBox.Items.Insert(selectedIndex, updatedData.Surname);
                prog.Sortirovka();
                RefreshContactListBox();
            }
            if (FindTextBox.Text.Length != 0)
            {
                //var txt = FindTextBox.Text;
                //FindTextBox.Text = null;

                //FindTextBox.Text = txt; ;
                var indddex = list.BinarySearch(selectedDataTest);
                Console.WriteLine("Zashel v if");
                list.RemoveAt(indddex);

                list.Insert(indddex, updatedData);
                var index21 = prog.contactsList.BinarySearch(selectedDataTest);
                prog.contactsList.RemoveAt(index21);
                prog.contactsList.Insert(index21, updatedData);
                //prog.contact+sList.Remove(selectedData);
                //prog.contactsList.Insert(selectedIndex, updatedData);

                var text = FindTextBox.Text;
                FindTextBox.Text = null;
                FindTextBox.Text = text;


            }
            //ContactsListBox.Items.Insert(selectedIndex, updatedData.Surname);
            //prog.Sortirovka();
            //RefreshContactListBox();
            ProjectManager.SaveToFile(prog, filename);
        }
        //var text = FindTextBox.Text;
        //FindTextBox.Text = null;
        //FindTextBox.Text = text;
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i].Surname);
        }
        Console.WriteLine("prog");
        for (int i = 0; i < prog.contactsList.Count; i++)
        {
            Console.WriteLine(prog.contactsList[i].Surname);
        }
        Console.WriteLine("______________________________");
    }
    // -------------------RemoveButtonCode-------------
    private void RemoveContactButton_Click(object sender, EventArgs e)
    {

        var selectedIndex = ContactsListBox.SelectedIndex;

        if (selectedIndex == -1)
        {
            MessageBox.Show("Вы не выбрали контакт");
            return;
        }
        Contact selectedItem = new Contact();
        if (FindTextBox.Text.Length != 0)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete " + list[selectedIndex].Surname, "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {

                selectedItem = list[selectedIndex];
                list.Remove(selectedItem);
                ContactsListBox.Items.RemoveAt(selectedIndex);
                //Сохранение после удаления
                prog.contactsList.Remove(selectedItem);
                ProjectManager.SaveToFile(prog, filename);
            }
        }
        else
        {
            DialogResult result = MessageBox.Show("Do you really want to delete " + prog.contactsList[selectedIndex].Surname, "Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                prog.contactsList.RemoveAt(selectedIndex);
                ContactsListBox.Items.RemoveAt(selectedIndex);
                //Сохранение после удаления

                ProjectManager.SaveToFile(prog, filename);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i].Surname);
        }
        Console.WriteLine("prgo ");
        Console.WriteLine(list.Count);
        for (int i = 0; i < prog.contactsList.Count; i++)
        {
            Console.WriteLine(prog.contactsList[i].Surname);
        }
    }
}
