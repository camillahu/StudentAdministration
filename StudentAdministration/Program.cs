
using StudentAdministration;

var StudentsList = new List<Student>()
{
    new("Camilla", 23, "Start IT", 1),
    new("Bjarne", 44, "Start IT", 2)
};

var SubjectsList = new List<Subject>()
{
    new(1001, "JavaScript",5),
    new(1002, "C#",8),
    new(1003, "NK", 3)
};

var GradesList = new List<Grade>()
{
    new(StudentsList[0],SubjectsList[0], 4),
    new(StudentsList[0],SubjectsList[1], 3),
    new(StudentsList[0],SubjectsList[2], 5),

    new(StudentsList[1],SubjectsList[0], 6),
    new(StudentsList[1],SubjectsList[1], 6),
    new(StudentsList[1],SubjectsList[2], 6),

};

StudentsList[0].PrintInfo();
SubjectsList[0].PrintInfo();
GradesList[0].PrintInfo();


