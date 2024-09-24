using System.ComponentModel;
using System.Text;

namespace PracticalTasks6
{
    internal class Program
    {
        static void AddNew()
        {
            using (StreamWriter sw = new StreamWriter("Employers.txt",true, Encoding.Unicode))
            {
                string row = string.Empty;
                Console.Write("\nВведите ID сотрудника: ");
                row += $"{Console.ReadLine()}#";

                string now = DateTime.Now.ToString();
                row += $"{now}#";

                
                Console.Write("\nВведите ФИО сотрудника: ");
                row += $"{Console.ReadLine()}#";
                Console.Write("\nВведите Возраст сотрудника: ");
                row += $"{Console.ReadLine()}#";
                Console.Write("\nВведите Рост сотрудника: ");
                row += $"{Console.ReadLine()}#";
                Console.Write("\nВведите Дату рождения сотрудника: ");
                row += $"{Console.ReadLine()}#";
                Console.Write("\nВведите Место рождения сотрудника: ");
                row += $"{Console.ReadLine()}#";
                sw.WriteLine(row);
            }
        }
        static void Show()
        {
            using (StreamReader sr = new StreamReader("Employers.txt", Encoding.Unicode))
            {
                string row;
                Console.WriteLine($"{"ID ",-3}{"Дата и время добавления ",-25}{"ФИО ",-15}{"Возраст ",-10}{"Рост ",-5}{"Дата рождения ",-15}{"Место рождения",-15}");
                while((row = sr.ReadLine())!=null)
                {
                    string[] data = row.Split("#");
                    Console.WriteLine($"{data[0],-3}{data[1],-25}{data[2],-15}{data[3],-10}{data[4],-5}{data[5],-15}{data[6],-15}");
                }
            }
        }
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
