using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentAdministration
{
    internal class AdminSystem
    {
        private List<Student> StudentsList { get; set; }
        private List<Subject> SubjectsList { get; set; }
        private List<Grade> GradesList { get; set; }

        public AdminSystem()
        {
             StudentsList = new List<Student>() 
            {
                new("Camilla", 23, "Start IT", 1, [0, 1, 2], [3, 4, 6]),
                new("Bjarne", 44, "Start IT", 2, [0, 1], [6, 6])
            };

             SubjectsList = new List<Subject>()
            {
                new(0, "JavaScript",5),
                new(1, "C#",8),
                new(2, "NK", 3)
            };

            //GradesList = new List<Grade>()
            //{
            //    new(StudentsList[0].Id,SubjectsList[0], 4),
            //    new(StudentsList[0].Id,SubjectsList[1], 3),
            //    new(StudentsList[0].Id,SubjectsList[2], 5),
            //    new(StudentsList[1].Id,SubjectsList[0], 6),
            //    new(StudentsList[1].Id,SubjectsList[1], 6),

            //};
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

            if (input <= 0 || input > StudentsList.Count)
            {
                Console.WriteLine("Student does not exist. Please pick a option from the list:");
                do
                {
                    ShowStudents();
                    input = Convert.ToInt32(Console.ReadLine());
                } while (input < 0 || input > StudentsList.Count);
            }
            return StudentsList[input -1];
        }




        public void MainMenu(AdminSystem system)
        {   
            Console.WriteLine("Welcome to student administration. Please pick a student:");
            ShowStudents();

            Student selectedStudent = SelectStudent();
            selectedStudent.PrintInfo(GradesList, selectedStudent, system);
        }

        public void HandleInput1(AdminSystem system, Student selectedStudent)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Currently taking subjects:");
                            selectedStudent.GetSubjects(SubjectsList, system, selectedStudent);
                        running = false;
                        
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        MainMenu(system);
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

        public void HandleInput2(AdminSystem system, Student selectedStudent)
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
                        selectedStudent.SubjectSelect(SubjectsList, system, selectedStudent);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        MainMenu(system);
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
        public void HandleInput3(AdminSystem system, Student selectedStudent)
        {
            int input = Convert.ToInt32(Console.ReadLine());

            string subjectName = SubjectsList.FirstOrDefault(s => s.Code == input - 1).Name;  //sjekk dette ut

            List<Grade> studentGrades = GradesList.Where(g => g.StudentId == selectedStudent.Id).ToList();

            Console.WriteLine($"Showing {selectedStudent.GetName()}'s grade in {subjectName}:"); 
            Console.WriteLine($"{studentGrades[input - 1].GetGradeValue()}");
            HandleInput4(system, selectedStudent);



            //gjør det samme som den over: 

            //List<Grade> studentGrades = new List<Grade>();

            //foreach (Grade grade in allGrades.Where(g => g.StudentId == Id))
            //{
            //    studentGrades.Add(grade);
            //}

        }
        public void HandleInput4(AdminSystem system, Student selectedStudent)
        {

            Console.WriteLine("What do you want to do now?");
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Go back to subjects menu. \n2. Change student. \n3. Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        selectedStudent.SubjectSelect(SubjectsList, system, selectedStudent); 
                        running = false;
                        break;
                    case 2:
                        MainMenu(system);
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
        //public List<Grade> GetGrades(List<Grade> allGrades)
        //{
        //    List<Grade> studentGrades = new List<Grade>();
        //    foreach (Grade grade in allGrades.Where(g => g.StudentId == Id))
        //    {
        //        studentGrades.Add(grade);
        //    }

        //    return studentGrades;

        //}
    }

}

