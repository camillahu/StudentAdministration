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
        private List<Grade> _studentGrades;
        private int _averageGrade; 

        public Student(string name, int age, string program, int id, List<int> subjects)
        {
            _name = name;
            _age = age;
            _program = program;
            Id = id;
            _studentSubjects = subjects;
            _averageGrade = GetAverage();
        }

        //private void AddSubject(int subjectCode)
        //{
        //    _studentSubjects.Add(subjectCode);
        //}

        //private void RemoveSubject(int subjectCode)
        //{
        //    _studentSubjects.Remove(subjectCode);
        //}


        private void GetSubjects(List<Subject> allSubjects)
        {
            foreach (var subject in allSubjects.Where(subject => _studentSubjects.Contains(subject.Code)))
            {

                subject.PrintSubjectInfo();

            }
        }

        public void GetGrades(List<Grade> allGrades)
        {   
            foreach (Grade grade in allGrades.Where(g => g.StudentId == Id))
            {
                _studentGrades.Add(grade);
            }

        }
        public double GetAverage()
        {
            int sum = 0;
            GetGrades()= 

            double average = GetGrades(allGrades)/allGrades.Count;
            return average;
        }

        public string GetName() // dette er måten man gjør det på om name er private. 
        {
            return _name;
        }

        public void PrintInfo(List<Grade> allGrades)
        {
            GetGrades(allGrades);
            Console.WriteLine();
            Console.WriteLine($"Student:\n" +
                              $"Name: {_name} \n" +
                              $"Age: {_age} \n" +
                              $"Program: {_program} \n" +
                              $"Id: {Id} \n" +
                              $"Id: {_averageGrade} \n" +
                              $"\n");
        }

        public void HandleInput1(List<Subject> allSubjects)
        {
            AdminSystem system = new AdminSystem();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Currently taking subjects:");
                        GetSubjects(allSubjects);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        system.MainMenu();
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

        public void HandleInput2(List<Subject> SubjectList)
        {
            AdminSystem system = new AdminSystem();
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
                        system.MainMenu();
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(2);
                        break;
                    default:
                        Console.WriteLine("You have to pick an option. Please try again.");
                        break;
                }
            }
        }

        private void SubjectSelect(List<Subject> allSubjects)
        {
            Console.WriteLine("Please select a subject you want to view:");
            for (int i = 0; i < _studentSubjects.Count; i++)
            {
                string sub =
                    allSubjects.Where(subject => subject.Code == _studentSubjects[i]).FirstOrDefault().Name;
                Console.WriteLine($"{i + 1}. {sub}");
            }


        }

        public void HandleInput3(List<Grade> allGrades, List<Subject> allSubjects)
        {
            int input = Convert.ToInt32(Console.ReadLine());

            string subjectName = allSubjects.Where(s => s.Code == input - 1).FirstOrDefault().Name;

            List<Grade> studentGrades = allGrades.Where(g => g.StudentId == Id).ToList();

            Console.WriteLine($"Showing {_name}'s grade in {subjectName}:"); //er denne fool proof?
            Console.WriteLine($"{studentGrades[input - 1].GetGradeValue()}");



            //gjør det samme som den over: 

            //List<Grade> studentGrades = new List<Grade>();

            //foreach (Grade grade in allGrades.Where(g => g.StudentId == Id))
            //{
            //    studentGrades.Add(grade);
            //}

        }

        public void HandleInput4(List<Subject> allSubjects)
        {
            AdminSystem system = new AdminSystem();

            Console.WriteLine("What do you want to do now?");
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Go back to subjects menu. \n2. Change student. \n3. Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        SubjectSelect(allSubjects); //bug? 
                        running = false;
                        break;
                    case 2:
                        system.MainMenu();
                        running = false;
                        break;
                    case 3:
                        Environment.Exit(3);
                        break;
                    default:
                        Console.WriteLine("You have to pick a valid option.");
                        break;
                }
            }
        }


        

    }
}


