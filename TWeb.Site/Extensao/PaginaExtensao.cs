using System.Collections.Generic;
using System.Linq;

namespace TWeb.Site.Extensao
{
    public static class PaginaExtensao
    {
        public static IEnumerable<T> Paginacao<T>(this IEnumerable<T> source, int paginaAtual, int quantidadePagina)
        {
            var sourceCopy = source.ToList();

            if (sourceCopy.Count() < quantidadePagina)
            {
                return sourceCopy;
            }

            return sourceCopy.Skip((paginaAtual - 1) * quantidadePagina).Take(quantidadePagina);
        }
    }
}