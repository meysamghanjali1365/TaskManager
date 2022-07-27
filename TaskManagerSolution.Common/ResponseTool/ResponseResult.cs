namespace TaskManagerSolution.Common.ResponseTool;

public class ResponseResult<T>
{
    public T Result { get; set; }
    public bool IsSuccess { get; set; }
    public string Msg { get; set; }
    public int StatusCode { get; set; }
}
public class ResponseResult {
    public bool IsSuccess { get; set; }
    public string Msg { get; set; }
    public int StatusCode { get; set; }
}