using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks6
{
    public class Repository
    {
        public Worker[] Workers;
        private string path;
        int index;
        string[] titles;
        
        public Repository(string path) 
        {
            this.path = path;
            this.index = 0;
            this.titles = new string[6];
            this.Workers = new Worker[2];
        }
        public void Load()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    titles = sr.ReadLine().Split('#');
                    while (!sr.EndOfStream)
                    {

                        string[] args = sr.ReadLine().Split('#');
                        AddWorker(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), args[2], Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToDateTime(args[5]), args[6]));
                    }
                }
                DeleteFile();
            }
        }
        public Worker[] GetAllWorkers()
        {
                //Load();
                
                return this.Workers;
             
        }
        public Worker GetWorkerById(int id,ref int index)
        {
            //Load();
            Worker w = new Worker();
            if (this.index > id)
            {
                for (int i=0;i<Workers.Length;i++)
                {
                    if (Workers[i].ID == id)
                    {
                        w = Workers[i];
                        index = i;
                        return w;
                        break;
                    }
                }
            }
            return w;

        }
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.Workers, this.Workers.Length * 2);
            }
        }
        private void AddFile(Worker CurWorker)
        {
            string row = String.Empty;
            if (!File.Exists(path))
            {
                row = "ID#Дата и время добавления#ФИО#Возраст#Рост#Дата рождения#Место рождения";
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
                {
                    sw.Write(row);
                }
            }

            if (CurWorker.ID > 0)
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append($"\n{CurWorker.ID}#");
                    sb.Append($"{CurWorker.CreationDate}#");
                    sb.Append($"{CurWorker.FIO}#");
                    sb.Append($"{CurWorker.Age}#");
                    sb.Append($"{CurWorker.Height}#");
                    sb.Append($"{CurWorker.BirthDate}#");
                    sb.Append($"{CurWorker.PlaceBirth}#");

                    sw.Write(sb.ToString());
                }
            }
        }
        public void SaveToFile()
        {
            foreach (Worker w in Workers)
            {
                
                    AddFile(w);
             }
        }
        public void AddWorker(Worker ConcreteWorker)
        {
            this.Resize(index >= this.Workers.Length);
            this.Workers[index] = ConcreteWorker;
            this.index++;
            
            
            
        }
        public void DeleteFile()
        {
            if (File.Exists(this.path)) { File.Delete(this.path); }
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            Load();
            DeleteFile();
            for (int i = 0;i<index;i++)
            {
                if (Workers[i].ID != id)
                {
                    AddFile(Workers[i]);
                }
            }
            
            
        }
        public void PrintHead()
        {
            if (!String.IsNullOrEmpty(titles[0]))
            {
                Console.WriteLine($"{titles[0],-3}{titles[1],-25}{titles[2],-15}{titles[3],-10}" +
                    $"{titles[4],-5}{titles[5],-15}{titles[6],-15}");
            }
        }
        public void PrintDBToConsole()
        {
            if (Workers[0].ID > 0)
            {
                PrintHead();
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine(Workers[i].Print());
                }
                //SaveToFile();
            } else
            {
                Console.WriteLine("Не найдено ни одного сотрудника!");
            }
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            //Load();
            // фильтрация нужных записей
            Worker[] reqWRK = new Worker[Workers.Length];
            int i = 0;
            foreach(Worker w in Workers)
            {
                if (w.BirthDate >= dateFrom && w.BirthDate <= dateTo)
                {
                    reqWRK[i] = w;
                    i++;
                }
            }

            // и возврат массива считанных экземпляров

            return reqWRK;

        }
        
    }
}


