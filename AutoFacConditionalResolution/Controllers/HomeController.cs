using AutoFacConditionalResolution.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacConditionalResolution.Controllers
{
    public class HomeController : Controller
    {
        private ISocialMediaRepository _repository;
        public HomeController(ISocialMediaRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {            
            ViewBag.Message = _repository.GetProvider();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}