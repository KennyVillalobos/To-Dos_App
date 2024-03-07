using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Dos_App.Core.Results
{
    public class Result<TValue, TError>
    {
        public readonly TValue? Value;
        public readonly TError? Error;

        public readonly bool _isSuccess;

        public Result(TValue value)
        {
            _isSuccess = true;
            Value = value;
            Error = default;
        }

        private Result(TError error)
        {
            _isSuccess = false;
            Value = default;
            Error = error;
        }

        public static implicit operator Result<TValue, TError>(TValue value) => new Result<TValue, TError>(value);

        public static implicit operator Result<TValue, TError>(TError error) => new Result<TValue, TError>(error);
    }
}
