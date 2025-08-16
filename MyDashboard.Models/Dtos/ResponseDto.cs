public class ResponseDto<T>
{
    public string Title { get; set; } = "";
    public string Status { get; set; } = "";
    public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    public T? Data { get; set; }
}