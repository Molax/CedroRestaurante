using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Infra.Data.Repositories
{

    public class PratoRepository : RepositoryBase<Domain.Entities.Prato>, IPratoRepository
    {
        public IEnumerable<Domain.Entities.Prato> BuscarPorNome(string nome)
        {
            return Db.Prato.Where(p => p.Nome == nome);
        }
    }
}
