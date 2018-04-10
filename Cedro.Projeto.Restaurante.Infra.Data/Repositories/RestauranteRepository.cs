using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Infra.Data.Repositories
{
    public class RestauranteRepository : RepositoryBase<Domain.Entities.Restaurante>, IRestauranteRepository
    {
        public IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome)
        {
            return Db.Restaurante.Where(p => p.Nome == nome);
        }
    }
}
