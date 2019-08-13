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

        private TagCatsRepoDapper _repo = new TagCatsRepoDapper();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            List<TagCatsTableRow> allCats = _repo.GetAll().ToList();
            
            return View(allCats);

        }

        public ActionResult Outline1()
        //Tried to put all the html into an array
        {
            List<TagCatsTableRow> allCats = _repo.GetAll().ToList();

            string[] htmlBlock = new string[allCats.Count+1];
            int crntFolderId = allCats[0].TagNameId;
            string crntFolder = allCats[0].TagName;

            htmlBlock[0] = "<ul>" + "<li>" + crntFolder + "</li>";

            for (int i = 1; i < allCats.Count; i++)
            {
                if (allCats[i].TagParentId == crntFolderId)
                {
                    htmlBlock[i] = "<ul>" + "<li>" + crntFolder + "</li>";
                    htmlBlock[i] += "<li>" + allCats[i].TagName + "/</li>";
                }
                else
                {
                    htmlBlock[i] += "</ul>" + "<li>" + crntFolder + "</li>";
                    crntFolder = allCats[i].TagName;
                }

            }
            htmlBlock[allCats.Count] = "</ul>";

            return View(htmlBlock);
        }

        public ActionResult Outline2()
        {
            List<TagCatsTableRow> allCats = _repo.GetAll().ToList();
            return View(allCats);
        }

        public ActionResult Outline3()
        {
            List<TagCatsTableRow> allCats = _repo.GetAll().ToList();
            return View(allCats);
        }


        public ActionResult Contact()
        // I lost track of what this code does.
        {
            TagCatsRepoDapper repo = new TagCatsRepoDapper();
            IEnumerable<TagCatsTableRow> allCats = repo.GetAll();

            List<OutlineVM1> TagIds = new List<OutlineVM1>();
            int tagId, parentId;
            string tagName;

            foreach (TagCatsTableRow oneTag in allCats)
            {
                //tagId = oneTag.TagNameId;
                //parentId = (int)oneTag.TagParentId;
                //tagName = oneTag.TagName;

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