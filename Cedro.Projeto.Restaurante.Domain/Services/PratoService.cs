using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Services
{
    public class PratoService : ServiceBase<Entities.Prato>, IPratoService
    {
        private readonly IPratoRepository _PratoRepository;

        public PratoService(IPratoRepository pratoRepository)
            : base(pratoRepository)
        {
            _PratoRepository = pratoRepository;
        }

        public IEnumerable<Entities.Prato> BuscarPorNome(string nome)
        {
            return _PratoRepository.BuscarPorNome(nome);
        }
    }
}
