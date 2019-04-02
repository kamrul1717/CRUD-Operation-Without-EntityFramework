using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMvcApp.BLL;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager();
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (customerManager.IsSaved(customer))
                    {
                        ViewBag.SMsg = "Saved Successfully";
                    }
                    else
                    {
                        ViewBag.FMsg = "Not Saved";
                    }
                }
                return View();
            }catch(Exception e){
                return View();
            }
        }

        ////[HttpGet]
        ////public ActionResult Update(string Code)
        ////{
        ////    Customer customer = customerManager.GetCustomerInfo(Code);
        ////    return View(customer);
        ////}

        //[HttpPost]
        //public ActionResult Update(Customer customer)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (customerManager.Update(customer))
        //            {
        //                ViewBag.SMsg = "Updated successfully";
        //            }
        //            else
        //            {
        //                ViewBag.FMsg = "Not Updated";
        //            }
        //        }
        //        return View();
        //    }catch(Exception e){
        //        return View();
        //    }
        //}

        public ActionResult Delete(int id)
        {
            if (customerManager.Delete(id))
            {
                ViewBag.SMsg = "Deleted successfully!";
                return RedirectToAction("Show");
            }
            
            ViewBag.FMsg = "Deletion Failed!";
            return View("Show");
            
        }

        public ActionResult Show()
        {

            var dataList = customerManager.Show();
            return View(dataList);
        }

        public ActionResult Search()
        {
            var customer = new Customer();
            var dataList = customerManager.Search(customer);
            return View(dataList);
        }

        [HttpPost]
        public ActionResult Search(Customer customer)
        {
            var dataList = customerManager.Search(customer);
            return View(dataList);
        }



        public ActionResult Edit(int id)
        {
            var customer = customerManager.GetById(id);
            return View(customer);
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUpdated = customerManager.Update(customer);

                    if (isUpdated)
                    {
                        return RedirectToAction("Search");
                    }
                    ViewBag.FMsg = "Failed!!!!";
                }
                return View(customer);
            }
            catch (Exception e)
            {
                ViewBag.EMsg = e.Message;
                return View(customer);
               
            }
        }

	}
}