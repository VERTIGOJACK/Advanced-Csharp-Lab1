using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Csharp_Lab1.classes
{
    public static class OldDocumentReader
    {
        internal class Department
        {
            public string name;
            public List<OldEmployee> Employees = new List<OldEmployee>();
            public override string ToString()
            {

                string result = string.Empty;
                result += name + ": ";

                string employeeString = string.Join(", ", Employees);
                result += employeeString;

                return result;
            }
        }

        internal class OldEmployee : IComparable<OldEmployee>
        {
            public string department;
            public string firstName;
            public string lastName;

            public int CompareTo(OldEmployee obj)
            {
                //first compare lastname
                int result = this.lastName.CompareTo(obj.lastName);
                if (result != 0)
                {
                    return result;
                }
                //if same lastname, sort by firstname
                else
                {
                    result = this.firstName.CompareTo(obj.firstName);
                    return result;
                }

            }

            public override string ToString()
            {
                return firstName + " " + lastName;
            }
        }

        internal static SortedDictionary<string, Department> AssembleFromDocumentArray(string[] document)
        {
            SortedDictionary<string, Department> departments = new SortedDictionary<string, Department>();

            foreach (var line in document)
            {
                OldEmployee employee = new OldEmployee();
                //split by |
                string[] array = line.Split("|");

                //handle name, first trim whitespace
                string name = array[0].Trim();
                string[] nameArray = name.Split(" ");

                //assign to obj and format
                employee.firstName = Capitalize(nameArray[0]);
                employee.lastName = Capitalize(nameArray[1]);

                // handle department, first trim whitespace
                string department = array[1].Trim();
                //then format
                department = Capitalize(department);

                // check if key exists in dict
                bool exists = departments.ContainsKey(department);

                if (exists)
                {
                    //add employee to department
                    departments[department].Employees.Add(employee);
                }
                else
                {
                    departments[department] = new Department();
                    departments[department].name = department;
                    //add employee to department
                    departments[department].Employees.Add(employee);
                }
            }
            return departments;
        }

        internal static string Capitalize(string inputString)
        {
            return char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }

        public static void PrintfromDocument(string filename)
        {

            //navigate to documents folder
            string root = Directory.GetCurrentDirectory();
            root = Directory.GetParent(root).FullName;
            root = Directory.GetParent(root).FullName;
            root = Directory.GetParent(root).FullName;

            string path = Path.Combine(root, "Documents");
            path = Path.Combine(path, filename);

            if (File.Exists(path))
            {
                //first read all the text from the file
                string stringContent = File.ReadAllText(path);

                //separate into lines
                string[] lines = stringContent.Split(Environment.NewLine);

                SortedDictionary<string, Department> departmentsDict = AssembleFromDocumentArray(lines);



                foreach (var item in departmentsDict.Values)
                {
                    item.Employees.Sort();
                    Console.WriteLine(item.ToString());
                }

            }
            else
            {
                Console.WriteLine("No file found matching filename in documents directory");
            }
        }
    }
}
