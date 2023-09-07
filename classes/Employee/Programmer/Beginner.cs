using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Csharp_Lab1.Enums;
using Advanced_Csharp_Lab1.Exceptions;

namespace Advanced_Csharp_Lab1.Classes.Employee.Programmer
{
    public class Beginner : Employee
    {

       
        //props
        private Mentor AssignedMentor;

        public void AssignMentor(Mentor mentor)
        {
            try
            {
                if (mentor.ProgrammingLanguage.get() != this.ProgrammingLanguage.get())
                {
                    throw new OrganizationException("Programming language mismatch between Mentor and Beginner");
                }
                this.AssignedMentor = mentor;
            }
            catch(OrganizationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public Mentor getMentor()
        {
            return this.AssignedMentor;
        }

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
            result = (1+calculatedMultiplier) * base.BaseSalary;

            return result;
        }

        public override string ToString()
        {
            string result = base.ToString();
            
            result += "\n";
            result += base.FirstName + " ";

            if (AssignedMentor != null)
            {
                result += "is mentored by: "+ AssignedMentor.GetFullName();
            }
            else
            {
                result += "Has no mentor assigned ";
            }
            return result;
        }

        // constructors

        public Beginner(string FirstName, string LastName, decimal Salary, Specialization ProgrammingLanguage) : base(FirstName, LastName, Salary, ProgrammingLanguage)
        {
            initVars();
        }

        private Beginner(Employee employee):base(employee)
        {
            initVars();
        }

        private void initVars()
        {
            //nothing here this time
        }
    }
}
