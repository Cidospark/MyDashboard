using Microsoft.AspNetCore.Components;

public class DataBindingBase : ComponentBase
{
    protected string Name1 { get; set; } = "Tom";
    protected string Name2 { get; set; } = "";

    protected string Colour { get; set; } = "red";
    private string _colorPrefix = $"background-color:";
    protected string Colour2 { get { return $"{_colorPrefix}{Colour}"; } set { } }
     
}