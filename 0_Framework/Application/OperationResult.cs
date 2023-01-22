namespace _0_Framework.Application;

public class OperationResult
{
    public string TableName { get; set; }
    public string Operation { get; set; }
    public long Id { get; set; }
    public string Message { get; set; }
    public bool IsSucceeded { get; set; }
    public List<KeyValuePair<string, object>> Data { get; set; }

    public OperationResult()
    {
        
    }

    public OperationResult(string tableName)
    {
        TableName = tableName;
    }

    public OperationResult IsCreate()
    {
        Operation = "Create";
        return this;
    }

    public OperationResult Success(string message = "عملیات با موفقیت انجام شد.")
    {
        IsSucceeded = true;
        Message = message;
        return this;
    }

    public OperationResult Failure(string message)
    {
        IsSucceeded = false;
        Message = message;
        return this;
    }

    public OperationResult SetId(long id)
    {
        Id = id;
        return this;
    }
}