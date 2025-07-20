using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeFast.CrossCutting.extension;

namespace BeFast.CrossCutting.Extension
{
    public static class ExceptionExtensions
    {
        public static ErroOr<T> ToErroOrFailure<T>(this Exception ex, string source)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            return ErroOr<T>.Failure($"Source: {source}, Erro: {errorMessage}");
        }
    }
}