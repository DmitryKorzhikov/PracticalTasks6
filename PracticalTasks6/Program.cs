using System.ComponentModel;
using System.Text;

namespace PracticalTasks6
{ class Program
    {
        
        public static void AddNewWorker(Repository r,Worker w)
        {
            r.AddWorker(w);
        }
        public static void EditWorker(Repository r, ref Worker w, string Field, string Value)
        {
            switch (Field)
            {
                case "ФИО":
                    w.FIO = Value;
                    break;
                case "Рост":
                    w.Height = Convert.ToInt32(Value);
                    break;
                case "Возраст":
                    w.Age = Convert.ToInt32(Value); ;
                    break;
                case "Дата рождения":
                    w.BirthDate = Convert.ToDateTime(Value);
                    break;
                case "Место рождения":
                    w.PlaceBirth = Value;
                    break;
            }
            int i = -1;
            Worker w2 = r.GetWorkerById(w.ID,ref i);
            r.Workers[i] = w;
        }
        public static Worker GetWorkerRep(Repository r, string ID)
        {
            int i = -1;
            Worker w = r.GetWorkerById(Convert.ToInt32(ID),ref i);
            return w;
            
        }
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
                    //Получение списка сотрудников
                    rep.PrintDBToConsole();
                    break;
                case "2":
                    {
                        //Добавление нового сотрудника
                        AddNewWorker(rep, new Worker(1, "Сотрудник 1", 22, 175, Convert.ToDateTime("07.01.1999"), "Москва"));
                        rep.PrintDBToConsole();
                        break;
                    }
            };
            //Вывод сотрудников ограниченных по дате
            Console.WriteLine("Вывод сотрудников, у которых день рождение в сентябре 2022 года.");

            rep.PrintHead();
            foreach (Worker w in rep.GetWorkersBetweenTwoDates(Convert.ToDateTime("01.09.2022"), Convert.ToDateTime("30.09.2022")))
            {
                String s = w.Print();
                if (!String.IsNullOrEmpty(s))
                {
                    Console.WriteLine(s);
                }
            }
            //Сортировка сотрудников
            Console.WriteLine("Введите по какому параметру отсортировать сотрудников(ФИО, Дата создания, Возраст, Рост, Дата рождения, Место рождения)");
            string sTypeOrder = Console.ReadLine();

            rep.PrintHead();

            Worker[] w1 = rep.GetAllWorkers();

            int i = 0;
            switch (sTypeOrder)
            {
                case "Дата создания":
                    IEnumerable<Worker> query1 = w1.OrderBy(worker => worker.CreationDate);
                    i = 0;
                    foreach (Worker wr in query1)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
                case "ФИО":
                    IEnumerable<Worker> query2 = w1.OrderBy(worker => worker.FIO);
                    i = 0;
                    foreach (Worker wr in query2)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
                case "Возраст":
                    IEnumerable<Worker> query3 = w1.OrderBy(worker => worker.Age);
                    i = 0;
                    foreach (Worker wr in query3)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
                case "Рост":
                    IEnumerable<Worker> query4 = w1.OrderBy(worker => worker.Height);
                    i = 0;
                    foreach (Worker wr in query4)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
                case "Дата рождения":
                    IEnumerable<Worker> query5 = w1.OrderBy(worker => worker.BirthDate);
                    i = 0;
                    foreach (Worker wr in query5)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
                case "Место рождения":
                    IEnumerable<Worker> query6 = w1.OrderBy(worker => worker.PlaceBirth);
                    i = 0;
                    foreach (Worker wr in query6)
                    {
                        if (wr.ID > 0)
                        {
                            Console.WriteLine(wr.Print());
                            rep.Workers[i] = wr;
                            i++;
                        }
                    }
                    break;
            }
            //Редактирование сотрудника
            Worker w2 = GetWorkerRep(rep, "5");
            EditWorker(rep, ref w2, "Рост", "220");
            rep.SaveToFile();



        }
    }
}
