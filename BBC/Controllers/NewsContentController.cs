using System;
using System.Web.Mvc;
using BBC.Factories;
using BBC.Models;
using BBC.Pipelines;
using BBC.ViewModels;
using Glass.Mapper.Sc;
using Sitecore.Mvc.Controllers;
using Sitecore.Pipelines;
using Sitecore.SecurityModel;

namespace BBC.Controllers
{
    public class NewsContentController : SitecoreController
    {
        // GET: NewsContent
        public ActionResult ShowNewsContent()
        {
            var context = new SitecoreContext();

            INews current = context.GetCurrentItem<INews>();
            CommentsViewModel model = new CommentsViewModel()
            {
                Comments = current.Children
            };
            var args = new DatePipeline();
            CorePipeline.Run("DatePipeline", args);
            ViewBag.myMessage = args.CurrentDate;
            ViewBag.Commentlist = model;
            return View(current);
        }


        [HttpPost]
        public ActionResult SaveComment(Comment model)
        {

            var context =new SitecoreContext();

            INews current = context.GetCurrentItem<INews>();
            var _comment = new Comment
            {
                Description = model.Description,
                FullName = model.FullName,
                Name = DateTime.Now.ToString("yy-dddThh-mm-ss")
            };

            var service = BBCFactory.GetSitecoreService(BBCFactory.enumSiteCoreDataBase.Master);

            using (new SecurityDisabler())
            {
                service.Create<IComment, INews>(current, _comment);

            }
            return Json(new { succeed = true, message = "Thanks for your comment!" }, JsonRequestBehavior.AllowGet);

        }


    }
}