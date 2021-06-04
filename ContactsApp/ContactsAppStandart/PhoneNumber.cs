using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using System.Text;

namespace ContactsApp1
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
                    throw new ArgumentException("Кол-во символов не равно 11, либо номер начинается не с 7");
                }

                _number = value;
            }
        }
    }
}
