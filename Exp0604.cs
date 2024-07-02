using System;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string MobileNumber { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string JobProfile { get; set; }
    public string Department { get; set; }
    public string BusinessUnit { get; set; }
    public DateOnly DateOfJoining { get; set; }
    public int RM_Id { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Mobile: {MobileNumber}, DOB: {DateOfBirth}, Job Profile: {JobProfile}, Department: {Department}, Business Unit: {BusinessUnit}, Date of Joining: {DateOfJoining}, RM_Id: {RM_Id}";
    }
}
public class EmployeeRepo
{
    private List<Employee> employees;
     public EmployeeRepo()
    {
        employees = new List<Employee>();
    }
      public void AddNewEmployee(Employee employee)
    {
        employees.Add(employee);
    }
      public void RemoveEmployeeById(int id)
    {
        employees.RemoveAll(e => e.Id == id);
    }
    public void UpdateMobileNumberOfEmployeeById(int id, string newMobileNumber)
    {
        var employee = employees.Find(e => e.Id == id);
        if (employee != null)
        {
            employee.MobileNumber = newMobileNumber;
        }
        else
        {
            Console.WriteLine($"Employee with Id {id} not found.");
        }
    }
    public List<Employee> GetAllEmployeesByJoiningDateRange(DateOnly startDate, DateOnly endDate)
    {
        return employees.FindAll(e => e.DateOfJoining >= startDate && e.DateOfJoining <= endDate);
    }
     public List<Employee> GetAllEmployeesByRM(int rmId)
    {
        return employees.FindAll(e => e.RM_Id == rmId);
    }
     public Employee GetRMDetailsByEmployeeId(int employeeId)
    {
        var employee = employees.Find(e => e.Id == employeeId);
        if (employee != null)
        {
            return employees.Find(e => e.Id == employee.RM_Id);
        }
        else
        {
            Console.WriteLine($"Employee with Id {employeeId} not found.");
            return null;
        }
    }
    public void Display()
    {
        foreach(var i in employees)
        {
            Console.WriteLine(i);
        }
    }
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var employee in employees)
            {
                writer.WriteLine($"{employee.Id},{employee.Name},{employee.MobileNumber},{employee.DateOfBirth.ToShortDateString()}," +
                                 $"{employee.JobProfile},{employee.Department},{employee.BusinessUnit}," +
                                 $"{employee.DateOfJoining.ToShortDateString()},{employee.RM_Id}");
            }
        }
    }

     public void LoadFromFile(string filePath)
    {
        employees.Clear();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 9)
                {
                    Employee employee = new Employee()
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        MobileNumber = parts[2],
                        DateOfBirth = DateOnly.Parse(parts[3]),
                        JobProfile = parts[4],
                        Department = parts[5],
                        BusinessUnit = parts[6],
                        DateOfJoining = DateOnly.Parse(parts[7]),
                        RM_Id = int.Parse(parts[8])
                    };
                    employees.Add(employee);
                }
            }
        }
    }
}
class Expt
{
    public static void Main(String[] args)
    {
       EmployeeRepo employeeRepo = new EmployeeRepo();
       Employee newEmployee = new Employee()
        {
            Id = 2,
            Name = "Sanchit Gharge",
            MobileNumber = "9876543210",
            DateOfBirth = new DateOnly(2002, 6, 28),
            JobProfile = "Developer",
            Department = "IT",
            BusinessUnit = "Engineering",
            DateOfJoining = new DateOnly(2022,8,10),
            RM_Id = 100
        };
         employeeRepo.AddNewEmployee(newEmployee);
        //  employeeRepo.SaveToFile(@"C:/Users/dell/Desktop/Expt/employee.txt");
         employeeRepo.LoadFromFile(@"C:/Users/dell/Desktop/Expt/employee.txt");
         employeeRepo.Display();
    }
}