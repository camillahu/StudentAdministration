﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Grade
    {
        public int StudentId { get; private set; }
        public Subject Subject { get; private set; }
        private int Value;

        public Grade(int studentId, Subject subject, int value)
        {
            StudentId = studentId;
            Subject = subject;
            Value = value;
        }

        public int GetGradeValue() 
        { return Value; }

        
        //public void PrintInfo()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine($"Grade: \n" +
        //                      //$"Student: {Student.Name}\n" +
        //                      $"Subject: {Subject.Name}\n" +
        //                      $"Grade value: {Value}");
        //    Console.WriteLine();
        //}
    }
}
