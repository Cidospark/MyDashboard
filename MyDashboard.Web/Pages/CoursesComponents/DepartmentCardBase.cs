using Microsoft.AspNetCore.Components;

public class DepartmentCardBase : ComponentBase
{
    [Parameter]
    public Department Department { get; set; }

    [Parameter]
    public bool Show { get; set; }

    protected bool IsSelected { get; set; } 

    [Parameter]
    public EventCallback<bool> OnSelection { get; set; }

    // When the checkbox on the departmentCard is clicked
    // the CheckboxChanged() function is called and in it we set
    // The Iselected value which is binded to the checkbox and will change the current state of that checkbox
    // The we emit the value of the new state to the parent through the EventCallBack
    protected async Task CheckboxChanged(ChangeEventArgs e)
    {
        IsSelected = (bool)e.Value;
        await OnSelection.InvokeAsync(IsSelected);
    }
}