using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeUID;

namespace Advanced_Csharp_Lab1.Classes.Employee
{
    public abstract class Employee
    {
        //props
        protected int PayrollUID { get; set; }
        protected string Name { get; set; }
        protected decimal BaseSalary { get; set; }

        //methods
        public abstract string getReport();
        public abstract decimal getSalary();

        //constructors
        //using the static class imported from dll assign a unique ID on constructed
        public Employee()
        {
            PayrollUID = EmployeeID.getID();
        }
        public Employee(string Name)
        {
            PayrollUID = EmployeeID.getID();
            this.Name = Name;
        }
        public Employee(string Name, decimal BaseSalary)
        {
            PayrollUID = EmployeeID.getID();
            this.Name = Name;
            this.BaseSalary = BaseSalary;
        }
    }
}
