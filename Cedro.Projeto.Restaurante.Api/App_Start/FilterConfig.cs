using System.Web;
using System.Web.Mvc;

namespace Cedro.Projeto.Restaurante.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
