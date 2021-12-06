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
        /// Поле, хранящее список контактов
        /// </summary>
        public List<Contact> contactsList = new List<Contact>();

        /// <summary>
        /// Сортировка списка контактов
        /// </summary>      
        public List<Contact> Sort()
        {
            var sortedContacts = contactsList;
            sortedContacts.Sort();
            return sortedContacts;
        }

        /// <summary>
        /// Метод находит и возвращает список контактов, имещих в поле Surname или Name подстроку str
        /// </summary>  
        public List<Contact> FindContacts(string str)
        {
            List<Contact> foundContacts = new List<Contact>();
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList[i].Surname.ToUpper().Contains(str.ToUpper()) ||
                        contactsList[i].Name.ToUpper().Contains(str.ToUpper()))
                {
                    foundContacts.Add(contactsList[i]);
                }
            }
            foundContacts.Sort(); 
            return foundContacts;
        }

        /// <summary>
        /// Метод возвращает список контактов, у которых месяц и день в поле DateOfBirth совпадает с сегодняшней датой
        /// </summary>        
        public List<Contact> ShowBirthdayPeople(DateTime birthday)
        {
            List<Contact> birthdayPeople = new List<Contact>();
            for (int i = 0; i < contactsList.Count; i++)
            {
                 if(contactsList[i].DateOfBirth.Month == birthday.Month && 
                        contactsList[i].DateOfBirth.Day == birthday.Day)
                {
                    birthdayPeople.Add(contactsList[i]);
                }
            }

            return birthdayPeople;
        }
    }
}
