using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories
{
    public interface IRestauranteRepository : IRepositoryBase<Domain.Entities.Restaurante>
    {
        IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome);
    }

}
