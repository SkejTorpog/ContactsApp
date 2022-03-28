using System;
using System.Collections.Generic;
using System.Linq;


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
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Сортировка списка контактов
        /// </summary>      
        public List<Contact> Sort()
        {
            var sortedContacts = Contacts;
            sortedContacts.Sort();
            return sortedContacts;
        }

        /// <summary>
        /// Метод находит и возвращает список контактов, имещих в поле Surname или Name подстроку str
        /// </summary>  
        public List<Contact> FindContacts(string str)
        {
            List<Contact> foundContacts = new List<Contact>();
            for (int i = 0; i < Contacts.Count; i++)
            {
                if (Contacts[i].Surname.ToUpper().Contains(str.ToUpper()) ||
                        Contacts[i].Name.ToUpper().Contains(str.ToUpper()))
                {
                    foundContacts.Add(Contacts[i]);
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
            for (int i = 0; i < Contacts.Count; i++)
            {
                 if(Contacts[i].DateOfBirth.Month == birthday.Month && 
                        Contacts[i].DateOfBirth.Day == birthday.Day)
                {
                    birthdayPeople.Add(Contacts[i]);
                }
            }

            return birthdayPeople;
        }        
    }
}
