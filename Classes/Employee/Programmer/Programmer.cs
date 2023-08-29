using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Advanced_Csharp_Lab1.Classes.Employee.Programmer
{
    public class Programmer : Employee
    {
        // constructors
        public Programmer(string Name) : base(Name) 
        { 
            
        }

        public Programmer(string Name, decimal Salary) : base(Name,Salary)
        {

        }

        public Programmer(string Name, decimal Salary, bool Inexperienced) : base(Name, Salary)
        {
            this.Inexperienced = Inexperienced;
        }

        private int SpecializationID;

        private int AssignedMentorID;

        private bool Inexperienced = true;

        public void ToggleInxperienced()
        {
            this.Inexperienced = !this.Inexperienced;
        }

        public override string getReport()
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
        }


    }
}
