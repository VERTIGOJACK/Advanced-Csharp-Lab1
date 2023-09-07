using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.classes.Organization;
using Advanced_Csharp_Lab1.Enums;
using Advanced_Csharp_Lab1.Exceptions;

namespace Advanced_Csharp_Lab1.Classes.Employee.Programmer
{
    public class Mentor : Employee
    {
        //props
        //sortedset because i want to prevent duplicates and allow sorting
        private SortedSet<Beginner> AssignedBeginners;

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
            result = (1+calculatedMultiplier)*base.BaseSalary;

            return result;
        }

        //manage beginners
        public void addBeginner(Beginner beginner)
        {
            try
            {
                if (beginner.ProgrammingLanguage.get() != this.ProgrammingLanguage.get())
                {
                    throw new OrganizationException("Programming language mismatch between Mentor and Beginner");
                }
                AssignedBeginners.Add(beginner);
            }
            catch (OrganizationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public SortedSet<Beginner> changeLanguage(Specialization language)
        {
            this.ProgrammingLanguage.set(language);

            //copy to new
            SortedSet<Beginner> temp = new SortedSet<Beginner>(AssignedBeginners);

            //clear
            AssignedBeginners.Clear();

            //return list of mentees that need to be dealt with
            return temp;
        }

        public void removeBeginner(Beginner beginner)
        {
                AssignedBeginners.Remove(beginner);
        }

        public int countBeginners()
        {
            return AssignedBeginners.Count();
        }

        public static Mentor ToMentor(Beginner beginner)
        {
            beginner.getMentor().removeBeginner(beginner);
            return new Mentor(beginner);
        }

        //tostring
        public override string ToString()
        {
            string result = base.ToString();
            result += base.FirstName + " is a mentor to:\n";
            foreach(var beginner in AssignedBeginners) 
            {
                result += beginner.GetFullName()+"\n"; 
            }         
            return result;
        }


        // constructors
        public Mentor(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage) : base(FirstName, LastName, Salary, ProgrammingLanguage)
        {
            initVars();
        }

        //upgrade downgrade
        private Mentor(Beginner beginner) : base(beginner)
        {
            initVars();
        }

        // QoL
        private void initVars()
        {
            this.AssignedBeginners = new SortedSet<Beginner>();
        }
    }
}
