using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_and_Asset_Management_2._0.Models;

namespace Inventory_and_Asset_Management_2._0.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.loginUser(username, password);
            if (camtUserModel.user_id != 0)
            {
                if (camtUserModel.user_type == 1 && camtUserModel.user_active == true)
                {
                    Session["userId"] = camtUserModel.user_id.ToString();
                    Session["userType"] = camtUserModel.user_type.ToString();
                    return RedirectToAction("AdministratorMainpage");
                }
                else if (camtUserModel.user_type == 2 && camtUserModel.user_active == true)
                {
                    Session["userId"] = camtUserModel.user_id.ToString();
                    Session["userType"] = camtUserModel.user_type.ToString();
                    return RedirectToAction("TechnicianMainpage", "Technician");
                }
                else if (camtUserModel.user_type == 3 && camtUserModel.user_active == true)
                {
                    Session["userId"] = camtUserModel.user_id.ToString();
                    Session["userType"] = camtUserModel.user_type.ToString();
                    return RedirectToAction("ReporterMainpage", "Reporter");
                }
                else if (camtUserModel.user_active == false)
                {
                    TempData["msg"] = "your username still not approve from administrator";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["msg"] = "username or password incorrect";
                return RedirectToAction("Index");
            }
        }

        public ActionResult AdministratorMainpage()
        {
            return View();
        }

        public ActionResult UserManagement()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult TechnicianManagement()
        {
            CAMTUserModel camtUserModel = new CAMTUserModel();
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList = camtUserModel.viewAllUserByUserType(2);

            return View(camtUserModelList);
        }
        public ActionResult ReporterManagement()
        {
            CAMTUserModel camtUserModel = new CAMTUserModel();
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList = camtUserModel.viewAllUserByUserType(3);

            return View(camtUserModelList);
        }

        [HttpPost]
        public ActionResult registerCAMTUser()
        {
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();
            string name = Request["name"].ToString();
            string department = Request["department"].ToString();
            string room = Request["room"].ToString();
            string address = Request["address"].ToString();
            string tel = Request["tel"].ToString();
            string email = Request["email"].ToString();
            int userType = int.Parse(Request["userType"].ToString());
            int userActive = int.Parse(Request["userActive"].ToString());

            CAMTUserModel camtUserModel = new CAMTUserModel();
            bool status = camtUserModel.insertCAMTUser(username, password, name, department, room, address, tel, email, userType, userActive);

            if (status == false)
            {
                TempData["msg"] = "Your information is incorrect, please fill information again";
                return RedirectToAction("UserRegistration");
            }
            else
            {
                TempData["msg"] = "Registration successful";
                return RedirectToAction("UserRegistration");
            }

        }

        public ActionResult approveUser(CAMTUserModel camtUserModel1)
        {
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.updateCAMTUser(camtUserModel1.user_id, camtUserModel1.user_username, camtUserModel1.user_password, camtUserModel1.user_name, camtUserModel1.user_department, camtUserModel1.user_room, camtUserModel1.user_address, camtUserModel1.user_tel, camtUserModel1.user_email, camtUserModel1.user_type, true);
            if (camtUserModel1.user_type == 2)
            {
                return RedirectToAction("TechnicianManagement");
            }
            else
            {
                return RedirectToAction("ReporterManagement");
            }

        }

        public ActionResult disapproveUser(CAMTUserModel camtUserModel1)
        {
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.updateCAMTUser(camtUserModel1.user_id, camtUserModel1.user_username, camtUserModel1.user_password, camtUserModel1.user_name, camtUserModel1.user_department, camtUserModel1.user_room, camtUserModel1.user_address, camtUserModel1.user_tel, camtUserModel1.user_email, camtUserModel1.user_type, false);
            if (camtUserModel1.user_type == 2)
            {
                return RedirectToAction("TechnicianManagement");
            }
            else
            {
                return RedirectToAction("ReporterManagement");
            }

        }

        public ActionResult deleteCAMTUser(CAMTUserModel camtUserModel1)
        {
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            bool status = camtUserModel2.removeCAMTUser(camtUserModel1.user_id);
            if (camtUserModel1.user_type == 2)
            {
                if (status == true)
                {
                    TempData["msg"] = "Delete user successful";
                    return RedirectToAction("TechnicianManagement");
                }
                else
                {
                    TempData["msg"] = "Can't delete user successful";
                    return RedirectToAction("TechnicianManagement");
                }

            }
            else
            {
                if (status == true)
                {
                    TempData["msg"] = "Delete user successful";
                    return RedirectToAction("ReporterManagement");
                }
                else
                {
                    TempData["msg"] = "Can't delete user successful";
                    return RedirectToAction("ReporterManagement");
                }
            }
        }

        public ActionResult ItemManagement()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }

    }
}
