using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cedro.Projeto.Restaurante.Domain.Entities;

namespace Cedro.Projeto.Restaurante.Application.Interface
{
    public interface IRestauranteAppService : IAppServiceBase<Domain.Entities.Restaurante>
    {
        IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome);
    }
}
