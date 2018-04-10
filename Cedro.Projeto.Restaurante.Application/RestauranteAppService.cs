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
    public class RestauranteAppService : AppServiceBase<Domain.Entities.Restaurante>, IRestauranteAppService
    {
        private readonly IRestauranteService _restauranteService;

        public RestauranteAppService(IRestauranteService restauranteservice)
            : base(restauranteservice)
        {
            _restauranteService = restauranteservice;
        }

        public IEnumerable<Domain.Entities.Restaurante> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
