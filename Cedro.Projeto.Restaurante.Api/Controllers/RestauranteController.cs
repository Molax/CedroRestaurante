using AutoMapper;
using Cedro.Projeto.Restaurante.Api.Filters;
using Cedro.Projeto.Restaurante.Api.ViewModel;
using Cedro.Projeto.Restaurante.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Cedro.Projeto.Restaurante.Api.Controllers
{
    public class RestauranteController : ApiController
    {
        private readonly IRestauranteAppService _restauranteApp;

        public RestauranteController(IRestauranteAppService restauranteapp)
        {
            _restauranteApp = restauranteapp;
        }


        [AcceptVerbs("Get")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Restaurante>))]
        public IHttpActionResult Get(string nome = "")
        {
            IEnumerable<Domain.Entities.Restaurante> listaRestaurantes = new List<Domain.Entities.Restaurante>();

            try
            {
                if (!string.IsNullOrEmpty(nome))
                {
                    listaRestaurantes = _restauranteApp.BuscarPorNome(nome);
                }
                else
                {
                    listaRestaurantes = _restauranteApp.GetAll();
                }

                return Content(HttpStatusCode.OK, listaRestaurantes);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [AcceptVerbs("Get")]
        //[BasicAuthentication]
        [ResponseType(typeof(Domain.Entities.Restaurante))]
        public IHttpActionResult Get(int id)
        {
            Domain.Entities.Restaurante restaurante = new Domain.Entities.Restaurante();

            try
            {
                restaurante = _restauranteApp.GetById(id);

                return Content(HttpStatusCode.OK, restaurante);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [AcceptVerbs("Put")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Restaurante>))]
        public IHttpActionResult Edit(RestauranteViewModel restaurante)
        {
            try
            {
                var restauranteDomain = Mapper.Map<RestauranteViewModel, Domain.Entities.Restaurante>(restaurante);
                _restauranteApp.Update(restauranteDomain);

                return Content(HttpStatusCode.OK, restauranteDomain);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }


        [AcceptVerbs("Post")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Restaurante>))]
        public IHttpActionResult Create(RestauranteViewModel restaurante)
        {
            try
            {
                var restauranteDomain = Mapper.Map<RestauranteViewModel, Domain.Entities.Restaurante>(restaurante);
                _restauranteApp.Add(restauranteDomain);

                return Content(HttpStatusCode.OK, restauranteDomain);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }


        [AcceptVerbs("Delete")]
        //[BasicAuthentication]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var restauranteDomain = _restauranteApp.GetById(id);
                _restauranteApp.Remove(restauranteDomain);

                return Content(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
