using Microsoft.AspNetCore.Components;

public class ConfirmBase : ComponentBase
{   
    
    public string toggleModalClass { get; set; } = "hide";

    [Parameter]
    public EventCallback<bool> OnDeleteCallBack { get; set; }

    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public string Text { get; set; } = "";


    protected void CloseDeleteConfirmationModal()
    {
        toggleModalClass = "hide";
    }


    public void OpenDeleteConfirmationModal()
    {
        toggleModalClass = null;
    }

    protected async Task DeleteUser()
    {
        await OnDeleteCallBack.InvokeAsync(true);
    }

}