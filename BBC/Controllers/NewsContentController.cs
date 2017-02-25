using System;
using System.Web.Mvc;
using BBC.Factories;
using BBC.Models;
using BBC.Pipelines;
using BBC.ViewModels;
using Glass.Mapper.Sc;
using SimpleInjector;
using Sitecore.Mvc.Controllers;
using Sitecore.Pipelines;
using Sitecore.SecurityModel;

namespace BBC.Controllers
{
    public class NewsContentController : SitecoreController
    {
        #region "fileds"
        private SitecoreContext context { get; set; }
        private Container container { get; set; }
        #endregion

        public NewsContentController(SitecoreContext _context,Container _container)
        {
            context = _context;
            container = _container;
        }

        // GET: NewsContent
        public ActionResult ShowNewsContent()
        {
            INews current = context.GetCurrentItem<INews>();

            var commentsModel = container.GetInstance<CommentsViewModel>();
            commentsModel.Comments = current.Children;

            var args = container.GetInstance<DatePipeline>();
            CorePipeline.Run("DatePipeline", args);
            ViewBag.myMessage = args.CurrentDate;
            ViewBag.Commentlist = commentsModel;
            return View(current);
        }

        [HttpPost]
        public ActionResult SaveComment(Comment model)
        {
            try
            {
                INews current = context.GetCurrentItem<INews>();
                IComment comment = container.GetInstance<Comment>();
                comment.Description = model.Description;
                comment.FullName = model.FullName;
                comment.Name = DateTime.Now.ToString("yy-dddThh-mm-ss");


                var service = BBCFactory.GetSitecoreService(BBCFactory.enumSiteCoreDataBase.Master);
                var securityDisabler = container.GetInstance<SecurityDisabler>();
                using (securityDisabler)
                {
                    service.Create<IComment, INews>(current, comment);

                }
                return Json(new {succeed = true, message = "Thanks for your comment!"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new {succeed = false, message = e.Message}, JsonRequestBehavior.AllowGet);
            }
        }
    }
}