using System.ComponentModel;
using System.Text;

namespace PracticalTasks6
{
        static void Main(string[] args)
        {
            Console.WriteLine("<<Программа учета сотрудников>>");
            Console.WriteLine("Если Вы хотите вывести список сотрудников на экран нажмите 1");
            Console.WriteLine("Если Вы хотите добавить нового сотрудника нажмите 2");
            string sType = Console.ReadLine();
            switch (sType)
            {
                case "1": 
                    Show();
                    break;
                case "2":
                    AddNew();
                    break;
             };
                     
        }
    }
}
