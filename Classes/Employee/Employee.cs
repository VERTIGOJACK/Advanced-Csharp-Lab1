using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.classes.Employee.Programmer;
using Advanced_Csharp_Lab1.Enums;

//This namespace contains the DLL class, which helps generate a uid, this class is also static.
using EmployeeUID;

namespace Advanced_Csharp_Lab1.Classes.Employee
{
    public abstract class Employee
    {
        //props
        protected int PayrollUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //decimal is preferred when calculating currency
        protected decimal BaseSalary { get; set; }
        // enum for 
        public ProgrammingLanguage ProgrammingLanguage { get; set; }

        //id methods
        public int GetId()
        {
            return this.PayrollUID;
        }
        //should only be used when up or downgrading employee
        protected void SetId(int id)
        {
            this.PayrollUID = id;
        }
        //salary methods
        public abstract decimal GetSalary();
        public void SetSalary(decimal Salary)
        {
            this.BaseSalary = Salary;
        }

        //tostring
        public override string ToString()
        {
            string result = "";

            result += "ID: " + this.PayrollUID + "\n";
            result += "Name: " + this.FirstName + " " + this.LastName + "\n";
            result += "Programming language specialization: " + ProgrammingLanguage + "\n";

            return result;
        }

        //constructors
        //using the static class imported from dll assign a unique ID on instantiation
        public Employee()
        {
            PayrollUID = EmployeeID.getID();
            ProgrammingLanguage = new ProgrammingLanguage();
        }

        public Employee(string FirstName, string LastName)
        {
            PayrollUID = EmployeeID.getID();
            ProgrammingLanguage = new ProgrammingLanguage();
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public Employee(string FirstName, string LastName, decimal BaseSalary)
        {
            PayrollUID = EmployeeID.getID();
            ProgrammingLanguage = new ProgrammingLanguage();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BaseSalary = BaseSalary;
        }
        public Employee(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage)
        {
            PayrollUID = EmployeeID.getID();
            this.ProgrammingLanguage = new ProgrammingLanguage();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BaseSalary = Salary;
            this.ProgrammingLanguage.set(ProgrammingLanguage);
        }
    }
}
