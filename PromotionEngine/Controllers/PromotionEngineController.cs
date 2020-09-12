using PromotionEngine.Models;
using System.Web.Mvc;

namespace PromotionEngine.Controllers
{
    public class PromotionEngineController : Controller
    {
        // GET: PromotionEngine
        public ActionResult Index()
        {
            return View(new PromotionEngineModel());
        }
    }
}