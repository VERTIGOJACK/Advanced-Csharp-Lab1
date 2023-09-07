using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.Classes.Employee.Programmer;
using Advanced_Csharp_Lab1.Enums;
using Advanced_Csharp_Lab1.Interfaces;

//This namespace contains the DLL class, which helps generate a uid, this class is also static.
using EmployeeUID;

namespace Advanced_Csharp_Lab1.Classes.Employee
{
    //implements icomparable, sorts employees by calculated salary, also implements custom interface, which is a contract that specifies vars and methods concerning name.
    public abstract class Employee : IComparable<Employee> , IPerson
    {
        //props
        protected int PayrollUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //decimal is preferred when calculating currency
        protected decimal BaseSalary { get; set; }
        // enum for 
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        // name method
        public string GetFullName()
        {
            return FirstName+" "+LastName;
        }
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
            result += "their salary is: "+ GetSalary() + "\n";

            return result;
        }

        //compareto implementation
        //compares by salary
        public int CompareTo(Employee other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

        //constructors
        //using the static class imported from dll assign a unique ID on instantiation
        public Employee()
        {
            initVars();
        }

        //all of this information should be known at the time of hiring a new employee
        public Employee(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage)
        {
            initVars();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BaseSalary = Salary;
            this.ProgrammingLanguage.set(ProgrammingLanguage);
        }

        // for upgrading or downgrading mentors and beginners
        protected Employee(Employee employee)
        {
            this.PayrollUID = employee.PayrollUID;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.BaseSalary = employee.BaseSalary;
            this.ProgrammingLanguage = employee.ProgrammingLanguage;
        }

        private void initVars()
        {
            PayrollUID = EmployeeID.getID();
            this.ProgrammingLanguage = new ProgrammingLanguage();
        }

        public ProgrammingLanguage ProgrammingLanguage1
        {
            get => default;
            set
            {
            }
        }
    }
}
