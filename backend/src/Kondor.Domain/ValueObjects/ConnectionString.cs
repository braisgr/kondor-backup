using Kondor.Domain.Common;

namespace Kondor.Domain.ValueObjects;

public sealed class ConnectionString
{
    public string Value { get; }
    
    private ConnectionString(string value)
    {
        Value = value;
    }
    
    public static Result<ConnectionString> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<ConnectionString>.Failure("Connection string cannot be empty");
            
        return Result<ConnectionString>.Success(new ConnectionString(value));
    }
    
    public override string ToString() => Value;
}