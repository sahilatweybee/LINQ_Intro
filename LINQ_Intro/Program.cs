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
                Console.WriteLine(item);
            }

            var MethodSyntax = (from obj in integerList
                                where obj > 5
                                select obj).Sum();
            Console.Write("\nSum Is : " + MethodSyntax + "\n\n");

            ///////////////////////Lambda Expression////////////////////////
            var result = integerList.Select(x => x);

            foreach (var item in result)
            {
                Console.Write($"{item}  ");
            }

            int Average = integerList.Aggregate((a, b) => a * b);
            Console.WriteLine($"\n\n{Average}\n");

            //////////////////////Sorting Operators///////////////////////////
            List<Student> Objstudent = new List<Student>()
            {
                new Student() { RoleId=6, Name = "Akshay", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student() { RoleId=7, Name = "Vaishali", Gender = "Female", Subjects = new List<string> { "Computer", "Botany" } },
                new Student() { RoleId=8, Name = "Arpita", Gender = "FMale", Subjects = new List<string> { "Economics", "Operating System", "Java" } },
                new Student() { RoleId=9, Name = "Shubham", Gender = "Male", Subjects = new List<string> { "Account", "Social Studies", "Chemistry" } },
                new Student() { RoleId=10, Name = "Himanshu", Gender = "Male", Subjects = new List<string>{ "English", "Charted" } },
                new Student() { RoleId=1, Name = "Ak", Gender = "Male", Subjects = new List<string> { "Mathematics", "Physics" } },
                new Student() { RoleId=2, Name = "Shalu", Gender = "Female", Subjects = new List<string> { "Computers", "Botany" } },
                new Student() { RoleId=3, Name = "Shubham", Gender = "Male", Subjects = new List<string> { "Economics", "Operating System", "Java" } },
                new Student() { RoleId=4, Name = "Rohit", Gender = "Male", Subjects = new List<string> { "Accounting", "Social Studies", "Chemistry" } },
                new Student() { RoleId=5, Name = "Shivani", Gender = "FeMale", Subjects = new List<string> { "English", "Charterd" } }
            };

            foreach (var item in Objstudent.OrderByDescending(x => x.Name).ThenBy(y => y.RoleId))
            {
                Console.WriteLine($"[{item.RoleId}, {item.Name}, {item.Gender}]");
            }

            /////////////////////////Partition Operators/////////////////////////
            Console.WriteLine("\n");
            foreach (var s in Objstudent.Take(5))
            {
                Console.WriteLine($"{s.RoleId}  {s.Name}\n");
            }

            string[] countries = { "RUSSIA", "CHINA", "ARGENTINA", "INDIA", "JAPAN" };
            IEnumerable<String> result1 = (from x in countries select x).TakeWhile(y => y.StartsWith("C")); // Return Empty list because 1st element doesn't satisfy the condition
            foreach (var country in result1)
            {
                Console.WriteLine(country);
            }

            Console.ReadLine();
        }
    }
}
