using System.ComponentModel;
using System.Text;

namespace PracticalTasks6
{ class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("<<Программа учета сотрудников>>");
            Console.WriteLine("Если Вы хотите вывести список сотрудников на экран нажмите 1");
            Console.WriteLine("Если Вы хотите добавить нового сотрудника нажмите 2");
            Repository rep = new Repository("Employers.txt");
            rep.Load();
            string sType = Console.ReadLine();
            switch (sType)
            {
                case "1":
                    rep.PrintDBToConsole();
                    break;
                case "2":
                    {
                        rep.AddWorker(new Worker(1, "Сотрудник 1", 22, 175, Convert.ToDateTime("07.01.1999"), "Москва"));
                        rep.PrintDBToConsole();
                        break;
                    }
            };
            Console.WriteLine("Вывод сотрудников, у которых день рождение в сентябре 2022 года.");

            rep.PrintHead();
            foreach (Worker w in rep.GetWorkersBetweenTwoDates(Convert.ToDateTime("01.09.2022"), Convert.ToDateTime("30.09.2022")))
            {
                if (!String.IsNullOrEmpty(w.Print()))
                {
                    Console.WriteLine(w.Print());
                }
            }
            Console.WriteLine("Введите по какому параметру отсортировать сотрудников(ID, FIO, Create date, Age, Height, Birthdate, Birth place)");
            string sTypeOrder = Console.ReadLine();
            
            rep.PrintHead();

            Worker[] w1 = rep.GetAllWorkers();

            
            switch (sTypeOrder)
            {
                case "ID":
                    IEnumerable<Worker> query = w1.OrderBy(wo => wo.ID);
                    foreach (Worker wr in query)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "Create date":
                    IEnumerable<Worker> query1 = w1.OrderBy(worker => worker.DateTime);
                    foreach (Worker wr in query1)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "FIO":
                    IEnumerable<Worker> query2 = w1.OrderBy(worker => worker.sFIO);
                    foreach (Worker wr in query2)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "Age":
                    IEnumerable<Worker> query3 = w1.OrderBy(worker => worker.nAge);
                    foreach (Worker wr in query3)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "Height":
                    IEnumerable<Worker> query4 = w1.OrderBy(worker => worker.nHeight);
                    foreach (Worker wr in query4)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "Birthdate":
                    IEnumerable<Worker> query5 = w1.OrderBy(worker => worker.dBirthDate);
                    foreach (Worker wr in query5)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
                case "Birth place":
                    IEnumerable<Worker> query6 = w1.OrderBy(worker => worker.sPlaceBirth);
                    foreach (Worker wr in query6)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                        }
                    }
                    break;
            }
            
            
            

            
        }
    }
}
