using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace ContactsApp.UnitTests
{
    [TestFixture]
    public class ProjectManagerTest
    {
        private static readonly string defaultFolder = Environment.
            GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ContactsAppTest";

        public static readonly string defaultFilename = defaultFolder + "\\ContactsAppTest.notes";

        private Project _project;

        [SetUp]
        public void InitProjectManager()
        {
            Directory.CreateDirectory(defaultFolder);

            _project = new Project()
            {
                Contacts = new List<Contact>() {
                    new Contact("Grigorev", "Oleg", new PhoneNumber(73333333333), new DateTime(2000, 1, 1), "grek@mail.ru",2),
                    new Contact("Tutashev", "Alex", new PhoneNumber(74444444443), new DateTime(2002, 10, 4), "tuta@mail.ru",23),
                    new Contact("Babaev", "Artem", new PhoneNumber(73335553333), new DateTime(2001, 9, 10), "bash@mail.ru",24),
                    new Contact("Fisher", "Sam", new PhoneNumber(73333633363), new DateTime(2000, 11, 11), "gid@mail.ru",25),
                    }
            };
        }

        [TearDown]
        public void TearDownProjectManager()
        {
            File.Delete(defaultFilename);
            Directory.Delete(defaultFolder);
        }

        [Test]
        public void TestSaveToFile()
        {            
            var expected = _project.Contacts;
            
            ProjectManager.SaveToFile(_project, defaultFilename);
            var actual = ProjectManager.LoadFromFile(defaultFilename).Contacts;
            
            CollectionAssert.AreEqual(expected, actual, "");
        }

        [Test]
        public void TestLoadFromFile_NonExistentFile()
        {
            Assert.Throws<Exception>(
                () => { ProjectManager.LoadFromFile("aaaaaaaaaaaaa"); });            
        }

        [Test]
        public void TestLoadFromFile_CorruptedFile()
        {
            
           
        }
    }
}
