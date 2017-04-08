using System;
using System.Linq;
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
using BBC.Repositories;

namespace BBC.Controllers
{
    public class NewsController : SitecoreController
    {
        #region "fileds"

        private ISitecoreContext context { get; set; }
        private CommentsViewModel CommentsViewModel { get; set; }
        private DatePipeline DatePipeline { get; set; }
        private IComment Comment { get; set; }

        private CategoryRepository CategoryRepository { get; set; }
        private NewsRepository NewsRepository { get; set; }

        #endregion

        public NewsController(ISitecoreContext _context, CommentsViewModel _CommentsViewModel,
            CategoryRepository _CategoryRepository, NewsRepository _NewsRepository,
            DatePipeline _DatePipeline, IComment _Comment)
        {
            context = _context;
            CommentsViewModel = _CommentsViewModel;
            DatePipeline = _DatePipeline;
            Comment = _Comment;
            CategoryRepository = _CategoryRepository;
            NewsRepository = _NewsRepository;
        }

        // GET: NewsContent
        public ActionResult ShowNewsContent()
        {
            INews current = context.GetCurrentItem<INews>();

            CommentsViewModel.Comments = current.Children;

            CorePipeline.Run("DatePipeline", DatePipeline);
            ViewBag.myMessage = DatePipeline.CurrentDate;
            ViewBag.Commentlist = CommentsViewModel;
            return View(current);
        }

        public ActionResult GetCategories()
        {
            var model = context.GetItem<ICategories>("{462BBFC9-52BA-4D5C-836C-BC80765B0B83}");
            ViewBag.RootNode = Sitecore.Context.Database.GetItem("/sitecore/content/Home/News");
            return View("Header", model);
        }

        public ActionResult NewsOfCategory()
        {
            var model = CategoryRepository.GetNewsOfCategory(context.GetCurrentItem<ICategory>());
            return View(model);
        }

        public ActionResult AllNews()
        {
            var model = NewsRepository.GetAllNews().Take(4);
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveComment(Comment model)
        {
            try
            {
                INews current = context.GetCurrentItem<INews>();
                Comment.Description = model.Description;
                Comment.FullName = model.FullName;
                Comment.Name = DateTime.Now.ToString("yy-dddThh-mm-ss");

                var service = new SitecoreService("master");
                var securityDisabler = new SecurityDisabler();
                using (securityDisabler)
                {
                    service.Create<IComment, INews>(current, Comment);
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