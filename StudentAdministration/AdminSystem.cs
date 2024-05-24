using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class AdminSystem
    {
        private List<Student> StudentsList { get; set; }
        private List<Subject> SubjectsList { get; set; }
        private List<Grade> GradesList { get; set; }

        public AdminSystem()
        {
             StudentsList = new List<Student>() // siste param er List _studentSubjects
            {
                new("Camilla", 23, "Start IT", 1, [0, 1, 2]),
                new("Bjarne", 44, "Start IT", 2, [0, 1])
            };

             SubjectsList = new List<Subject>()
            {
                new(0, "JavaScript",5),
                new(1, "C#",8),
                new(2, "NK", 3)
            };

            GradesList = new List<Grade>()
            {
                new(StudentsList[0].Id,SubjectsList[0], 4),
                new(StudentsList[0].Id,SubjectsList[1], 3),
                new(StudentsList[0].Id,SubjectsList[2], 5),
                new(StudentsList[1].Id,SubjectsList[0], 6),
                new(StudentsList[1].Id,SubjectsList[1], 6),

            };
        }
        
        public void ShowStudents()
        {
            for (var i = 0; i < StudentsList.Count; i++)
            {
                Console.WriteLine($" {i +1}. {StudentsList[i].GetName()}");
            }
        }

        Student SelectStudent()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (input < 0 || input > StudentsList.Count)
            {
                Console.WriteLine("Student does not exist. By default the first student will show.");
                input = 0;
            }
            return StudentsList[input -1];
        }


        public void MainMenu()
        {   
            Console.WriteLine("Welcome to student administration. Please pick a student:");
            ShowStudents();

            Student selectedStudent = SelectStudent();
            selectedStudent.PrintInfo();
            Console.WriteLine($"Do you want to see {selectedStudent.GetName()}s subjects?");
            selectedStudent.HandleInput1(SubjectsList);
            Console.WriteLine("Do you want to see this students grades in any subjects?");
            selectedStudent.HandleInput2(SubjectsList);
            selectedStudent.HandleInput3(GradesList, SubjectsList);
            selectedStudent.HandleInput4(SubjectsList);


        }
    }

    
}
