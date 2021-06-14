using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = null;
        public StudentController()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student(){ Id=1, Name="Aashna", BatchCode="DotNet", Marks=90},

                    new Student(){ Id=2, Name="Priynaka", BatchCode="DotNet", Marks=87},
                    new Student(){ Id=3, Name="Tisha", BatchCode="SAP", Marks=98},
                    new Student(){ Id=4, Name="Naveen", BatchCode="SAP", Marks=90},
                    new Student(){ Id=5, Name="Siddhant", BatchCode="DotNet", Marks=90},
                    new Student(){ Id=6, Name="Vaibhav", BatchCode="DotNet", Marks=90},
                };
            }
        }
        public ActionResult Index()
        {
            if (TempData["msg"] != null)
                ViewBag.msg = TempData["msg"];
            return View(students);
        }

        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Student student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    ViewBag.msg = "Student with this ID not exist";
                    return View();
                }
                else
                    return View(student);
            }
            else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }
        }

        // Create 

        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (student != null)
            {
                students.Add(student);
            }
            TempData["msg"] = "Record is inserted";
            return RedirectToAction("Index");
        }

        /// Edit
        /// 
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Student student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    ViewBag.msg = "Student with this ID not exist";
                    return View();
                }
                else
                    return View(student);
            }
            else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {

            foreach(Student temp in students)
            {
                if(temp.Id == id)
                {
                    temp.Name = student.Name;
                    temp.BatchCode = student.BatchCode;
                    temp.Marks = student.Marks;
                }
            }
            TempData["msg"] = "Record is updated";
            return RedirectToAction("Index");

        }



        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                Student student = students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    ViewBag.msg = "Student with this ID not exist";
                    return View();
                }
                else
                    return View(student);
            }
            else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }

        }

        [HttpPost]
        public ActionResult Delete (int id)
        {
            Student student = students.FirstOrDefault(x => x.Id == id);
            students.Remove(student);
            TempData["msg"] = "Record is deleted";
            return RedirectToAction("Index");

        }

    }
}
