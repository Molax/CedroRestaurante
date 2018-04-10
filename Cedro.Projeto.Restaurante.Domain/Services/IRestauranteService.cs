using Cedro.Projeto.Restaurante.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Services
{
    public interface IRestauranteService : IServiceBase<Domain.Entities.Restaurante>
    {
        IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome);
    }
}
