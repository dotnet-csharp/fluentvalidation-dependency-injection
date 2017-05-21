using System.Web.Mvc;
using Tut.Entities;
using Tut.Services;

namespace Tut.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogServices _blogServices;

        public BlogController(IBlogServices services)
        {
            _blogServices = services;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _blogServices.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Blog());
        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);

            _blogServices.Create(blog);
            return new RedirectResult("Index");
        }

        //
        // GET: /Country/Edit/5
        public ActionResult Edit(int id)
        {
            var blog = _blogServices.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Country/Edit
        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);
            _blogServices.Update(blog);
            return RedirectToAction("Index");
        }

        //
        // GET: /Country/Delete/5
        public ActionResult Delete(int id)
        {
            var blog = _blogServices.GetById(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        //
        // POST: /Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection data)
        {
            var blog = _blogServices.GetById(id);
            _blogServices.Delete(blog);
            return RedirectToAction("Index");
        }
    }
}