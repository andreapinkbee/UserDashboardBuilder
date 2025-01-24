using System;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace UserDashboardBuilder.Core
{
    public class Result<T>
    {
        public T? Value { get; private set; }  // Permite valores nulos si T es un tipo nullable
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }

        // Constructor modificado para permitir valores nulos de forma segura
        public Result(T? value, bool isSuccess, string error)
        {
            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }

        // Métodos para facilitar la creación del Result
        public static Result<T> Success(T? value) => new Result<T>(value, true, string.Empty);
        public static Result<T> Failure(string error) => new Result<T>(default, false, error);
    }
}
