using System;
using System.Collections.Generic;
using System.Linq;

struct Student
{
    public string Surname;
    public int Course;
    public int Grade1;
    public int Grade2;

    // Метод, що повертає рядок з значеннями полів
    public override string ToString()
    {
        return $"{Surname}\t{Course}\t{Grade1}\t{Grade2}";
    }
}

class Program
{
    static void Main()
    {
        // Введення даних з клавіатури
        Console.Write("Введіть кількість студентів: ");
        int studentCount = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();

        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine($"Введіть дані для студента {i + 1}:");
            Console.Write("Прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Курс: ");
            int course = int.Parse(Console.ReadLine());
            Console.Write("Оцінка 1: ");
            int grade1 = int.Parse(Console.ReadLine());
            Console.Write("Оцінка 2: ");
            int grade2 = int.Parse(Console.ReadLine());

            students.Add(new Student { Surname = surname, Course = course, Grade1 = grade1, Grade2 = grade2 });
        }

        // Виведення списку студентів на екран
        Console.WriteLine("Список студентів:");
        Console.WriteLine("Прізвище\tКурс\tОцінка1\tОцінка2");
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }

        // Введення курсу для пошуку
        Console.Write("Введіть курс для пошуку: ");
        int searchCourse = int.Parse(Console.ReadLine());

        // Пошук найкращого студента та кількості студентів на курсі
        var studentsOnCourse = students.Where(s => s.Course == searchCourse).ToList();

        if (studentsOnCourse.Count > 0)
        {
            var bestStudent = studentsOnCourse.OrderByDescending(s => s.Grade1 + s.Grade2).First();
            Console.WriteLine($"Найкращий студент на курсі {searchCourse}: {bestStudent.Surname} з сумою оцінок {bestStudent.Grade1 + bestStudent.Grade2}");
            Console.WriteLine($"Кількість студентів на курсі {searchCourse}: {studentsOnCourse.Count}");
        }
        else
        {
            Console.WriteLine($"На курсі {searchCourse} немає студентів.");
        }
    }
}
