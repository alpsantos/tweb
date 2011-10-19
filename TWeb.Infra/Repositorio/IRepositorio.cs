using System;
using System.Collections.Generic;

namespace TWeb.Infra.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> BuscarColecao(Func<T, bool> expressao);
        T Buscar(Func<T, bool> expressao);

        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Deletar(T entidade);
        void Salvar();
    }
}
