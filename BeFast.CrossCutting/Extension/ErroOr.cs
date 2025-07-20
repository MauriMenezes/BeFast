using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeFast.CrossCutting.extension
{
    public readonly record struct ErroOr<T>
    {
        public bool IsSuccess { get; }
        public T? Result { get; }
        public string? Error { get; }

        public ErroOr(T resultado)
        {
            IsSuccess = true;
            Result = resultado;
            Error = null;
        }

        public ErroOr(string erro)
        {
            IsSuccess = false;
            Result = default;
            Error = erro;
        }

        public static ErroOr<T> Success(T resultado) => new ErroOr<T>(resultado);

        public static ErroOr<T> Failure(string erro) => new ErroOr<T>(erro);
    }
}