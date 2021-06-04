using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            Contact one = new Contact("Volkov", "Mark",new PhoneNumber(71118888899), new DateTime(2020, 03, 02), "mail", 2231);
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
            Project prog3 = new Project();

            prog.contactsList.Add(one);
            prog.contactsList.Add(two);
            Console.WriteLine($"Второй контакт из списка контактов: Surname: {prog.contactsList[1].Surname} Name: {prog.contactsList[1].Name} Number: {prog.contactsList[1].Number.Number} Mail: {prog.contactsList[1].Mail}");

            ProjectManager.SaveToFile(prog, "ContactsApp.notes");
            
            prog2 = ProjectManager.LoadFromFile("ContactsApp.notes");

            Console.WriteLine($"Второй контакт из загруженного из файла списка: Surname: {prog2.contactsList[1].Surname} Name: {prog2.contactsList[1].Name} Number: {prog2.contactsList[1].Number.Number} Mail: {prog2.contactsList[1].Mail}");

            Contact tri = new Contact();
            tri = (Contact)one.Clone();
            tri.Number.Number = 77777777777;
            tri.Name = "Alfredo";
            Console.WriteLine(one.Number.Number);
            Console.WriteLine(one.Name);
            
            
            prog3 = prog;
            prog.contactsList[0].Surname = "Beshbarmak";
            Console.WriteLine(prog3.contactsList[0].Surname);

            Project prog4 = new Project();
            prog4.contactsList.Add( prog.contactsList[0]);
            Console.WriteLine(prog.contactsList[0].Surname);
            prog4.contactsList[0].Surname = "хя";
            Console.WriteLine(prog.contactsList[0].Surname);

            List<Contact> list1 = new List<Contact>(200);
            List<Contact> list2 = new List<Contact>(200);
            
            list1.Add(one);
            list1.Add(one);
            list1.Add(one);
            list1.Add(one);
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    list2.Add(list1[i]);
                }    
            }

            Console.WriteLine(list1.Count);
            Console.WriteLine(list2.Count);
            Console.WriteLine("______________");
            list2.RemoveAt(0);
            Console.WriteLine(list1.Count);
            Console.WriteLine(list2.Count);
            Console.ReadLine();

        }
    }
}
