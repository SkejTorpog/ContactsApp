using System;
using System.Collections.Generic;


namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий список контактов
    /// </summary>
    public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Contact> contactsList = new List<Contact>();

        public List<Contact> Sort()
        {
            var list = contactsList;
            list.Sort();
            return list;
        }

        public List<Contact> FindContacts(string str)
        {
            List<Contact> list = new List<Contact>();
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList[i].Surname.ToUpper().Contains(str.ToUpper()) ||
                    contactsList[i].Name.ToUpper().Contains(str.ToUpper()))
                {
                    list.Add(contactsList[i]);
                }
            }
            list.Sort(); 
            return list;
        }

        public List<Contact> ShowBirthdayPeople(DateTime birthday)
        {
            List<Contact> list = new List<Contact>();
            for (int i = 0; i < contactsList.Count; i++)
            {
                 if(contactsList[i].DateOfBirth.Month == birthday.Month && 
                    contactsList[i].DateOfBirth.Day == birthday.Day)
                {
                    list.Add(contactsList[i]);
                }
            }

            return list;
        }
    }
}
