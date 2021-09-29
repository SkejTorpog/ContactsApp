using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp1
{
    /// <summary>
    /// Класс контакта, хранящий информацию о фамилии, имени, номере, дне рождения, почте и id вк.
    /// </summary>
    public class Contact : ICloneable
    {
        private string _surname;
        private string _name;
        private PhoneNumber _number;
        private DateTime _birthDateTime;
        private string _mail;
        private long _vkID;

        /// <summary>
        /// Конструктор для контакта
        /// </summary>
        public Contact(string surname, string name, PhoneNumber number, DateTime birthDateTime, string mail, long vkID)
        {            
            _surname = surname;
            _name = name;
            _number = number;
            _birthDateTime = birthDateTime;
            _mail = mail;
            _vkID = vkID;
        }

        public Contact()
        {

        }

        /// <summary>
        /// Возвращает номер контакта
        /// </summary>
        public PhoneNumber Number
        { 
            get { return _number; } 
            set 
            {
                _number = value;
            } 
        }

        /// <summary>
        /// Возвращает и задает фамилию контакта. Длина фамилии не должна превышать 50-ти символов
        /// </summary>
        public string Surname
        {
            get {
                return _surname;
                }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Символов больше 50");
                }
                _surname = value.ToUpper()[0] + value.Substring(1).ToLower();
                
            }
        }

        /// <summary>
        /// Возвращает и задает имя контакта. Длина имени не должна превышать 50 символов.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Символов больше 50");
                }

                _name = value.ToUpper()[0] + value.Substring(1).ToLower();
            }

        }

        /// <summary>
        /// Возвращает и задает адрес эл. почты контакта. Длина адреса не должна превышать 50-ти символовю.
        /// </summary>
        public string Mail
        {
            get { return _mail; }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Символов больше 50");
                }
               
                _mail = value;
            }
        }

        /// <summary>
        /// Возвращает и задает id в ВК. Длина id не должна превышать 15 символов.
        /// </summary>
        public long VkID
        {
            get { return _vkID; }
            set
            {
                if (value.ToString().Length > 15)
                    throw new Exception("Символов больше 15");
                _vkID = value;
            }
        }

        /// <summary>
        /// Возвращает и задает день рождения контакта. Дата рождения должна быть в диапазоне от 1900г до настоящего времени.
        /// </summary>
        public DateTime BirthDateTime
        {
            get { return _birthDateTime; }
            set
            {
                if (value < new DateTime(1900, 1, 1) || value > DateTime.Now)
                {
                    throw new Exception("Даты выставлена неправильно");
                }
                _birthDateTime = value;
            }
        }

    }
}
