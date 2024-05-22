using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Student
    {
        private string _name;
        private int _age;
        private string _program;
        public int Id { get; private set; }

        private List<int> _studentSubjects;
        private List<int> _studentGrades;

        public Student(string name, int age, string program, int id, List<int> subjects)
        {
            _name = name; 
            _age = age;
            _program = program;
            Id = id;
            _studentSubjects = subjects;
        }

        public void AddSubject(int subjectCode)
        {
            _studentSubjects.Add(subjectCode);
        }

        public void RemoveSubject(int subjectCode)
        {
            _studentSubjects.Remove(subjectCode);
        }


        public void GetSubjectNames(List<Subject> allSubjects)
        {
            foreach (var subject in allSubjects.Where(subject => _studentSubjects.Contains(subject.Code)))
            {
                Console.WriteLine(subject.Name);
                
            }
        }

        public string GetName()  // dette er måten man gjør det på om name er private. 
        {
            return _name;
        }

        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"Student:\n" +
                              $"Name: {_name} \n" +
                              $"Age: {_age} \n" +
                              $"Program: {_program} \n" +
                              $"Id: {Id} \n" +
                              $"\n");
        }

        public void HandleInputFirst(List<Subject> allSubjects)
        {  
            bool running=true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Currently taking subjects:");
                        GetSubjectNames(allSubjects);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        // needs help
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("You have to pick an option. Please try again.");
                        break;
                }
            }
          
           
        }

        public void HandleInputSecond(List <Subject> SubjectList)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Directing you to the subject select menu");
                        SubjectSelect(SubjectList);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        // needs help
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("You have to pick an option. Please try again.");
                        break;
                }
            }
        }

        public void SubjectSelect(List<Subject> allSubjects)
        {   
            Console.WriteLine("Please select a subject you want to view:");
            for (int i = 0; i < _studentSubjects.Count; i++)
            {
                string sub = 
                    allSubjects.Where(subject => subject.Code == _studentSubjects[i]).FirstOrDefault().Name;
                Console.WriteLine($"{i+1}. {sub}"); 
            }

        }

    }
    //_studentSubjects[i] == allSubjects.Code[i]).Name;
    //var subject in allSubjects.Where(subject => _studentSubjects.Contains(subject.Code)))
}
