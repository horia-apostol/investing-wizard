using InvestingWizard.Shared.Common.Errors;
using System.Text.Json.Serialization;

namespace InvestingWizard.Shared.Common
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; private set; }
        protected Result() { }
        [JsonConstructor]
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None ||
               !isSuccess && error == Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);
    }

    public sealed class Result<T>
        : Result where T : class
    {
        public T? Value { get; private set; }
        [JsonConstructor]
        private Result(bool isSuccess, T? value, Error error)
            : base(isSuccess, error)
        {
            Value = value;
        }
        private Result() { }
        public static Result<T> Success(T value)
        {
            return new Result<T>(true, value, Error.None);
        }
        public static new Result<T> Failure(Error error)
        {
            return new Result<T>(false, null, error);
        }

        public static implicit operator Result<T>(T value)
        {
            return Success(value);
        }

        public static implicit operator Result<T>(Error error)
        {
            return Failure(error);
        }
    }
}
