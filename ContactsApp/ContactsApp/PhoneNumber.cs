using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Numerics;
using System.Text;

namespace ContactsApp
{
    public class PhoneNumber
    {
        private long _number;

        public void SetNumber(long number)
        {
            string num = number.ToString();
            if (num.Length != 11 || num[0] != '7')
            {
                throw new Exception("Nea!");
            }
  
        }
    }
}
