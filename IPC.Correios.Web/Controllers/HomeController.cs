using IPC.Correios.Core.Services.Interfaces;
using System.Web.Mvc;

namespace IPC.Correios.Middleware.Web.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IEnderecoService _enderecoService;
        public HomeController(IEnderecoService enderecoService)
        {
            this._enderecoService = enderecoService;
        }

        [Route(Name = "Index")]
        [ActionName("Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route(Name = "Resultado")]
        [ActionName("Resultado")]
        public ActionResult Resultado()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route(Name = "BuscaCEP")]
        [ActionName("BuscaCEP")]
        public ActionResult BuscaCEP()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route(Name = "BuscaEndereco")]
        [ActionName("BuscaEndereco")]
        public ActionResult BuscaEndereco()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Teste()
        {
            var teste = this._enderecoService.BuscarLogradouro(123);

            return "teste";
        }
    }

}