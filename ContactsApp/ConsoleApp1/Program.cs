using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Contact one = new Contact("Volkov", "Mark",new PhoneNumber(71118888899), new DateTime(2018, 03, 02), "mail", 2231);
            Contact two = new Contact();
            two.Surname = "Udashkin";
            two.Name = "Uriy";
            two.Number = new PhoneNumber(78888888899);
            two.BirthDateTime = new DateTime(2018, 03, 02);
            two.Mail = "Udav@mail.ru";
            two.VkID = 3331;
            Console.WriteLine($"Первый контакт: Surname: {one.Surname} Name: {one.Name} Number: {one.Number.Number} Mail: {one.Mail}");
            Console.WriteLine($"Второй контакт: Surname: {two.Surname} Name: {two.Name} Number: {two.Number.Number} Mail: {two.Mail}");
            
            Project prog = new Project();
            Project prog2 = new Project();

            prog.contactsList.Add(one);
            prog.contactsList.Add(two);
            Console.WriteLine($"Второй контакт из списка контактов: Surname: {prog.contactsList[1].Surname} Name: {prog.contactsList[1].Name} Number: {prog.contactsList[1].Number.Number} Mail: {prog.contactsList[1].Mail}");

            ProjectManager.SaveToFile(prog, "ContactsApp.notes");
            
            prog2 = ProjectManager.LoadFromFile("ContactsApp.notes");

            Console.WriteLine($"Второй контакт из загруженного из файла списка: Surname: {prog2.contactsList[1].Surname} Name: {prog2.contactsList[1].Name} Number: {prog2.contactsList[1].Number.Number} Mail: {prog2.contactsList[1].Mail}");
            Console.ReadLine();

        }
    }
}
