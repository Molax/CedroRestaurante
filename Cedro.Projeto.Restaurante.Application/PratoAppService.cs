using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cedro.Projeto.Restaurante.Application.Interface;
using Cedro.Projeto.Restaurante.Domain.Entities;
using Cedro.Projeto.Restaurante.Domain.Services;

namespace Cedro.Projeto.Restaurante.Application
{
    public class PratoAppService : AppServiceBase<Domain.Entities.Prato>, IPratoAppService
    {
        private readonly IPratoService _PratoService;

        public PratoAppService(IPratoService pratoservice)
            : base(pratoservice)
        {
            _PratoService = pratoservice;
        }

        public IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Prato> IPratoAppService.BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
