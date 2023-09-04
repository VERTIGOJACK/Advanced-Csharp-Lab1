using Advanced_Csharp_Lab1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.classes.Employee.Programmer
{
    public class ProgrammingLanguage
    {

        private Specialization Language;
        public ProgrammingLanguage() { }

        public void set(Specialization language)
        {
            this.Language = language;
        }

        public Specialization get() { 
            return this.Language; 
        }

        public override string ToString()
        {
            string result = "";

            switch (this.Language)
            {
                case Specialization.None:
                    result = "None";
                    break;
                case Specialization.Java:
                    result = "Java";
                    break;
                case Specialization.C_Sharp:
                    result = "C#";
                    break;
                case Specialization.C_PlusPlus:
                    result = "C++";
                    break;

            }
            return result;
        }
    }
}
