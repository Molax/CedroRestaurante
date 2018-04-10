using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cedro.Projeto.Restaurante.Domain.Entities
{
    public class Prato
    {
        public int IdPrato { get; set; }

        public string Nome { get; set; }

        public string Preco { get; set; }

        public int IdRestaurante { get; set; }

        public virtual Restaurante Restaurante { get; set; }
    }
}
