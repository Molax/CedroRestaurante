using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cedro.Projeto.Restaurante.Api.ViewModel
{
    public class PratoViewModel
    {
        public int IdPrato { get; set; }

        public string Nome { get; set; }

        public string Preco { get; set; }

        public int IdRestaurante { get; set; }

        public virtual RestauranteViewModel Restaurante  { get; set; }
    }
}