using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using InterviewQuestionGenerator.Models;

namespace InterviewQuestionGenerator.Controllers
{
    public class ResourceController : Controller
    {
        private ApplicationDbContext _context;

        public ResourceController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Technical()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult Career()
        {
            return View();
        }
    }
}
