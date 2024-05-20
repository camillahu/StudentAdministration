using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Student
    {
        public string Name { get;  private set; }
        public int Age { get; private set; }
        public string Program { get;  private set; }
        public int Id { get; private set; }

        public List <Subject> Subjects { get; private set; }

        public Student(string name, int age, string program, int id)
        {
            Name = name; 
            Age = age;
            Program = program;
            Id = id;
            Subjects = new List<Subject>();
        }

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }
        public void PrintInfo() 
        {
            Console.WriteLine();
            Console.WriteLine($"Student:\n" +
                                $"Name: {Name} \n" +
                                $"Age: {Age} \n" +
                                $"Program: {Program} \n" +
                                $"Id: {Id}");
            Console.WriteLine();
        }
    }
}
