using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Services
{

    public class RestauranteService : ServiceBase<Entities.Restaurante>, IRestauranteService
    {
        private readonly IRestauranteRepository _PratoRepository;

        public RestauranteService(IRestauranteRepository pratoRepository)
            : base(pratoRepository)
        {
            _PratoRepository = pratoRepository;
        }

        public IEnumerable<Entities.Restaurante> BuscarPorNome(string nome)
        {
            return _PratoRepository.BuscarPorNome(nome);
        }
    }
}
