using dotnet_menu_app.models;

namespace dotnet_menu_app.repository;

public interface StudentInterface
{
    void Create(Student student);
    void Update(Student student);
    void Delete(int studentId);
    Student GetById(int studentId);
    List<Student> List();
}