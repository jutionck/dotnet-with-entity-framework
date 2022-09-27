using dotnet_menu_app.config;
using dotnet_menu_app.models;

namespace dotnet_menu_app.repository.impl;

public class StudentInterfaceImpl: StudentInterface
{
    public StudentInterfaceImpl() {}
    public void Create(Student student)
    {
        using (var context = new Config())
        {
            var std = new Student()
            {
                Name = student.Name,
                Address = student.Address,
                Country = student.Country
            };
            context.Students.Add(std);
            context.SaveChanges();
        }
    }

    public void Update(Student student)
    {
        using (var context = new Config())
        {
            var std = new Student();
            std.StudentId = student.StudentId;
            std.Name = student.Name;
            std.Address = student.Address;
            std.Country = student.Country;
            context.Students.Update(std);
            context.SaveChanges();
        }
    }

    public void Delete(int studentId)
    {
        var context = new Config();
        var student = new Student();
        student.StudentId = studentId;
        context.Students.Remove(student);
        context.SaveChanges();
    }

    public Student GetById(int studentId)
    {
        var context = new Config();
        var student = context.Students.FirstOrDefault(student => student.StudentId == studentId);
        if (student != null)
        {
            return student;
        }

        return new Student();
    }

    public List<Student> List()
    {
        var context = new Config();
        return context.Students.ToList();
    }
}