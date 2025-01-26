using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace UserDashboardBuilder.Core
{
    public class Result<T>
    {
        public T? Value { get; private set; }  
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }

        public Result(T? value, bool isSuccess, string error)
        {
            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result<T> Success(T? value) => new Result<T>(value, true, string.Empty);
        public static Result<T> Failure(string error) => new Result<T>(default, false, error);
    }
}
