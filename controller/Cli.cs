using dotnet_menu_app.models;
using dotnet_menu_app.repository.impl;

namespace dotnet_menu_app.controller;

public class Cli
{
    public static void Run()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }
     private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Main Menu App");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Create Student");
        Console.WriteLine("2) Update Student");
        Console.WriteLine("3) Get All Student");
        Console.WriteLine("4) Delete Student");
        Console.WriteLine("5) Exit");
        Console.Write("\r\nSelect an Option: ");

        switch (Console.ReadLine())
        {
            case "1":
                CreateStudent();
                break;
            case "2":
                UpdateStudent();
                break;
            case "3":
                GetAllStudent();
                break;
            case "4":
                DeleteStudent();
                break;
            default:
                return false;
        }

        return true;
    }

    private static void CreateStudent()
    {
        Console.Clear();
        Console.WriteLine("Create Student");
        Console.Write("Input student name: ");
        string? name = Console.ReadLine();
        Console.Write("Input student address: ");
        string? address = Console.ReadLine();
        Console.Write("Input student country: ");
        string? country = Console.ReadLine();
        var student = new Student();
        student.Name = name;
        student.Address = address;
        student.Country = country;
        var studentService = new StudentInterfaceImpl();
        studentService.Create(student);
    }
    
    private static void UpdateStudent()
    {
        Console.Clear();
        Console.WriteLine("Update Student");
        Console.Write("Find student by Id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var studentService = new StudentInterfaceImpl();
        Student student = studentService.GetById(id);
        if (student != null)
        {
            Console.WriteLine($"{student.StudentId} {student.Name} {student.Address} {student.Country}");
            Console.Write("Input student name: ");
            string? name = Console.ReadLine();
            Console.Write("Input student address: ");
            string? address = Console.ReadLine();
            Console.Write("Input student country: ");
            string? country = Console.ReadLine();
            student.StudentId = student.StudentId;
            student.Name = name;
            student.Address = address;
            student.Country = country;
            studentService.Update(student);
        }
        else
        { 
            Console.WriteLine($"Student id with ID {id} not found!"); 
        }
        Console.ReadKey();
    }

    private static void GetAllStudent()
    {
        Console.WriteLine("List All Student");
        Console.WriteLine("----------------------");
        var studentService = new StudentInterfaceImpl();
        var students = studentService.List();
        foreach (var student in students)
        {
            Console.WriteLine($"{student.StudentId} - {student.Name} - {student.Address} - {student.Country}");
        }

        Console.ReadKey();
    }

    private static void DeleteStudent()
    {
        Console.Clear();
        Console.WriteLine("Delete Student");
        Console.Write("Find student by Id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var studentService = new StudentInterfaceImpl();
        var student = studentService.GetById(id);
        if (student != null)
        {
            Console.WriteLine("Deleted student success");
            studentService.Delete(student.StudentId);
        }
        else
        {
            Console.WriteLine($"Student id with ID {id} not found!");
        }
        Console.ReadKey();
    }
}