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

            Contact one = new Contact("Volkov", "Alibek",new PhoneNumber(71118888899), new DateTime(2018, 03, 02), "mail", 2232);
            Contact two = new Contact("Udashkin ", "name",new PhoneNumber( 78888888899), new DateTime(2018, 03, 02), "mail", 2232);

            //Project prog = new Project() ;
            ////prog.contactsList.Add(one);
            ////prog.contactsList.Add(two);
            ////Console.WriteLine(prog.contactsList[0].Number.Number);
            
            //Project prog2 = new Project();
            
            //ProjectManager.SaveToFile(prog, "C:\\Users\\AlischRak9\\Desktop\\jaaaason.notes");
            //ProjectManager.LoadFromFile("C:\\Users\\AlischRak9\\Desktop\\jaaaason.notes");
            
            Console.ReadLine();

        }
    }
}
