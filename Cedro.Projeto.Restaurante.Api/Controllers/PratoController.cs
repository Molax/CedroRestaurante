using AutoMapper;
using Cedro.Projeto.Restaurante.Api.ViewModel;
using Cedro.Projeto.Restaurante.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Cedro.Projeto.Restaurante.Api.Controllers
{
    public class PratoController : ApiController
    {
        private readonly IPratoAppService _pratoApp;


        public PratoController(IPratoAppService app)
        {
            _pratoApp = app;
        }

        [AcceptVerbs("Get")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Prato>))]
        public IHttpActionResult Get(string nome = "")
        {

            IEnumerable<Domain.Entities.Prato> listPratos = new List<Domain.Entities.Prato>();

            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    listPratos = _pratoApp.BuscarPorNome(nome);
                }
                else
                {
                    listPratos = _pratoApp.GetAll();
                }

                return Content(HttpStatusCode.OK, listPratos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [AcceptVerbs("Put")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Prato>))]
        public IHttpActionResult Edit(PratoViewModel prato)
        {
            try
            {
                var pratoDomain = Mapper.Map<PratoViewModel, Domain.Entities.Prato>(prato);
                _pratoApp.Update(pratoDomain);

                return Content(HttpStatusCode.OK, pratoDomain);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }


        [AcceptVerbs("Post")]
        //[BasicAuthentication]
        [ResponseType(typeof(List<Domain.Entities.Prato>))]
        public IHttpActionResult Create(PratoViewModel prato)
        {
            try
            {
                var pratoDomain = Mapper.Map<PratoViewModel, Domain.Entities.Prato>(prato);
                _pratoApp.Add(pratoDomain);

                return Content(HttpStatusCode.OK, pratoDomain);
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
                var pratoDomain = _pratoApp.GetById(id);
                _pratoApp.Remove(pratoDomain);

                return Content(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}
