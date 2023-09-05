using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.Enums;


namespace Advanced_Csharp_Lab1.Classes.Employee.Programmer
{
    public class Mentor : Employee
    {
        //props
        private List<Beginner> AssignedBeginners;

        //salary
        public override decimal GetSalary()
        {
            decimal result = 0;

            decimal languageMultiplier = 0.1m;
            decimal beginnersMultiplier = 0.05m;

            decimal calculatedMultiplier = 0;

            //calculate multiplier for language and add to var
            if(base.ProgrammingLanguage.get() == Specialization.C_Sharp)
            {
                calculatedMultiplier += languageMultiplier;
            }

            //calculate multiplier for mentees and add to var
            calculatedMultiplier += beginnersMultiplier * AssignedBeginners.Count();

            //multiply basesalary
            result = calculatedMultiplier*base.BaseSalary;

            return result;
        }

        //manage beginners
        public void addBeginner(Beginner beginner)
        {
            if(AssignedBeginners.Contains(beginner) == false && 
               beginner.ProgrammingLanguage.get() == this.ProgrammingLanguage.get())
            {
                AssignedBeginners.Add(beginner);
            } 
        }

        public void removeBeginner(Beginner beginner)
        {
            if (AssignedBeginners.Contains(beginner) == true)
            {
                AssignedBeginners.Remove(beginner);
            }
        }

        public override string ToString()
        {
            string result = base.ToString();
            result += base.FirstName + " is a mentor to: ";
            foreach(var beginner in AssignedBeginners) 
            {
                result += beginner.getFullName()+"\n"; 
            }


        }

        // constructors
        public Mentor(string FirstName, string LastName) : base(FirstName, LastName)
        {
            initVars();
        }

        public Mentor(string FirstName, string LastName, decimal Salary) : base(FirstName, LastName, Salary)
        {
            initVars();
        }

        public Mentor(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage) : base(FirstName, LastName, Salary, ProgrammingLanguage)
        {
            initVars();
        }

        private Mentor(Beginner beginner) : base(beginner)
        {
            initVars();
        }

        private void initVars()
        {
            this.AssignedBeginners = new List<Beginner>();
        }

    }
}
