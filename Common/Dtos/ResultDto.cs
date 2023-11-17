namespace Common.Dtos;

public class ResultDto
{
    public bool IsSuccess { get; set; } = true;
    public string? Message { get; set; } = "با موفقیت انجام شد";
}

public class ResultDto<T>
{
    public bool IsSuccess { get; set; } = true;
    public string? Message { get; set; } = "با موفقیت انجام شد";
    public T? Data { get; set; }
}