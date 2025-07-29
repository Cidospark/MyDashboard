using Microsoft.AspNetCore.Components;

public class Counter2Base : ComponentBase
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        currentCount++;
    }
}