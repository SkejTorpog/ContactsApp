using System;
using NUnit.Framework;
using ContactsApp;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test(Description ="Позитивный тест геттера Surname")]
        public void TestMethod1()
        {
            var expected = "Смирнов";
            var contact = new Contact();
            contact.Surname = expected;
            var actual = contact.Surname;

            Assert.AreEqual(expected, actual, "Геттер Surname возвращает неправильную фамилию");
        }
    }
}
