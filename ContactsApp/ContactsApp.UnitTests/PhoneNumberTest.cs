using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ContactsApp.UnitTests
{
    public class PhoneNumberTest
    {
        private PhoneNumber _phoneNumber;

        [SetUp]
        public void InitContact()
        {
            _phoneNumber = new PhoneNumber();  
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumberGet_CorrectValue()
        {
            var expected = 75555555556;
            _phoneNumber.Number = expected;
            var actual = _phoneNumber.Number;

            Assert.AreEqual(expected, actual, "Геттер возвращает неправильный номер");
        }

        [TestCase("12345678910", "Должно возникнуть исключение, если первый символ номера не 7",
            TestName = "Присвоение номера, начинающегося не с 7")]
        [TestCase("7244444344445678910", "Должно возникнуть исключение, если кол-во символов номера не равно 11",
            TestName = "Присвоение номера, кол-во символов которого, не равно 11")]
        public void TestNumberSet_ArgumentException(string wrongNumber, string message)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _phoneNumber.Number = Int64.Parse(wrongNumber);
            }, message);
        }

    }
}
