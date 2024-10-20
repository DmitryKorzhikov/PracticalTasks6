using System;
using System.ComponentModel;
using System.ComponentModel.Design;
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
            string sType = String.Empty;
            Repository rep = new Repository("Employers.txt");
            rep.Load();
            int q = 1;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Что Вы хотите сделать?:");
                Console.WriteLine("Вывести полный список сотрудников - введите 1");
                Console.WriteLine("Добавить нового сотрудника - 2");
                Console.WriteLine("Изменить данные сотрудника - 3");
                Console.WriteLine("Удалить сотрудника - 4");
                Console.WriteLine("Отсортировать список сотрудников - 5");
                Console.WriteLine("Вывести список сотрудников, день рождение у которых между заданными датами - 6");
                Console.WriteLine("Выйти из программы - 0");
                sType = Console.ReadLine();
                switch (sType)
                {
                    case "1":
                        Console.WriteLine();
                        //Получение списка сотрудников
                        rep.PrintDBToConsole();
                        Console.ReadKey();
                        break;
                    case "2":

                        Console.WriteLine();
                        //Добавление нового сотрудника
                        Console.WriteLine("Для добавления нового сотрудника введите ФИО:");
                        String FIO = Console.ReadLine();
                        Console.WriteLine("возраст:");
                        String Age = Console.ReadLine();
                        Console.WriteLine("рост:");
                        String Height = Console.ReadLine();
                        Console.WriteLine("дата рождения(dd.mm.yyyy):");
                        String DateBirth = Console.ReadLine();
                        Console.WriteLine("место рождения:");
                        String PlaceBirth = Console.ReadLine();
                        int maxID = 1;
                        foreach(Worker wM in rep.Workers)
                        {
                            if (wM.ID > maxID)
                            { 
                                maxID = wM.ID;
                            };
                        }
                        AddNewWorker(rep, new Worker(++maxID, 
                                                     FIO, 
                                                     Convert.ToInt32(Age), 
                                                     Convert.ToInt32(Height), 
                                                     Convert.ToDateTime(DateBirth), 
                                                     PlaceBirth));
                            rep.PrintDBToConsole();
                            rep.SaveToFile();
                            Console.ReadKey();
                            break;
                    case "3":

                        Console.WriteLine();
                        //Изменение данных сотрудника
                        Console.WriteLine("Введите ID сотрудника, которого требуется изменить:");
                        String IDEdit = Console.ReadLine();
                        Worker w2 = GetWorkerRep(rep, IDEdit);
                        if (w2.ID > 0)
                        {
                            Console.WriteLine("Найден сотрудник с данными.");
                            rep.PrintHead();
                            Console.WriteLine(w2.Print());
                            String TypeEdit = String.Empty;
                            String TypeEdit2 = String.Empty;
                            int Error = -1;
                            do
                            {
                                Console.WriteLine();
                                Console.WriteLine("Что Вы хотите изменить?:");
                                Console.WriteLine("если нужно изменить ФИО - введите 1");
                                Console.WriteLine("рост - 2");
                                Console.WriteLine("возраст - 3");
                                Console.WriteLine("дату рожения - 4");
                                Console.WriteLine("место рождения - 5");
                                Console.WriteLine("Закончить изменения - 0");
                                TypeEdit = Console.ReadLine();
                                switch (TypeEdit)
                                {
                                    case "1":
                                        TypeEdit2 = "ФИО";
                                        break;
                                    case "2":
                                        TypeEdit2 = "Рост";
                                        break;
                                    case "3":
                                        TypeEdit2 = "Возраст";
                                        break;
                                    case "4":
                                        TypeEdit2 = "Дата рождения";
                                        break;
                                    case "5":
                                        TypeEdit2 = "Место рождения";
                                        break;
                                    case "0":
                                        break;
                                    default:
                                        int q2 = 1;
                                        if (q2 == 1)
                                        {
                                            Console.WriteLine("Вы уверены? Такого варианта нет в предложенном списке! Попробуйте еще раз!");
                                            q2++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Болван будь внимательнее. Для выхода введи 0!");
                                        }
                                        Error = 1;
                                        break;
                                }
                                if (Error == -1)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Введите новое значение:");
                                    String NewValue = Console.ReadLine();
                                    if (!String.IsNullOrEmpty(NewValue))
                                    {
                                        
                                        EditWorker(rep, ref w2, TypeEdit2, NewValue);
                                        Console.WriteLine();
                                        rep.PrintHead();
                                        Console.WriteLine(w2.Print());
                                        Console.ReadKey();
                                        rep.SaveToFile();
                                    }
                                }
                            }
                            while (TypeEdit != "0");
                        }
                        else {
                            Console.WriteLine();
                            Console.WriteLine("Сотрудника с таким ID не найдено!"); 
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.WriteLine();
                        //Удаление данных сотрудника
                        Console.WriteLine("Введите ID сотрудника, которого требуется удалить:");
                        String IDDelete = Console.ReadLine();
                        Worker w3 = GetWorkerRep(rep, IDDelete);
                        if (w3.ID > 0)
                        {
                            rep.DeleteWorker(w3.ID);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Сотрудника с таким ID не найдено!");
                        }
                        //Console.ReadKey();
                        break;
                    case "5":
                        Console.WriteLine();
                        //Сортировка сотрудников
                        Console.WriteLine("Введите по какому параметру отсортировать сотрудников:");
                        Console.WriteLine("если нужно отсортировать по ФИО - введите 1");
                        Console.WriteLine("росту - 2");
                        Console.WriteLine("возрасту - 3");
                        Console.WriteLine("дате рожения - 4");
                        Console.WriteLine("месту рождения - 5");
                        Console.WriteLine("дате создания - 6");
                        string sTypeOrder = Console.ReadLine();
                        Worker[] w1 = rep.GetAllWorkers();

                        int i = 0;
                        switch (sTypeOrder)
                        {
                            case "6":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            case "1":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            case "3":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            case "2":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            case "4":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            case "5":
                                Console.WriteLine();
                                rep.PrintHead();
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
                            default:
                                Console.WriteLine();
                                Console.WriteLine("Такого варианта сортировки не найдено!");
                                break;
                        }
                        Console.ReadKey();
                        rep.SaveToFile();
                        break;
                    case "6":
                        Console.WriteLine();
                        //Вывод сотрудников, у которых ДР находится между двумя введенными датами
                        Console.WriteLine("Введите дату(dd.mm.yyyy), с которой начать поиск сотрудников:");
                        String DateFrom = Console.ReadLine();
                        Console.WriteLine("Введите дату(dd.mm.yyyy), до которой необходимо продолжать поиск сотрудников:");
                        String DateTo = Console.ReadLine();
                        if(!String.IsNullOrEmpty(DateFrom) && !String.IsNullOrEmpty(DateTo))
                        {
                            Console.WriteLine();
                            rep.PrintHead();
                            foreach (Worker w in rep.GetWorkersBetweenTwoDates(Convert.ToDateTime(DateFrom), Convert.ToDateTime(DateTo)))
                            {
                                String s = w.Print();
                                if (!String.IsNullOrEmpty(s))
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Данные для поиска не корректны!");
                            Console.ReadKey();
                        }
                        break;
                    default:
                        if (q == 1) {
                            Console.WriteLine();
                            Console.WriteLine("Вы уверены? Такого варианта нет в предложенном списке! Попробуйте еще раз!");
                            q++;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Болван будь внимательнее. Для выхода введи 0!");
                        }
                        break;

                        
                };
                
                
                
            }
            while(sType != "0");
        }
    }
}
