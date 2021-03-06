﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using System.Data;
using System.Net.Mail;
using Inventory_and_Asset_Management_2._0.Models;
using Inventory_and_Asset_Management_2._0.Repositories;
using System.Drawing.Imaging;

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

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        //Pass
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
                    return RedirectToAction("ReparationManagement");
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


        public ActionResult UserManagement()
        {
            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        public ActionResult AdministratorInfor()
        {
            int adminId = int.Parse(Session["userId"].ToString());
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.viewUserByuserId(adminId);
            return View(camtUserModel);
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

        // Pass
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
                TempData["msg"] = "Your username are duplicate with other username";
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

        // Can't delete user ไม่ได้เขียนใน SRS ต้องรอถามจานอีกที
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
                    TempData["msg"] = "Can't delete user";
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
                    TempData["msg"] = "Can't delete user";
                    return RedirectToAction("ReporterManagement");
                }
            }
        }

        public ActionResult ItemManagement()
        {
            /*
            try
            {
                string searchType = Request["searchType"].ToString();
                string keyword = Request["keyword"].ToString();
                ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
                itemOwnerModelList = itemOwnerModel.viewAllItemOwner();
                List<ItemOwnerModel> newItemOwnerModelList = new List<ItemOwnerModel>();
                if (!String.IsNullOrEmpty(keyword))
                {

                    switch (searchType)
                    {
                        case "itemBrand":
                            newItemOwnerModelList = itemOwnerModelList.Where(i => i.item_id.item_brand.Contains(keyword)).ToList();
                            newItemOwnerModelList = newItemOwnerModelList.OrderBy(i => i.item_id.item_brand).ToList();
                            break;

                        case "itemStatus":
                            if (keyword == "0")
                            {
                                newItemOwnerModelList = itemOwnerModelList;
                            }
                            else
                            {
                                newItemOwnerModelList = itemOwnerModelList.Where(i => i.item_id.item_status == int.Parse(keyword)).ToList();
                                newItemOwnerModelList = newItemOwnerModelList.OrderBy(i => i.item_id.item_brand).ToList();
                            }
                            break;

                    }
                }
                //-----------item Brand group-----------
                ItemModel itemModel = new ItemModel();
                List<string> itemBrand = new List<string>();
                itemBrand = itemModel.viewGroupByItemBrand();
                ViewData["itemBrand"] = itemBrand;

                return View(newItemOwnerModelList);
            }*/

                ItemModel itemModel = new ItemModel();
                List<string> itemBrand = new List<string>();
                itemBrand = itemModel.viewGroupByItemBrand();

                ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
                itemOwnerModelList = itemOwnerModel.viewAllItemOwner();

                ViewData["itemBrand"] = itemBrand;
                return View(itemOwnerModelList);
            

        }
        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult AddItemOwner()
        {
            CAMTUserModel camtUserModel = new CAMTUserModel();
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList = camtUserModel.viewAllCAMTUser();
            return View(camtUserModelList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addItem()
        {
            int count = int.Parse(Request["count"].ToString());
            int itemComponentAdd = 0;
            for (int x = 1; x <= count; x++)
            {
                string index = x.ToString();
                string itemPictureIndex = "item-picture" + index;
                string itemBandIndex = "item-band" + index;
                string itemNameIndex = "item-name" + index;
                string itemDescriptionIndex = "item-description" + index;
                string itemEndDateIndex = "time-end" + index;
                string itemStatusIndex = "item-status" + index;

                //serialNumber
                string camtNumberIndex = "camt-number" + index;
                string cmuNumberIndex = "cmu-number" + index;
                string serialNumberIndex = "serial-number" + index;

                // getdata
                HttpPostedFileBase itemPicture = Request.Files[itemPictureIndex];
                string itemBand = Request[itemBandIndex].ToString();
                string itemName = Request[itemNameIndex].ToString();
                string itemDescription = Request[itemDescriptionIndex].ToString();
                DateTime itemStartDate = DateTime.Now;
                string endDate = Request[itemEndDateIndex].ToString();

                Nullable<DateTime> itemEndDate = null;

                if (endDate != "")
                {
                    itemEndDate = DateTime.Parse(endDate);
                }

                int itemStatus = int.Parse(Request[itemStatusIndex].ToString());
                // component id
                Nullable<int> itemComponent = null;
                if (count == 1)
                {
                    itemComponent = null;
                }
                else
                {
                    if (x == 1)
                    {
                        itemComponent = null;
                    }
                    else
                    {
                        itemComponent = itemComponentAdd;
                    }
                }


                // Owner
                int userItemOwner = int.Parse(Request["userOwnerId"].ToString());
                //serialNumber
                string camtNumber = Request[camtNumberIndex].ToString();
                string cmuNumber = Request[cmuNumberIndex].ToString();
                string serialNumber = Request[serialNumberIndex].ToString();

                ItemModel itemModel = new ItemModel();
                bool status1 = itemModel.insertItem(itemBand, itemName, itemDescription, itemStartDate, itemEndDate, itemStatus, cmuNumber, camtNumber, serialNumber, itemComponent);

                if (status1 == true)
                {

                    itemModel.viewPreviousItem();

                    // create picture name
                    string fileType = "";

                    if (itemPicture.ContentType.Contains("jpeg"))
                    {
                        fileType = ".jpg";
                    }
                    else if (itemPicture.ContentType.Contains("png"))
                    {
                        fileType = ".png";
                    }

                    var fileName = "picItem-" + itemModel.item_id + fileType;
                    itemModel.item_picture = fileName;

                    // add picturer in path
                    if (itemPicture.ContentLength > 0)
                    {
                        System.Drawing.Image bm = System.Drawing.Image.FromStream(itemPicture.InputStream);
                        bm = ResizeBitmap((Bitmap)bm, 200, 200); /// new width, height
                        bm.Save(Path.Combine(Server.MapPath("~/Content/ItemPics/"), fileName));
                    }

                    // update product info
                    Nullable<int> componentItemId = null;
                    if (itemModel.item_component.item_id != 0)
                    {
                        componentItemId = itemModel.item_component.item_id;
                    }
                    itemModel.updateItem(itemModel.item_id, itemModel.item_brand, itemModel.item_name, itemModel.item_description, itemModel.item_startDate, itemModel.item_endDate, itemModel.item_status, itemModel.item_picture, itemModel.item_cmuNumber, itemModel.item_camtNumber, itemModel.item_serialNumber, componentItemId);
                    // set itemComponentAdd
                    if (x == 1)
                    {
                        itemComponentAdd = itemModel.item_id;
                    }
                    // add item Owner

                    ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                    bool status2 = itemOwnerModel.insertItemOwner(itemModel.item_id, userItemOwner);
                }
            }

            TempData["msg"] = "Add items is success";

            return RedirectToAction("AddItem");
        }

        public ActionResult ItemInformation()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
            itemOwnerModelList = itemOwnerModel.viewItemOwnerInformation(itemId);
            return View(itemOwnerModelList);
        }

        /*
        public ActionResult ItemInformationView()
        {

        }
         * */
        public ActionResult EditItem()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            itemOwnerModel = itemOwnerModel.viewItemOwnerByItemId(itemId);
            return View(itemOwnerModel);
        }

        public ActionResult EditOwner()
        {
            
            int itemId = int.Parse(Request["itemId"].ToString());
            int itemOwnerId = int.Parse(Request["itemOwnerId"].ToString());
            int ownerId = int.Parse(Request["ownerId"].ToString());

            List<int> itemInfo = new List<int>();
            itemInfo.Add(itemOwnerId);
            itemInfo.Add(itemId);
            itemInfo.Add(ownerId);
            ViewData["itemInfo"] = itemInfo;

            CAMTUserModel camtUserModel = new CAMTUserModel();
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList = camtUserModel.viewAllCAMTUser();

            return View(camtUserModelList);
        }

        public ActionResult editItemOwner()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            int itemOwnerId = int.Parse(Request["itemOwnerId"].ToString());
            int ownerId = int.Parse(Request["ownerId"].ToString());
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            itemOwnerModel.updateItemOwner(itemOwnerId, ownerId);

            string url = "~/Home/EditItem?itemId=" + itemId;
            return Redirect(url);
        }

        public ActionResult AddComponent()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            int ownerId = int.Parse(Request["ownerId"].ToString());

            List<int> componentInfo = new List<int>();
            componentInfo.Add(itemId);
            componentInfo.Add(ownerId);
            ViewData["componentInfo"] = componentInfo;

            return View();
        }
        //Pass
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addComponent()
        {
            int itemComponent = int.Parse(Request["itemId"].ToString());
            int ownerId = int.Parse(Request["ownerId"].ToString());

            string itemBrand = Request["item-band"].ToString();
            string itemName = Request["item-name"].ToString();
            string itemDescription = Request["item-description"].ToString();
            DateTime itemStartDate = DateTime.Now;
            string endDate = Request["time-end"].ToString();

            Nullable<DateTime> itemEndDate = null;

            if (endDate != "")
            {
                itemEndDate = DateTime.Parse(endDate);
            }

            int itemStatus = int.Parse(Request["item-status"].ToString());
            HttpPostedFileBase itemPicture = Request.Files["item-picture"];
            string cmuNumber = Request["cmu-number"].ToString();
            string camtNumber = Request["camt-number"].ToString();
            string serialNumber = Request["serial-number"].ToString();

            ItemModel itemModel = new ItemModel();
            bool status1 = itemModel.insertItem(itemBrand, itemName, itemDescription, itemStartDate, itemEndDate, itemStatus, cmuNumber, camtNumber, serialNumber, itemComponent);

            if (status1 == true)
            {

                itemModel.viewPreviousItem();

                // create picture name
                string fileType = "";

                if (itemPicture.ContentType.Contains("jpeg"))
                {
                    fileType = ".jpg";
                }
                else if (itemPicture.ContentType.Contains("png"))
                {
                    fileType = ".png";
                }

                var fileName = "picItem-" + itemModel.item_id + fileType;
                itemModel.item_picture = fileName;

                // add picturer in path
                if (itemPicture.ContentLength > 0)
                {
                    System.Drawing.Image bm = System.Drawing.Image.FromStream(itemPicture.InputStream);
                    bm = ResizeBitmap((Bitmap)bm, 200, 200); /// new width, height
                    bm.Save(Path.Combine(Server.MapPath("~/Content/ItemPics/"), fileName));
                }

                // update product info
                Nullable<int> componentItemId = null;
                if (itemModel.item_component.item_id != 0)
                {
                    componentItemId = itemModel.item_component.item_id;
                }
                itemModel.updateItem(itemModel.item_id, itemModel.item_brand, itemModel.item_name, itemModel.item_description, itemModel.item_startDate, itemModel.item_endDate, itemModel.item_status, itemModel.item_picture, itemModel.item_cmuNumber, itemModel.item_camtNumber, itemModel.item_serialNumber, componentItemId);

                ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
                bool status2 = itemOwnerModel.insertItemOwner(itemModel.item_id, ownerId);
            }
            TempData["msg"] = "Add component success";

            string url = "~/Home/ItemInformation?itemId=" + itemComponent;
            return Redirect(url);
        }

        public ActionResult removeComponent()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            int itemComponent = int.Parse(Request["itemComponent"].ToString());
            ItemModel itemModel = new ItemModel();
            itemModel.removeComponent(itemComponent);

            string url = "~/Home/ItemInformation?itemId=" + itemId;
            return Redirect(url);
        }
        //Pass
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editItem()
        {
            int itemId = int.Parse(Request["itemId"].ToString());
            string itemBrand = Request["itemBrand"].ToString();
            string itemName = Request["itemName"].ToString();
            string itemDescription = Request["itemDescription"].ToString();
            DateTime itemStartDate = DateTime.Parse(Request["itemStartDate"].ToString());
            Nullable<DateTime> itemEndDate = DateTime.Parse(Request["itemEndDate"].ToString());
            int itemStatus = int.Parse(Request["itemStatus"].ToString());
            string itemPicturerName = Request["itemPicturerName"].ToString();
            HttpPostedFileBase itemPicture = Request.Files["picturer"];
            string cmuNumber = Request["cmuNumber"].ToString();
            string camtNumber = Request["camtNumber"].ToString();
            string serialNumber = Request["serialNumber"].ToString();

            Nullable<int> itemComponent;
            if (!(Request["itemComponent"].ToString().Equals("0")))
            {
                itemComponent = int.Parse(Request["itemComponent"].ToString());
            }
            else
            {
                itemComponent = null;
            }

            if (itemPicture.ContentLength > 0)
            {
                string fileType = "";

                if (itemPicture.ContentType.Contains("jpeg"))
                {
                    fileType = ".jpg";
                }
                else if (itemPicture.ContentType.Contains("png"))
                {
                    fileType = ".png";
                }

                // Delete old picturer
                var fullPath = Server.MapPath("~/Content/ItemPics/" + itemPicturerName);
                FileInfo fileInfo = new FileInfo(fullPath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                // add new picturer
                var fileName = "picItem-" + itemId + fileType;
                if (itemPicture.ContentLength > 0)
                {

                    System.Drawing.Image bm = System.Drawing.Image.FromStream(itemPicture.InputStream);
                    bm = ResizeBitmap((Bitmap)bm, 200, 200); /// new width, height
                    bm.Save(Path.Combine(Server.MapPath("~/Content/ItemPics/"), fileName));
                 //   bm.Dispose();
                }
                // update item
                ItemModel itemModel = new ItemModel();
                itemModel.updateItem(itemId, itemBrand, itemName, itemDescription, itemStartDate, itemEndDate, itemStatus, fileName, cmuNumber, camtNumber, serialNumber, itemComponent);
            }
            else
            {
                ItemModel itemModel = new ItemModel();
                itemModel.updateItem(itemId, itemBrand, itemName, itemDescription, itemStartDate, itemEndDate, itemStatus, itemPicturerName, cmuNumber, camtNumber, serialNumber, itemComponent);
            }
            TempData["msg"] = "Edit this item is success";
            string url = "~/Home/EditItem?itemId=" + itemId;
            return Redirect(url);
        }
        //Pass
        [HttpPost]
        public ActionResult editAdminInfo()
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

            TempData["msg"] = "Update Administrator information  successful";
            return RedirectToAction("AdministratorInfor");
            
        }

        
        [HttpPost]
        public ActionResult editAdminPass()
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
                TempData["msg"] = "Update your password successful";
                return RedirectToAction("AdministratorInfor");
            }
            else
            {
                TempData["msg"] = "Old password incorrect";
                return RedirectToAction("AdministratorInfor");
            }

        }

        public ActionResult MIS()
        {
            return View();
        }
        
        public ActionResult ItemMIS()
        {
           
            if (Request["mode"] != null)
            {
                string mode = Request["mode"].ToString();
                switch (mode)
                {
                    case "expireItem":
                        DateTime dateTimeStart = DateTime.Parse(Request["time-start"].ToString());
                        DateTime dateTimeEnd = DateTime.Parse(Request["time-end"].ToString());
                        ItemModel itemModel = new ItemModel();
                        List<ItemModel> itemModelList = new List<ItemModel>();
                        itemModelList = itemModel.viewExpireItem(dateTimeStart, dateTimeEnd);
                        TempData["mode"] = "expireItem";
                        ViewData["expireItemList"] = itemModelList;
                        break;
                    case "brandBroken":
                        List<List<string>> brandBroken = new List<List<string>>();
                        IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                        brandBroken = itemRepo.viewOftenBrokenBrand();
                        ViewData["brandBroken"] = brandBroken;
                        TempData["mode"] = "brandBroken";
                        break;
                    case "nameBroken":
                        List<List<string>> nameBroken = new List<List<string>>();
                        IItemRepo itemRepo2 = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
                        nameBroken = itemRepo2.viewOftenBrokenName();
                        ViewData["nameBroken"] = nameBroken;
                        TempData["mode"] = "nameBroken";
                        break;
                }
                return View();
            }
            else
            {
                return View();
            }

        }

      
        public ActionResult ReparationManagement()
        {
            return View();
        }

        public ActionResult NewReparation()
        {
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByStatusAndUserId(1, 0);
            return View(reportModelList);
        }

        public ActionResult updateTypeBroken()
        {
            int reportId = int.Parse(Request["reportId"].ToString());
            string typeBroken = Request["typeBroken"].ToString();

            ReportModel reportModel = new ReportModel();
            reportModel.distributeWork(reportId, typeBroken);
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByStatusAndUserId(1, 0);
            TempData["msg"] = "Define type of broken already";
            return RedirectToAction("NewReparation", reportModelList);
        }

        public ActionResult AllReparation()
        {
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModelList = camtUserModel.viewAllUserByUserType(2);
            return View(camtUserModelList);
        }


        public ActionResult TechnicianReparation()
        {
            int technicianId = int.Parse(Request["technicianId"].ToString()); 
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList = reportModel.viewReportByTechnicianId(technicianId);
            return View(reportModelList);
        }
        //Pass
        public ActionResult resetRandomTechnician()
        {
            int technicianId = int.Parse(Request["technicianId"].ToString());
            int reportId = int.Parse(Request["reportId"].ToString());
            string typeBroken = Request["typeBroken"].ToString();
            ReportModel reportModel = new ReportModel();
            reportModel.resetDistributeWork(reportId, typeBroken, technicianId);
            TempData["msg"] = "Repair task is distributed to a technician";
            string url = "~/Home/TechnicianReparation?technicianId=" + technicianId;
            return Redirect(url);
        }


        private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
        {
            Bitmap result = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
                g.DrawImage(b, 0, 0, nWidth, nHeight);
            return result;
        }


    }
}
