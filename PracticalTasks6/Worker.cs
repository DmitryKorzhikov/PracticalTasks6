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
        public DateTime DateTime { get; set; }
        public string sFIO { get; set; }
        public int nAge { get; set; }
        public int nHeight { get; set; }
        public DateTime dBirthDate { get; set; }
        public string sPlaceBirth { get; set; }
        public string Print()
            {
            string res = String.Empty;
            if (this.ID != 0)
            {
                res= ($"{this.ID,-3}{this.DateTime,-25}{this.sFIO,-15}{this.nAge,-10}{this.nHeight,-5}{this.dBirthDate,-15}{this.sPlaceBirth,-15}");
            }
            return res;
        }
        public Worker(int ID, string sFIO, int nAge, int nHeight, DateTime dBirthDate, string sPlaceBirth)
        {
            this.ID = ID;
            this.DateTime = DateTime.Now;
            this.sFIO = sFIO;
            this.nAge = nAge;
            this.nHeight = nHeight;
            this.dBirthDate = dBirthDate;
            this.sPlaceBirth = sPlaceBirth;


        }
        public Worker(int ID, DateTime dCreate, string sFIO, int nAge, int nHeight, DateTime dBirthDate, string sPlaceBirth)
        {
            this.ID = ID;
            this.DateTime = dCreate;
            this.sFIO = sFIO;
            this.nAge = nAge;
            this.nHeight = nHeight;
            this.dBirthDate = dBirthDate;
            this.sPlaceBirth = sPlaceBirth;


        }
    }
}
