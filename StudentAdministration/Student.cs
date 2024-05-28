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
        private double _averageGrade; 

        public Student(string name, int age, string program, int id, List<int> subjects, List<int> grades)
        {
            _name = name;
            _age = age;
            _program = program;
            Id = id;
            _studentSubjects = subjects;
            _studentGrades = grades;
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

        public void GetSubjects(List<Subject> allSubjects, AdminSystem system, Student selectedStudent)
        {
            foreach (var subject in allSubjects.Where(subject => _studentSubjects.Contains(subject.Code)))
            {
                subject.PrintSubjectInfo();
            }
            Console.WriteLine("Do you want to see this students grades in any subjects?");
            system.HandleInput2(system, selectedStudent);
        }


        public double GetAverage()
        {
            int sum = 0;
            foreach (int grade in _studentGrades)
            {
                sum += grade;
            }

            double average = sum / _studentGrades.Count;
            return average;
        }

        public string GetName()  
        {
            return _name;
        }

        public void PrintInfo(List<Grade> allGrades, Student selectedStudent, AdminSystem system)
        {
            Console.WriteLine();
            Console.WriteLine($"Student:\n" +
                              $"Name: {_name} \n" +
                              $"Age: {_age} \n" +
                              $"Program: {_program} \n" +
                              $"Id: {Id} \n" +
                              $"Average Grade: {_averageGrade} \n" +
                              $"\n");
            Console.WriteLine($"Do you want to see {GetName()}s subjects?");
            system.HandleInput1(system, selectedStudent);
        }

        

        public void SubjectSelect(List<Subject> allSubjects, AdminSystem system, Student selectedStudent)
        {
            Console.WriteLine("Please select a subject you want to view:");
            for (int i = 0; i < _studentSubjects.Count; i++)
            {
                string sub =
                    allSubjects.Where(subject => subject.Code == _studentSubjects[i]).FirstOrDefault().Name;
                Console.WriteLine($"{i + 1}. {sub}");
            }

            system.HandleInput3(system, selectedStudent);
        }

    }
}


