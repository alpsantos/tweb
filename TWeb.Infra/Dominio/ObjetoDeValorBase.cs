using System;
using System.Collections.Generic;
using System.Text;

namespace TWeb.Infra.Dominio
{
    public abstract class ObjetoDeValorBase<TId>
    {
        public TId Id { get; set; }

        private List<RegraDeNegocio> _regrasDeNegocioInvalidas = new List<RegraDeNegocio>();

        protected void AdicionarRegraDeNegocioInvalida(RegraDeNegocio regraDeNegocio)
        {
            _regrasDeNegocioInvalidas.Add(regraDeNegocio);
        }

        public void SubirExceptionSeInvalido()
        {
            _regrasDeNegocioInvalidas.Clear();

            Validar();

            if (_regrasDeNegocioInvalidas.Count > 0)
            {
                StringBuilder erros = new StringBuilder();

                foreach (var item in _regrasDeNegocioInvalidas)
                {
                    erros.Append(item.Regra);
                }

                throw new Exception(erros.ToString());
            }
        }

        protected abstract void Validar();

    }
}