using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        private Project _project;        

        [SetUp]
        public void InitContact()
        {
            _project = new Project();
            _project.Contacts = new List<Contact>()
            {
                new Contact("Grigorev", "Oleg", new PhoneNumber(73333333333), new DateTime(2000, 1, 1), "grek@mail.ru",2),
                new Contact("Tutashev", "Alex", new PhoneNumber(74444444443), new DateTime(2002, 10, 4), "tuta@mail.ru",23),
                new Contact("Babaev", "Artem", new PhoneNumber(73335553333), new DateTime(2001, 9, 10), "bash@mail.ru",24),
                new Contact("Fisher", "Sam", new PhoneNumber(73333633363), new DateTime(2000, 11, 11), "gid@mail.ru",25),
            };
        }

        [Test(Description = "Тест сортировки списка по фамилиям")]
        public void TestSort()
        {
            var expected = "Babaev, Fisher, Grigorev, Tutashev";
            _project.Sort();
            var surnames = _project.Contacts.Select(contact => contact.Surname);
            var actual = string.Join(", ", surnames);

            Assert.AreEqual(expected, actual, "Функция Sort неправильно сортирует");
        }

        [Test(Description = "Тест ф-ции для поисковой строки с нахождением совпадения")]
        public void TestFindContacts()
        {
            var str = "tut";
            List<Contact> expected = new List<Contact>() {
                new Contact("Tutashev", "Alex", new PhoneNumber(74444444443), new DateTime(2002, 10, 4), "tuta@mail.ru", 23) };

            var actual = _project.FindContacts(str);

            CollectionAssert.AreEqual(expected, actual, " Ф-ция FindContacts работает неправильно");
        }

        [Test(Description = "Тест ф-ции для поисковой строки без нахождением совпадения")]
        public void TestFindContacts_WithoutMatches()
        {
            var str = "tam";
            List<Contact> expected = new List<Contact>();

            var actual = _project.FindContacts(str);

            CollectionAssert.IsEmpty(actual, "Функция FindContacts работает неправильно, список должен быть пуст");
        }

        [Test(Description = "Тест ф-ции для пустой поисковой строки")]
        public void TestFindContacts_EmptyString()
        {
            string str = "";
            List<Contact> expected = _project.Contacts;

            var actual = _project.FindContacts(str);
         
            CollectionAssert.AreEquivalent(expected, actual, "Функция FindContacts работает неправильно," +
                " список должен быть равен изначальному");
        }

        [Test(Description = "Тест ф-ции для вывода именинников")]
        public void TestShowBirthdayPeople()
        {
            DateTime dateTime = new DateTime(2000,9,10);
            var expected = new List<Contact>() {
                new Contact("Babaev", "Artem", new PhoneNumber(73335553333), new DateTime(2001, 9, 10), "bash@mail.ru", 24)};

            var actual = _project.ShowBirthdayPeople(dateTime);

            CollectionAssert.AreEqual(expected, actual, "Функция ShowBirthdayPeople работает неправильно");
        }

        [Test(Description = "Тест ф-ции для вывода именинников без нахождением совпадения")]
        public void TestShowBirthdayPeople_NetSovpadeniy()
        {
            DateTime dateTime = new DateTime(2000, 12, 16);
            var expected = new List<Contact>();

            var actual = _project.ShowBirthdayPeople(dateTime);

            CollectionAssert.AreEqual(expected, actual, "Функция ShowBirthdayPeople работает неправильно," +
                "список должен быть пустым");
        }
    }
}
