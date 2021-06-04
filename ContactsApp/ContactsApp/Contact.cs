using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс контакта, хранящий информацию о фамилии, имени, номере, дне рождения, почте и id вк.
    /// </summary>
    public class Contact: ICloneable,IComparable
    {
        private string _surname;
        private string _name;
        private PhoneNumber _number;
        private DateTime _birthDateTime;
        private string _mail;
        private long _vkID;


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
            get
            {
                return _surname;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException($"Поле Фамилии превышает 50 символов. Кол-во символов сейчас: {value.Length}" );
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
                    throw new ArgumentException($"Поле Имени превышает 50 символов. Кол-во символов сейчас: {value.Length}");
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
                    throw new ArgumentException($"Поле Почты превышает 50 символов. Кол-во символов сейчас: {value.Length}");
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
                    throw new ArgumentException($"Поле ВкID превышает 50 символов. Кол-во символов сейчас: {value.ToString().Length}");
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
                    throw new ArgumentException($"Дата должна входить в диапозон от 01.01.1900г до {DateTime.Now}. Введенная дата: {value} ");
                }
                _birthDateTime = value;
            }
        }
        /// <summary>
        /// Конструктор для контакта
        /// </summary>
        /// <param name="surname">Поле, хранящее фамилию контакта</param>
        /// <param name="name">Поле, хранящее имя контакта</param>
        /// <param name="number">Поле, хранящее номер контакта</param>
        /// <param name="birthDateTime">Поле, хранящее дату рождения контакта</param>
        /// <param name="mail">Поле, хранящее эл. почту контакта</param>
        /// <param name="vkID">Поле, хранящее id ВК контакта</param>
        public Contact(string surname, string name, PhoneNumber number, DateTime birthDateTime, string mail, long vkID)
        {

            _surname = surname;
            _name = name;
            _number = number;
            _birthDateTime = birthDateTime;
            _mail = mail;
            _vkID = vkID;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Contact()
        {

        }

        /// <summary>
        /// Метод Clone, для глубокого копирования контакта
        /// </summary>
        public object Clone()
        {
            PhoneNumber number = new PhoneNumber { Number = this.Number.Number };
            return new Contact
            {
                Name = this.Name,
                Surname = this.Surname,
                Number = number,
                BirthDateTime = this.BirthDateTime,
                Mail = this.Mail,
                VkID = this.VkID
            };            
        }
        /// <summary>
        /// Метод для сравнения текущего объекта с объектом, переданным в качестве параметра "object o".
        /// </summary>
        public int CompareTo(object o)
        {
            Contact p = o as Contact;
            if (p != null)
                return this.Surname.CompareTo(p.Surname);
            else
                throw new ArgumentException("Невозможно сравнить два объекта");
        }
    }
}
