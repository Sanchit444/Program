using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
public class Student{
public string Name;
    public int RollNo;
    public string Branch;
    public int Marks;
    public string Location;
     public  Student(string name, int rollNo, string branch, int marks, string location)
    {
        Name = name;
        RollNo = rollNo;
        Branch = branch;
        Marks = marks;
        Location = location;
    }
    public static void  AddStudent(List<Student> L, Student obj)
    {
      L.Add(obj);
    }
     public static void RemoveByRoll(List<Student> L,int Rollno)
     {
      for(int i=0;i<L.Count;i++)
      {
        if(L[i].RollNo == Rollno)
        {
          L.Remove(L[i]);
          break;
        }
      }
     }
     public static  void DisplayStudent(List<Student>L)
     {
      foreach(Student i in L)
      {
        Console.WriteLine($"Name: {i.Name}, Roll No: {i.RollNo}, Branch: {i.Branch}, Marks: {i.Marks}, Location: {i.Location}");
      }
     }
     public static void DisplayStudentWithBranch(List<Student>L,string branch)
     {
      foreach(Student i in L)
      {
        if(i.Branch == branch)
        Console.WriteLine($"Name: {i.Name}, Roll No: {i.RollNo}, Branch: {i.Branch}, Marks: {i.Marks}, Location: {i.Location}");
      }
     }
     public static  void DisplayAllStudentsWithLocation(List<Student>L,string location)
     {
      foreach(Student i in L)
      {
        if(i.Location == location)
        Console.WriteLine($"Name: {i.Name}, Roll No: {i.RollNo}, Branch: {i.Branch}, Marks: {i.Marks}, Location: {i.Location}");
      }
     }
     public static void SortStudentByName(List<Student>L)
     {
    L.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.Ordinal));
    DisplayStudent(L);

     }

}
class Expt{
    static void Main(String[] args)
     {  
      Student s1 = new Student("Sanchit",2,"Cmpn",90,"Ghansoli");
      List<Student> l = new List<Student>();
      Student.AddStudent(l,s1);
       Student s2 = new Student("abc",3,"Inft",9,"Airoli");
       Student s3 = new Student("bc",4,"Etrx",91,"Mumbai");
        Student.AddStudent(l,s2);
        Student.AddStudent(l,s3);
       Student.DisplayStudent(l);
       Student.RemoveByRoll(l,3);
      //  Student.DisplayStudent(l);
       Student.SortStudentByName(l);
       Student.DisplayStudent(l);
}
}


