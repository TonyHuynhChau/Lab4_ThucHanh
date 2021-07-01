using Lab4_ThucHanh.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4_ThucHanh.Controllers
{
    public class CourseController : Controller
    {
        //GET: Course
        public ActionResult Create()
        {
            BigSchool content = new BigSchool();
            Course c = new Course();
            c.liCategory = content.Categories.ToList();
            return View(c);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course c)
        {
            BigSchool context = new BigSchool();

            ModelState.Remove("Lec");
            if(ModelState.IsValid)
            {
                c.liCategory = context.Categories.ToList();
                return View("Create",c);
            }    
            
            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            c.LecturerId = user.Id;
            context.Courses.Add(c);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}