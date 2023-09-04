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
        public void addBeginner(Beginner beginner)
        {
            Beginner fromList = AssignedBeginners.SingleOrDefault(x => x.base.GetId() == beginner.base.GetId());
            AssignedBeginners.Add(beginner);

        }

        /*     public override string getReport()
             {
                 //declare result variable
                 string report;
                 //first the easy part, name and uid
                 report = "Payroll ID: "+base.PayrollUID+"\n";
                 report += "Name: " + base.Name + "\n";


                 return report;
             }

             public override decimal getSalary()
             {
                 throw new NotImplementedException();
             }*/
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

        private void initVars()
        {
            this.AssignedBeginners = new List<Beginner>();
        }

    }
}
