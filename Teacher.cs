using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace End_Phase1_Project
{
    public class Teacher
    {
        public int id;
        public string name;
        public int ClassNum;
        public string section;

        public Teacher(int id, string name, int ClassNum, string section)
        {
            this.id = id;
            this.name = name;
            this.ClassNum = ClassNum;
            this.section = section;
        }
    }
}
