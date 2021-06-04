﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private long _number;

        /// <summary>
        /// Возвращает и задает Номер телефона контакта. Номер не должен превышать 11 символов и начинаться с 7
        /// </summary>
        public long Number
        {
            get { return _number; }
            set
            {
                string num = value.ToString();
                if (num.Length != 11 || num[0] != '7')
                {
                    throw new ArgumentException($"Кол-во символов должно быть равно 11, и номер должен начинаться с 7. " +
                        $"Введеное кол-во символов: {value.ToString().Length}, первая цифра: {value.ToString()[0]} ");
                }

                _number = value;
            }
        }
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="number"> Поле, хранящее номер телефона </param>
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
    }
}
