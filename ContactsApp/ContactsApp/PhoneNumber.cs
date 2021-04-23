using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using System.Text;

namespace ContactsApp
{
    /// <summary>
    /// Класс хранящий номер контакта.
    /// </summary>
    public class PhoneNumber
    {
        private long _number;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public PhoneNumber(long number)
        {
            Console.WriteLine("Конструктор номера сработал!");
            Number = number;
        }

        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public PhoneNumber()
        {
            
        }

        /// <summary>
        /// Возвращает и задает Номер телефона контакта. Номер не должен превышать 11 символов и начинаться с 7
        /// </summary>
        public long Number
        {
            get { return _number;}
            set
            {
                string num = value.ToString();
                if (num.Length != 11 || num[0] != '7')
                {
                    throw new ArgumentException("Nea!");
                }

                _number = value;
            }
        }
    }
}
