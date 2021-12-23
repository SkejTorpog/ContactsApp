using System;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ContactTest
    {
        private Contact _contact;

        [SetUp]
        public void InitContact()
        {
            _contact = new Contact();
        }

        [Test(Description ="Позитивный тест геттера Surname")]
        public void TestSurnameGet_CorrectValue()
        {
            var expected = "Смирнов";           
            _contact.Surname = expected;
            var actual = _contact.Surname;

            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }
     
        [TestCase("Смирнов-Смирнов-Смирнов-Смирнов-Смирнов-СмирновСмирнов-Смирнов-Смирнов-Смирнов", "Должно возникать исключение," +
            "если фамилия длинее 40 символов",
            TestName = "Присвоение неправильной фамилии больше 40 символов")]
        public void TestSurnameSet_ArgumentException(string wrongSurname, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Surname = wrongSurname; }, message);
        }

        [Test(Description = "Позитивный тест геттера Name")]
        public void TestNameGet_CorrectValue()
        {
            var expected = "Иван";
            _contact.Name = expected;
            var actual = _contact.Name;

            Assert.AreEqual(expected, actual, "Геттер Name возвращает неправильное имя");
        }
      
        [TestCase("Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван-Иван",
            "Должно возникнуть исключение, если имя длинее 50 символов",
            TestName = "Присвоение неправильного имени больше 50 символов")]
        public void TestNameSet_ArgumentException(string wrongName, string message)
        {
            Assert.Throws<ArgumentException>(
                () => { _contact.Name = wrongName; }, message);
        }

        [Test(Description = "Позитивный тест геттера EMail")]
        public void TestEMailGet_CorrectValue()
        {
            var expected = "gnomov@mail.ru";
            _contact.EMail = expected;
            var actual = _contact.EMail;

            Assert.AreEqual(expected, actual, "Геттера EMail возвращает неправильный эл. адрес");
        }

        [Test(Description = "Присвоение неправильного адреса длиной больше 50 символов")]
        public void TestEmailSet_Longer50Symbols()
        {
            var wrongEmail = "magnus@mail.ru-magnus@mail.ru-magnus@mail.ru-magnus@mail.ru";

            Assert.Throws<ArgumentException>(
                () => { _contact.EMail = wrongEmail; },
                "Должно возникнуть исключение, если EMail больше 50 символов");
        }

        [Test(Description = "Позитивный тест геттера VkId")]
        public void TestVkIdGet_CorrectValue()
        {
            var expected = Convert.ToInt64("123");
            _contact.VkID = expected;
            var actual = _contact.VkID;

            Assert.AreEqual(expected, actual, "Геттера VkId возвращает неправильный id ВКонтакте");
        }

        [Test(Description = "Присвоение неправильного id длиной больше 15 символов")]
        public void TestVkIdSet_Longer15Symbols()
        {
            var wrongVkID = "01234567891463456";

            Assert.Throws<ArgumentException>(
                () => { _contact.VkID = Convert.ToInt64(wrongVkID); },
                "Должно возникнуть исключение, если VkID больше 15 символов");
        }

        [Test(Description = "Позитивный тест геттера Number")]
        public void TestNumberGet_CorrectValue()
        {
            var expected = 79165127364;
            _contact.Number = new PhoneNumber(expected);
            var actual = _contact.Number.Number;

            Assert.AreEqual(expected, actual, "Геттера Number возвращает неправильный номер телефона");
        }

        [TestCase("1234567890","Должно возникать исключение, если первый символ номера не 7",
            TestName = "Присвоение номера, начинающегося не с 7")]
        [TestCase("71234567890366", "Должно возникать исключение, если кол-во символов больше 11",
            TestName = "Присвоение неправильного номера, больше 11 символов")]
        public void TestNumberSet_ArgumentException(string wrongNumber, string message)
        {
            PhoneNumber number = new PhoneNumber(Int64.Parse(wrongNumber));
            Assert.Throws<ArgumentException>(
                () => { _contact.Number = number; }, message);
        }

        [Test(Description = "Позитивный тест геттера DateOfBirth")]
        public void TestDateOfBirthGet_CorrectValue()
        {
            var expected = new DateTime(1986,1,4);
            _contact.DateOfBirth = expected;
            var actual = _contact.DateOfBirth;

            Assert.AreEqual(expected, actual, "Геттера DateOfBirth возвращает неправильную дату рождения");
        }

        [TestCase("05/05/1897","Должно возникнуть исключение, если дата раньше 01/01/1900",
            TestName = "Присвоение неправильной даты, раньше 01/01/1900г")]
        [TestCase("05/05/2200", "Должно возникнуть исключение, если дата позже настоящего времени",
            TestName = "Присвоение неправильной даты, позже настоящей")]
        public void TestDateOfBirthSet_ArgumentException(string wrongDateOfBirth, string message)
        {
            DateTime dateOfBirth = Convert.ToDateTime(wrongDateOfBirth);
            Assert.Throws<ArgumentException>(
                () => { _contact.DateOfBirth = dateOfBirth; }, message);
        }
    }
}
