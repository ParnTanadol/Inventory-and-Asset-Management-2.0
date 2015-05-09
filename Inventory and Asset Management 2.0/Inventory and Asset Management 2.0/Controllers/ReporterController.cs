using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_and_Asset_Management_2._0.Models;

namespace Inventory_and_Asset_Management_2._0.Controllers
{
    public class ReporterController : Controller
    {
        //
        // GET: /Reporter/

        public ActionResult ReporterMainpage()
        {
            return View();
        }

        public ActionResult ReportHistory()
        {
            int reporterId = int.Parse(Session["userId"].ToString());
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportbyReporterId(reporterId);
            return View(reportModelList);
        }

        public ActionResult ReporterInformation()
        {
            int reporterId = int.Parse(Session["userId"].ToString());
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.viewUserByuserId(reporterId);
            return View(camtUserModel);
        }
        
        [HttpPost]
        public ActionResult addReport()
        {
            string serialNumber = Request["serialNumber"].ToString();
            string typeBroken = Request["typeBroken"].ToString();
            string description = Request["description"].ToString();
            string contact = Request["contact"].ToString();
            bool reportRecieveMsg;
            if (Request["reportRecieveMsg"].ToString().Equals("1"))
            {
                reportRecieveMsg = true;
            }
            else
            {
                reportRecieveMsg = false;
            }
            int reporterId = int.Parse(Session["userId"].ToString());
            ReportModel reportModel = new ReportModel();
            bool status = reportModel.insertReport(reporterId, serialNumber, typeBroken, description, contact, reportRecieveMsg);
            if (status == true)
            {
                ReportModel reportModel2 = new ReportModel();
                reportModel2.viewPreviousReport(reporterId);

                MailAPI mailAPI = new MailAPI();
                string emailSubject = "New report form: " + reportModel2.reporter_id.user_name ;
                string emailBody = "New report form: " + reportModel2.reporter_id.user_name + "\r\n"
                              + "Item Information " + "\r\n"
                              + "Item Brand: " + reportModel2.item_id.item_brand + "\r\n"
                              + "Item Name: " + reportModel2.item_id.item_name + "\r\n"
                              + "Broken type: " + reportModel2.report_typeBroken + "\r\n"
                              + "Description: " + reportModel2.report_case + "\r\n"
                              + "Reporter Contract: " + reportModel2.report_contact;
                mailAPI.Send(reportModel2.technician_id.user_email, emailSubject, emailBody);
                
                TempData["msg"] = "Your report are send";
                return RedirectToAction("ReporterMainpage");
            }
            else
            {
                TempData["msg"] = "Can't send report, please contact to Administrator";
                return RedirectToAction("ReporterMainpage");
            }

        }

        public ActionResult ItemInformation()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            ItemModel itemModel = new ItemModel();
            itemModel.viewItemModelByItemId(itemId);
            return View(itemModel);
        }

        [HttpPost]
        public ActionResult editReporterInfo()
        {
            int userId = int.Parse(Request["userId"].ToString());
            string username = Request["username"].ToString();
            string password = Request["password"].ToString();
            string name = Request["name"].ToString();
            string department = Request["department"].ToString();
            string room = Request["room"].ToString();
            string address = Request["address"].ToString();
            string tel = Request["tel"].ToString();
            string email = Request["email"].ToString();
            int userType = int.Parse(Request["userType"].ToString());
            bool userActive = true;
            if (Request["userActive"].ToString().Equals("1"))
            {
                userActive = true;
            }
            else
            {
                userActive = false;
            }
            
            CAMTUserModel camtUserModel = new CAMTUserModel();
            bool status = camtUserModel.updateCAMTUser(userId,username, password, name, department, room, address, tel, email, userType, userActive);

            if (status == false)
            {
                TempData["msg"] = "Your information is incorrect, please fill information again";
                return RedirectToAction("ReporterInformation");
            }
            else
            {
                TempData["msg"] = "Update user infomation successful";
                return RedirectToAction("ReporterInformation");
            }
        }

         [HttpPost]
        public ActionResult editReporterPass()
        {
            int userId = int.Parse(Request["userId"].ToString());
            string password = Request["password"].ToString();
            string oldPassword = Request["oldPassword"].ToString();
            string newPassword = Request["newPassword"].ToString();
            string comfirmPassword = Request["comfirmPassword"].ToString();

            if (password == oldPassword)
            {
                CAMTUserModel camtUserModel = new CAMTUserModel();
                bool status = camtUserModel.updateCAMTUserPass(userId, newPassword);
                if (status == false)
                {
                    TempData["msg"] = "Your information is incorrect, please fill information again";
                    return RedirectToAction("ReporterInformation");
                }
                else
                {
                    TempData["msg"] = "Update your password successful";
                    return RedirectToAction("ReporterInformation");
                }
            }
            else
            {
                TempData["msg"] = "Old password incorrect";
                return RedirectToAction("ReporterInformation");
            }

        }
        
    }
}
