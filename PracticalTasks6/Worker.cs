using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks6
{
    public struct Worker
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceBirth { get; set; }
        public string Print()
            {
            string res = String.Empty;
            if (this.ID != 0)
            {
                res= ($"{this.ID,-3}{this.CreationDate,-25}{this.FIO,-15}{this.Age,-10}" +
                    $"{this.Height,-5}{this.BirthDate,-15}{this.PlaceBirth,-15}");
            }
            return res;
        }
        public Worker(int ID, string sFIO, int nAge, int nHeight, DateTime dBirthDate, string sPlaceBirth)
        {
            this.ID = ID;
            this.CreationDate = DateTime.Now;
            this.FIO = sFIO;
            this.Age = nAge;
            this.Height = nHeight;
            this.BirthDate = dBirthDate;
            this.PlaceBirth = sPlaceBirth;


        }
        public Worker(int ID, DateTime dCreate, string sFIO, int nAge, int nHeight, DateTime dBirthDate, string sPlaceBirth)
        {
            this.ID = ID;
            this.CreationDate = dCreate;
            this.FIO = sFIO;
            this.Age = nAge;
            this.Height = nHeight;
            this.BirthDate = dBirthDate;
            this.PlaceBirth = sPlaceBirth;


        }
    }
}
