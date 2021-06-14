using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class AddController : Controller
    {
         
       public ActionResult AddNumbers1()
        {
            return View();
        }

        // Pass Data as parameters 
        [HttpPost]
        public ActionResult AddNumbers1(string txtNo1, string txtNo2)
        {
            int n1 = int.Parse(txtNo1);
            int n2 = int.Parse(txtNo2);
            int result = n1 + n2;
            ViewBag.result = result;
            return View();
        }


        // 2nd way to pass data from view to controlletr to view using Request collection
        public ActionResult AddNumbers2()
        {
            if (TempData["result"] != null)
                ViewBag.result = TempData["result"];
            return View();
        }

        [HttpPost]
        public ActionResult AddNumbers()
        {
            int n1 = int.Parse(Request["txtNo1"]);
            int n2 = int.Parse(Request["txtNo2"]);
            int result = n1 + n2;
            TempData["result"] = result;
            return RedirectToAction("AddNumbers2");

        }

        // 3 Way to pass data from View to Controller using FormsCollection
        public ActionResult AddNumbers3()
        {
           return View();
        }
        [HttpPost]
        public ActionResult AddNumbers3(FormCollection frm)
        {
            int n1 = Convert.ToInt16(frm["txtNo1"]);
            int n2 = int.Parse(frm["txtNo2"]);
            int result = n1 + n2;
            ViewBag.result = result;
            return View();
        }

        // 4 way using Stronly typed View
        public ActionResult AddNumbers4()
        {
            Numbers numbers = new Numbers();
            return View(numbers);

        }

        [HttpPost]
        public ActionResult AddNumbers4(Numbers numbers)
        {
            int n1 = numbers.No1;
            int n2 = numbers.No2;

            int result = n1 + n2;
            ViewBag.result = result;
            return View();

        }
    }
}