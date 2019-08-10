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
            TagCatsRepoDapper repo = new TagCatsRepoDapper();
            IEnumerable<TagCatsTableRow> allCats = repo.GetAll();

            List<OutlineVM1> TagIds = new List<OutlineVM1>();
            int tagId, parentId;
            string tagName;

            foreach (TagCatsTableRow oneTag in allCats)
            {
                tagId = oneTag.TagNameId;
                parentId = (int)oneTag.TagParentId;
                tagName = oneTag.TagName;

                OutlineVM1 nextTagInfo = new OutlineVM1();
                nextTagInfo.TagId.Add(oneTag.TagNameId);
                nextTagInfo.ParentId.Add((int)oneTag.TagParentId);

                TagIds.Add(nextTagInfo);

            }

            //Finished the foreach above before stopping. Next, send this model to the html page
            //and try to use the parentId as the list index of tag Id to try and make an outline.

            return View();
        }
    }
}