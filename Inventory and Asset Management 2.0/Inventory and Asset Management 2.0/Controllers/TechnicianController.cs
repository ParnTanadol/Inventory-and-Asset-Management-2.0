using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventory_and_Asset_Management_2._0.Models;

namespace Inventory_and_Asset_Management_2._0.Controllers
{
    public class TechnicianController : Controller
    {
        //
        // GET: /Technician/

        public ActionResult TechnicianMainpage()
        {
            int technicianId = int.Parse(Session["userId"].ToString());
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByStatusAndUserId(technicianId, 1);
            return View(reportModelList);
        }

        public ActionResult ItemInformation()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            ItemModel itemModel = new ItemModel();
            itemModel.viewItemModelByItemId(itemId);
            return View(itemModel);
        }

        public ActionResult ReporterInformation()
        {
            int reporterId = int.Parse(Request["reporterId"].ToString());
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.viewUserByuserId(reporterId);
            return View(camtUserModel);
        }

        public ActionResult Repairing()
        {
            int technicianId = int.Parse(Session["userId"].ToString());
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByStatusAndUserId(technicianId, 2);
            return View(reportModelList);
        }
        public ActionResult RepairingHistory()
        {
            int technicianId = int.Parse(Session["userId"].ToString());
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByStatusAndUserId(technicianId, 3);
            return View(reportModelList);
        }

        public ActionResult updateRepairingStatus()
        {
            int reportId = int.Parse(Request["reportId"].ToString());
            ReportModel reportModel = new ReportModel();
            reportModel.updateRepairingStatus(reportId, 2);
            return RedirectToAction("TechnicianMainpage");
        }

        public ActionResult RepairingInformation()
        {
            int reportId = int.Parse(Request["reportId"].ToString());
            ReportModel reportModel = new ReportModel();
            reportModel.viewReportByReportId(reportId);
            return View(reportModel);
        }

        public ActionResult RepairingHistoryInformation()
        {
            int reportId = int.Parse(Request["reportId"].ToString());
            ReportModel reportModel = new ReportModel();
            reportModel.viewReportByReportId(reportId);
            return View(reportModel);
        }

        public ActionResult TechnicianInformation()
        {
            int reporterId = int.Parse(Session["userId"].ToString());
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.viewUserByuserId(reporterId);
            return View(camtUserModel);
        }

        [HttpPost]
        public ActionResult editTechnicianInfo()
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
            bool status = camtUserModel.updateCAMTUser(userId, username, password, name, department, room, address, tel, email, userType, userActive);

            if (status == false)
            {
                TempData["msg"] = "Your information is incorrect, please fill information again";
                return RedirectToAction("TechnicianInformation");
            }
            else
            {
                TempData["msg"] = "Update Technician information successful” ";
                return RedirectToAction("TechnicianInformation");
            }
        }

        [HttpPost]
        public ActionResult editTechnicianPass()
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
                    return RedirectToAction("TechnicianInformation");
                }
                else
                {
                    TempData["msg"] = "Update your password successful";
                    return RedirectToAction("TechnicianInformation");
                }
            }
            else
            {
                TempData["msg"] = "Old password incorrect";
                return RedirectToAction("TechnicianInformation");
            }

        }

        [HttpPost]
        public ActionResult updateRepairing()
        {
            int reportId = int.Parse(Request["reportId"].ToString());
            int reportStatusComplete = int.Parse(Request["report_statusComplete"].ToString());
            string repairingDetail = Request["reparingDescription"].ToString();

            string technicianName = Request["technicianName"].ToString();
            string reporterName = Request["reporterName"].ToString();
            string reporterEmail = Request["reporterEmail"].ToString();
            string itemBrand = Request["itemBrand"].ToString();
            string itemName = Request["itemName"].ToString();
            string technicianContract = Request["technicianContract"].ToString();
            bool recieveMsgStatus = Boolean.Parse(Request["recieveMsg"]);


            
            if (reportStatusComplete == 2)
            {
                ReportModel reportModel = new ReportModel();
                bool status = reportModel.updateReport(reportId, repairingDetail, 2);
                if (status == true)
                {

                    if (recieveMsgStatus == true)
                    {
                        string mailSubject = "New repairing update form: " + technicianName;
                        string mailBody = "Dear, " + reporterName + "\r\n"
                                          + "We inform in repairing information " + "\r\n"
                                          + "Item Name: " + itemName + "\r\n"
                                          + "Item Band: " + itemBrand + "\r\n"
                                          + "Repairing Description: " + repairingDetail+ "\r\n"
                                          + "Technician contract: " + technicianContract;
                        MailAPI mailAPI = new MailAPI();
                        mailAPI.Send(reporterEmail, mailSubject, mailBody);
                    }
                    TempData["msg"] = "Repairing information is updated";
                }
                else
                {
                    TempData["msg"] = "Can't Update repairing information";

                }
                string url = "~/Technician/RepairingInformation?reportId=" + reportId;
                return Redirect(url);
            }
            else
            {
                ReportModel reportModel = new ReportModel();
                bool status = reportModel.updateReport(reportId, repairingDetail, 3);
                if (status == true)
                {

                    if (recieveMsgStatus == true)
                    {
                        string mailSubject = "New repairing update form: " + technicianName;
                        string mailBody = "Dear, " + reporterName + "\r\n"
                                          + "We inform in repairing information " + "\r\n"
                                          + "Item Name: " + itemName + "\r\n"
                                          + "Item Band: " + itemBrand + "\r\n"
                                          + "Repairing Description: " + repairingDetail + "\r\n"
                                          + "Repairing status: repair complete" + "\r\n"
                                          + "Technician contract: " + technicianContract;
                        MailAPI mailAPI = new MailAPI();
                        mailAPI.Send(reporterEmail, mailSubject, mailBody);
                    }
                    TempData["msg"] = "Repairing information is updated";
                }
                else
                {
                    TempData["msg"] = "Can't Update repairing information";
                }
                string url = "~/Technician/RepairingInformation?reportId=" + reportId;
                return Redirect(url);
            }
        }



    }
}
