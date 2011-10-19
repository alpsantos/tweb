using System.Collections.Generic;

namespace TWeb.Infra.Dominio
{
    public abstract class EntidadeBase<TId>
    {
        public TId Id { get; set; }

        private List<RegraDeNegocio> _regrasDeNegocioInvalidas = new List<RegraDeNegocio>();

        protected void AdicionarRegraDeNegocioInvalida(RegraDeNegocio regraDeNegocio)
        {
            _regrasDeNegocioInvalidas.Add(regraDeNegocio);
        }


        public abstract void Validar();

        public IEnumerable<RegraDeNegocio> BuscarRegrasDeNegocioInvalidas()
        {
            return _regrasDeNegocioInvalidas;
        }

        public override bool Equals(object entidade)
        {
            return entidade != null && entidade is EntidadeBase<TId> && this == (EntidadeBase<TId>)entidade;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntidadeBase<TId> entidade1, EntidadeBase<TId> entidade2)
        {
            if ((object)entidade1 == null && (object)entidade2 == null)
            {
                return true;
            }
            if ((object)entidade1 == null || (object)entidade2 == null)
            {
                return false;
            }
            if (entidade1.Id.ToString() == entidade2.Id.ToString())
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(EntidadeBase<TId> entidade1, EntidadeBase<TId> entidade2)
        {
            return (!(entidade1 == entidade2));
        }
    }
}