using Cedro.Projeto.Restaurante.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Services
{
    public interface IPratoService : IServiceBase<Domain.Entities.Prato>
    {
        IEnumerable<Domain.Entities.Prato> BuscarPorNome(string nome);
    }
}
