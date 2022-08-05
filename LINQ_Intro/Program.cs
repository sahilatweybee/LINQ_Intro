using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Intro
{
    class Student
    {
        public int RoleId;
        public String Name;
        public String Gender;
         public List<String> Subjects;
    }

    class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
            ///////////////////////Syntax///////////////////////////////////
            var ModifiedArray = (from obj in integerList
                                 where obj > 5
                                 select obj).ToArray();
            foreach (var item in ModifiedArray)
            {
                Console.WriteLine("\t\t" + item);
            }

            var MethodSyntax = (from obj in integerList
                                where obj > 5
                                select obj).Sum();
            Console.Write("\nSum Is : \n\t\t" + MethodSyntax + "\n");

            ///////////////////////Lambda Expression////////////////////////
            var result = integerList.Select(x => x);
            Console.WriteLine("\nLambda: ");
            foreach (var item in result)
            {
                Console.WriteLine($"\t\t{item}  ");
            }

            int Average = integerList.Aggregate((a, b) => a * b);
            Console.WriteLine($"\nAggregate:\n\t\t{Average}\n");

            //////////////////////Sorting Operators///////////////////////////
            List<Student> Objstudent = new List<Student>()
            {
                new Student() { RoleId=1, Name = "Akshay", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student() { RoleId=2, Name = "Shalu", Gender = "Female", Subjects = new List<string> { "Computers", "Botany" } },
                new Student() { RoleId=3, Name = "Shubham", Gender = "Male", Subjects = new List<string> { "Economics", "Operating System", "Java" } },
                new Student() { RoleId=4, Name = "Rohit", Gender = "Male", Subjects = new List<string> { "Accounting", "Social Studies", "Chemistry" } },
                new Student() { RoleId=5, Name = "Shivani", Gender = "FeMale", Subjects = new List<string> { "English", "Charterd" } },
                new Student() { RoleId=6, Name = "Ak", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student() { RoleId=7, Name = "Vaishali", Gender = "Female", Subjects = new List<string> { "Computer", "Botany" } },
                new Student() { RoleId=8, Name = "Arpita", Gender = "FeMale", Subjects = new List<string> { "Economics", "Operating System", "Java" } },
                new Student() { RoleId=9, Name = "Shubham", Gender = "Male", Subjects = new List<string> { "Account", "Social Studies", "Chemistry" } },
                new Student() { RoleId=10, Name = "Himanshu", Gender = "Male", Subjects = new List<string>{ "English", "Charted" } }
            };
            Console.WriteLine("\nThenBy: ");
            foreach (var item in Objstudent.OrderByDescending(x => x.Name).ThenBy(y => y.RoleId))
            {
                Console.WriteLine($"\t\t[{item.RoleId}, {item.Name}, {item.Gender}]");
            }

            /////////////////////////Partition Operators/////////////////////////
            Console.WriteLine("\nTake: ");
            foreach (var s in Objstudent.Take(5))
            {
                Console.WriteLine($"\t\t{s.RoleId}  {s.Name}");
            }
            Console.WriteLine("\n");
            string[] countries = { "RUSSIA", "CHINA", "ARGENTINA", "INDIA", "JAPAN" };
            //IEnumerable<String> result1 = (from x in countries select x).TakeWhile(y => y.StartsWith("C")); // Return Empty list because 1st element doesn't satisfy the condition
            //foreach (var country in result1)
            //{
            //    Console.WriteLine(country);
            //}
            Console.WriteLine("\n");
            IEnumerable<String> result2 = (from x in countries select x).Skip(2);
            foreach (var country in result2)
            {
                Console.WriteLine("\t\t" + country);
            }
            Console.WriteLine("\n");
            IEnumerable<String> result3 = (from x in countries select x).SkipWhile(y => y.StartsWith("C")); // Doesn't skip anything because 1st element doesn't satisfy the condition
            foreach (var country in result3)
            {
                Console.WriteLine("\t\t" + country);
            }

            /////////////////////////Conversion Operators/////////////////////////
            Console.WriteLine("\nToList:\n\t\t" + result3.ToList());
            Console.WriteLine("ToArry: \n\t\t" + result2.ToArray());
            Console.WriteLine("Cast: \n\t\t" + integerList.Cast<String>());

            List<Employee> objEmployee = new List<Employee>()
            {
                new Employee(){ Name="Akshay Tyagi", Department="IT", Country="India"},
                new Employee(){ Name="Vaishali Tyagi", Department="Marketing", Country="UK"},
                new Employee(){ Name="Arpita Rai", Department="HR", Country="China"},
                new Employee(){ Name="Shubham Ratogi", Department="Sales", Country="USA"},
                new Employee(){ Name="Himanshu Tyagi", Department="Operations", Country="Canada"}
            };
            //objEmployee.ToLookup() method is used to print the value of the data in the pair/collection of items.  
            var Emp = objEmployee.ToLookup(x => x.Country);
            Console.WriteLine("\n-------ToLookup: ");
            foreach (var Pair in Emp)
            {
                Console.Write("\t\t" + Pair.Key + ":");

                foreach (var item in Emp[Pair.Key])
                {
                    Console.WriteLine("\t" + item.Name + " " + item.Department);
                }
            }

            ArrayList arr = new ArrayList
            {
                "abc",
                'x',
                12,
                123.456f,
                "xyz",
                'a',
                56,
                789.0456
            };
            Console.WriteLine("\n-------OfType: ");
            foreach (var item in arr.OfType<String>())
            {
                Console.WriteLine("\t\t" + item);
            }

            Console.WriteLine("\nAsEnumerable: " + ModifiedArray.AsEnumerable());

            Console.WriteLine("\nToDictionary: ");
            foreach (var item in Objstudent.ToDictionary(st => st.RoleId, st => st.Name).OrderByDescending(x => x.Key))
            {
                Console.WriteLine("\t\t" + item);
            }
            
            /////////////////////////E#lement Operators/////////////////////////
            List<int> lst = new List<int>();
            Console.WriteLine("\nFirst:\n\t\t" + Objstudent.First().Name);
            Console.WriteLine("FirstOrDefault:\n\t\t" + lst.FirstOrDefault());
            Console.WriteLine("Last:\n\t\t" + Objstudent.Last().Name);
            Console.WriteLine("LastOrDefault: \n\t\t" + lst.LastOrDefault());
            Console.WriteLine("ElementAt: \n\t\t" + Objstudent.ElementAt(3).Name);
            Console.WriteLine("ElementAtOrDefault: \n\t\t" + lst.ElementAtOrDefault(3));
            //Console.WriteLine("Single: \n\t\t" + Objstudent.Single().Name); // throws Exception because list contain more than 1 objects
            lst.Add(56);
            Console.WriteLine("SingleOrDeFault: \n\t\t" + lst.SingleOrDefault());
            var nullName = Objstudent.DefaultIfEmpty();
            Console.WriteLine("\nDefaultEmpty: ");
            foreach (var item in nullName)
            {
                Console.WriteLine($"\t\t{item.RoleId}, {item.Name}, {item.Gender}");
            }


            Console.ReadLine();
        }
    }
}
