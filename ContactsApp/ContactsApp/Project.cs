using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий список контактов
    /// </summary>
    public class Project
    {
        public List<Contact> contactsList = new List<Contact>(200);

        public List<Contact> Assort()
        {
            var list = contactsList;
            list.Sort();
            return list;
        }

        public List<Contact> Assort(string str)
        {
            List<Contact> list = new List<Contact>(200);
            for (int i = 0; i < contactsList.Count; i++)
            {
                if (contactsList[i].Surname.ToUpper().Contains(str.ToUpper()) || contactsList[i].Name.ToUpper().Contains(str.ToUpper()))
                {
                    list.Add(contactsList[i]);
                }
            }
            list.Sort(); 
            return list;
        }

        public List<Contact> ShowBirthdayPeople(DateTime birthday)
        {
            List<Contact> list = new List<Contact>(200);
            for (int i = 0; i < contactsList.Count; i++)
            {
                if(contactsList[i].BirthDateTime.Month == birthday.Month && contactsList[i].BirthDateTime.Day == birthday.Day)
                {
                    list.Add(contactsList[i]);
                }
            }

            return list;
        }
    }
}
