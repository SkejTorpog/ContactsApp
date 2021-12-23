﻿using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс, хранящий номер телефона
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Поле, хранящее номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// Возвращает и задает Номер телефона контакта. Номер не должен превышать 11 символов и начинаться с 7
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                string number = value.ToString();
                if (number.Length != 11 || number[0] != '7')
                {
                    throw new ArgumentException(
                        $"Кол-во символов должно быть равно 11, и номер должен начинаться с 7. " +
                        $"Введеное кол-во символов: {number.Length}," +
                        $" первая цифра: {number[0]} ");
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
        /// Конструктор класса без параметров
        /// </summary>
        public PhoneNumber()
        {
            
        }
    }
}
