using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HW1c.Models;
using HW1c.Backend;

namespace HW1c.Controllers
{
    public class ReportController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            var myViewModel = new ReportViewModel();

            myViewModel.LogViewModel = LogBackend.Instance.Index();
            myViewModel.NumberOfUsers = 3;

            return View(myViewModel);
        }

        /// <summary>
        /// Look up the record passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Read(string id = null)
        {
            // If no ID passed in, jump to the Index page
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var myData = LogBackend.Instance.Read(id);
            return View(myData);
        }

        /// <summary>
        /// Show the Data to Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Delete(string id = null)
        {
            // If no ID passed in, jump to the Index page
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var myData = LogBackend.Instance.Read(id);
            return View(myData);
        }

        /// <summary>
        /// Delete Action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include ="ID")] string id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // If no ID passed in, jump to the Index page
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var myData = LogBackend.Instance.Read(id);
            if (myData != null)
            {
                LogBackend.Instance.Delete(id);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Create Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// Log the Phone Request
        /// </summary>
        /// <param name="data">The Phone, and EventType, and Value</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Log([Bind(Include =
            "PhoneID," +
            "EventType," +
            "Value," +
            "")] LogModel data)
        {
            var myData = LogBackend.Instance.Create(data);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Create Action
        /// </summary>
        /// <param name="data">The Phone, and EventType, and Value</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = 
            "PhoneID," +
            "EventType," +
            "Value," +
            "")] LogModel data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // If no data passed in, jump to the Index page
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            var myData = LogBackend.Instance.Create(data);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Update Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(string id = null)
        {
            var myData = LogBackend.Instance.Read(id);
            return View(myData);
        }

        /// <summary>
        /// Update Action
        /// </summary>
        /// <param name="data">The Phone, and EventType, and Value</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include =
            "ID," +
            "RecordedDateTime,"+

            "PhoneID," +
            "EventType," +
            "Value," +
            "")] LogModel data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            // If no data passed in, jump to the Index page
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            var myData = LogBackend.Instance.Update(data);
            return RedirectToAction("Index");
        }
    }
}