using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Grade
    {
        public Student Student { get; private set; }
        public Subject Subject { get; private set; }
        public int Value { get; private set; }

        public Grade(Student student, Subject subject, int value)
        {
            Student = student;
            Subject = subject;
            Value = value;
        }

        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"Grade: \n" +
                              $"Student: {Student.Name}\n" +
                              $"Subject: {Subject.Name}\n" +
                              $"Grade value: {Value}");
            Console.WriteLine();
        }
    }
}
