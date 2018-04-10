using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories
{
    public interface IPratoRepository : IRepositoryBase<Domain.Entities.Prato>
    {
        IEnumerable<Domain.Entities.Prato> BuscarPorNome(string nome);
    }
}
