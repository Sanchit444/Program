using System;
using System.Collections;

public class Student{
public string Name;
   
    public string MobileNo;
    
     public  Student(string name, string mobileno)
    {
        Name = name;
        MobileNo = mobileno;
    }
    public static void  AddNewPair(List<Student> L, Student obj)
    {
      L.Add(obj);
      Student.SortStudentByName(l);

    }
     public static void RemoveWithKey(List<Student> L,string name)
     {
      for(int i=0;i<L.Count;i++)
      {
        if(L[i].Name == name)
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
        Console.WriteLine($"Name: {i.Name}, Mobile No: {i.MobileNo}");
      }
     }
     public static void DisplayUisngName(List<Student>L,string name)
     {
      foreach(Student i in L)
      {
        if(i.Name == name)
         Console.WriteLine($"Name: {i.Name}, Mobile No: {i.MobileNo}");
      }
      }
      public static void DisplayUisngMobile(List<Student>L,string mobileno)
     {
      foreach(Student i in L)
      {
        if(i.MobileNo == mobileno)
         Console.WriteLine($"Name: {i.Name}, Mobile No: {i.MobileNo}");
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
      Student s1 = new Student("Sanchit","9324519171");
      List<Student> l = new List<Student>();
      Student.AddNewPair(l,s1);
       Student s2 = new Student("abc","1234556");
       Student s3 = new Student("bcd","456768990");
        Student.AddNewPair(l,s2);
        Student.AddNewPair(l,s3);
       Student.DisplayStudent(l);
       Student.RemoveWithKey(l,"abc");
      //  Student.DisplayStudent(l);
       Student.DisplayStudent(l);
}
}


