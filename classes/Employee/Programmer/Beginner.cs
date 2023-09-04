using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.Enums;


namespace Advanced_Csharp_Lab1.Classes.Employee.Programmer
{
    public class Beginner : Employee
    {

        //props
        private Mentor AssignedMentor;


        public override decimal GetSalary()
        {
            decimal result = 0;

            decimal languageMultiplier = 0.1m;

            decimal calculatedMultiplier = 0;

            //calculate multiplier for language and add to var
            if (base.ProgrammingLanguage.get() == Specialization.C_Sharp)
            {
                calculatedMultiplier += languageMultiplier;
            }

            //multiply basesalary
            result = calculatedMultiplier * base.BaseSalary;

            return result;
        }


        // constructors
        public Beginner(string FirstName, string LastName) : base(FirstName, LastName)
        {
            initVars();
        }

        public Beginner(string FirstName, string LastName, decimal Salary) : base(FirstName, LastName, Salary)
        {
            initVars();
        }

        public Beginner(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage) : base(FirstName, LastName, Salary, ProgrammingLanguage)
        {
            initVars();
        }

        private void initVars()
        {
            //nothing here this time
        }


    }
}
