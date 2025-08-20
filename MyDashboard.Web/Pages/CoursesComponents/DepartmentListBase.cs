using Microsoft.AspNetCore.Components;

public class DepartmentListBase : ComponentBase
{
    public bool Show { get; set; } = true;
    protected int SelectedEmployeesCount { get; set; } = 0;
    protected void EmployeeSelectionChanged(bool isSelected)
    {
        if(isSelected)
        {
            SelectedEmployeesCount++;
        }
        else
        {
            SelectedEmployeesCount--;
        }
    }
    
    public IEnumerable<Department> Departments { get; set; } = new List<Department>
    {
        new Department{DepartmentId = 1, DepartmentName = "IT" },
        new Department{DepartmentId = 2, DepartmentName = "Management" },
        new Department{DepartmentId = 3, DepartmentName = "Finance" },
        new Department{DepartmentId = 4, DepartmentName = "HR" }
    };

}
public class Department {
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = "";
}