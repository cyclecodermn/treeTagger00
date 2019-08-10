using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tagger.Data.Models;
using Tagger.Data.Repos;

namespace Tagger.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            TagCatsRepoDapper repo = new TagCatsRepoDapper();
            IEnumerable<TagCatsTableRow> allCats = repo.GetAll();

            return View(allCats);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}