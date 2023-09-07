using Advanced_Csharp_Lab1.Classes.Employee;
using Advanced_Csharp_Lab1.Classes.Employee.Programmer;
using Advanced_Csharp_Lab1.Enums;
using Advanced_Csharp_Lab1.Exceptions;
using EmployeeUID;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.classes.Organization
{
    public delegate void SalaryCallback(decimal total);
    public class Organization
    {

        public string Name { get; set;}

        // using sorted dictionary makes sense when every employee has a unique id, benefits us with fast access through id and sorting
        public SortedDictionary<int,Mentor> Mentors { get; set;}
        public SortedDictionary<int, Beginner> Beginners { get; set; }

        public Mentor Mentor
        {
            get => default;
            set
            {
            }
        }

        public Beginner Beginner
        {
            get => default;
            set
            {
            }
        }

        //get total
        public decimal GetSalaryBillTotal()
        {
            decimal result = 0;

            foreach (var item in Mentors)
            {
                result += item.Value.GetSalary();
            }

            foreach (var item in Beginners)
            {
                result += item.Value.GetSalary();
            }

            return result;
        }

        //get total
        public void GetSalaryBillTotal(SalaryCallback callback)
        {
            decimal result = 0;

            foreach (var item in Mentors)
            {
                result += item.Value.GetSalary();
            }

            foreach (var item in Beginners)
            {
                result += item.Value.GetSalary();
            }

            callback(result);
        }

        //demonstration of icomparable
        public string ShowEmployeesByLastName()
        {
            string result = string.Empty;

            //cast each value of dict to employee, return as list of employee.
            List<Employee> list1 = Mentors.Values.Select(x => (Employee)x).ToList();
            List<Employee> list2 = Beginners.Values.Select(x => (Employee)x).ToList();

            //concat the two lists
            List<Employee> merged = list1.Concat(list2).ToList();

            //sort the list (using icomparable)
            merged.Sort();

            result = "Employees sorted by last name:\n";
            foreach (Employee emp in merged)
            {
                result += $"{emp.GetFullName()}\n";
            }

            return result;
        }

        public override string ToString()
        {
            string result = string.Empty;

            result += $"Organisation name: {this.Name}\n\n";

            result += $"Mentors:\n";
            foreach (var item in Mentors)
            {
                result += item;
                result += "\n\n";
            }

            result += $"Beginners:\n";
            foreach (var item in Beginners)
            {
                result += item;
                result += "\n\n";
            }

            return result;
        }

        //manage mentors
        public int NewMentor(string FirstName, string LastName,decimal Salary, Specialization Language)
        {
            Mentor mentor = new Mentor(FirstName,LastName,Salary,Language);
            

            //returns payroll id of newly created object
            try
            {
                int result = mentor.GetId();

                if (result < 0 && result > int.MinValue)
                {
                    throw new OrganizationException("integer overflow, contact your admin");
                }

                Mentors.Add(result, mentor);
                return result;            
            }
            catch (OrganizationException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public void RemoveMentor(Mentor mentor)
        {
            Mentors.Remove(mentor.GetId());
        }

        //TODO: downgrade, upgrade, put in appropriate list

        //manage beginners
        public int NewBeginner(string FirstName, string LastName, decimal Salary, Specialization Language)
        {
            Beginner beginner = new Beginner(FirstName, LastName, Salary, Language);
           
            //returns payroll id of newly created object
            try
            {
                int result = beginner.GetId();

                if (result < 0 && result > int.MinValue)
                {
                    throw new OrganizationException("integer overflow, contact your admin");
                }

                AssignBeginner(beginner);

                Beginners.Add(result, beginner);
                return result;
            }
            catch (OrganizationException ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public void RemoveBeginner(Beginner beginner)
        {           
            Beginners.Remove(beginner.GetId());        
        }

        public void UpgradeBeginner(int id)
        {
            Beginner beginner = this.Beginners[id];
            RemoveBeginner(beginner);
            Mentor mentor = Mentor.ToMentor(beginner);
            Mentors.Add(mentor.GetId(),mentor);
        }

        public void AssignBeginner(Beginner beginner)
        {
            //check for available mentors with LINQ
            List<Mentor> list = this.Mentors.Values.Where(mentor => mentor.ProgrammingLanguage.get() == beginner.ProgrammingLanguage.get()).ToList();

            //rudimentary load balancing, orderby is in ascending order, assign to person with least beginners
            if (list.Count >= 1)
            {
                Mentor mentor = list.OrderBy(mentor => mentor.countBeginners()).First();

                //update the two object
                beginner.AssignMentor(mentor);
                mentor.addBeginner(beginner);
            }

        }

        public void languageUpdate(Mentor mentor,Specialization language)
        {
            var beginners = mentor.changeLanguage(language);

            //reassign beginners under this mentor
            foreach (var item in beginners)
            {
                this.AssignBeginner(item);
            }
        }



    public Organization()
        {
            Mentors = new SortedDictionary<int,Mentor>();
            Beginners = new SortedDictionary<int, Beginner>();
        }
    }
}
