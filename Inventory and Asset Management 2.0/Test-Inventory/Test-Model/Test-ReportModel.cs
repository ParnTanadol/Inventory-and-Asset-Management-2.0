using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0.Models;
using Inventory_and_Asset_Management_2._0;

namespace Test_Inventory.Test_Model
{
    /// <summary>
    /// Summary description for Test_ReportModel
    /// </summary>
    [TestClass]
    public class Test_ReportModel
    {
        private Appendix appendixA = new Appendix();


        [TestCleanup]
        public void cleanup()
        {
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();
        }

        //-----------------insertReport------------
        [TestMethod]
        public void testInsertReport1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(4, "CAMT01", "Cannot open Keynote", "0833201787", true);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testInsertReport2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(0, "CAMT01", "Cannot open Keynote", "0833201787", true);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(4, "CAMT02", "Cannot open Keynote", "0833201787", true);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport4()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(4, null, "Cannot open Keynote", "0833201787", true);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport5()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(4, "CAMT01", null, "0833201787", true);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport6()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.insertReport(4, "CAMT01", "Cannot open Keynote", null, true);

            //Assert
            Assert.IsFalse(actual);
        }



        //-----------------updateReport------------
        [TestMethod]
        public void testUpdateReport1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.updateReport(1, "Complete", 3);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateReport2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.updateReport(0, "Complete", 3);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateReport3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.updateReport(1, null, 3);

            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------ViewPreviousReport------------
        [TestMethod]
        public void testViewPreviousReport1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //CAMTUSerModel Technician
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 2;
            camtUserModel1.user_username = "staff1";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "staff one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "113";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 2;
            camtUserModel1.user_active = true;

            //CAMTUSerModel Reporter
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 4;
            camtUserModel2.user_username = "reporter1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "reporter one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "114";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 3;
            camtUserModel2.user_active = true;

            //Item
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 1;
            itemModel1.item_brand = "Apple";
            itemModel1.item_name = "iMac";
            itemModel1.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel1.item_startDate = dateTimeStart1;

            string dateEnd1 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);
            itemModel1.item_endDate = dateTimeEnd1;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-1.jpg";
            itemModel1.item_cmuNumber = "CMU01";
            itemModel1.item_camtNumber = "CAMT01";
            itemModel1.item_serialNumber = "";

            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //Report
            ReportModel reportModel1 = new ReportModel();
            reportModel1.report_id = 2;
            reportModel1.technician_id = camtUserModel1;
            reportModel1.reporter_id = camtUserModel2;
            reportModel1.item_id = itemModel1;
            reportModel1.report_typeBroken = "Error about Application of Computer";
            reportModel1.report_case = "Cannot open iPhoto";
            reportModel1.report_contact = "0833201787";
            reportModel1.report_repairDetail = "Complete";

            string dateStart2 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            reportModel1.report_startDate = dateTimeStart2;

            string dateEnd2 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            reportModel1.report_endDate = dateTimeEnd2;

            reportModel1.report_statusComplete = 3;
            reportModel1.report_recieveMsg = true;

            //Act
            var actual = reportModel.viewPreviousReport(4);

            //Assert
            Assert.AreEqual(reportModel1, actual);
        }

        [TestMethod]
        public void testViewPreviousReport2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            ReportModel reportModel1 = new ReportModel();


            //Act
            var actual = reportModel.viewPreviousReport(0);

            //Assert
            Assert.AreEqual(reportModel1, actual);
        }

        //-----------------viewReportbyReporterId------------
        [TestMethod]
        public void testViewReportbyReporterId1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //CAMTUSerModel Technician
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 2;
            camtUserModel1.user_username = "staff1";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "staff one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "113";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 2;
            camtUserModel1.user_active = true;

            //CAMTUSerModel Reporter
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 4;
            camtUserModel2.user_username = "reporter1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "reporter one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "114";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 3;
            camtUserModel2.user_active = true;

            //Item
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 1;
            itemModel1.item_brand = "Apple";
            itemModel1.item_name = "iMac";
            itemModel1.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel1.item_startDate = dateTimeStart1;

            string dateEnd1 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);
            itemModel1.item_endDate = dateTimeEnd1;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-1.jpg";
            itemModel1.item_cmuNumber = "CMU01";
            itemModel1.item_camtNumber = "CAMT01";
            itemModel1.item_serialNumber = "";

            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //Report1
            ReportModel reportModel1 = new ReportModel();
            reportModel1.report_id = 1;
            reportModel1.technician_id = camtUserModel1;
            reportModel1.reporter_id = camtUserModel2;
            reportModel1.item_id = itemModel1;
            reportModel1.report_typeBroken = "Error about Application of Computer";
            reportModel1.report_case = "Cannot open Keynote";
            reportModel1.report_contact = "0833201787";
            reportModel1.report_repairDetail = "Complete";

            string dateStart2 = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            reportModel1.report_startDate = dateTimeStart2;

            string dateEnd2 = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            reportModel1.report_endDate = dateTimeEnd2;
            reportModel1.report_statusComplete = 3;
            reportModel1.report_recieveMsg = true;

            //Report2
            ReportModel reportModel2 = new ReportModel();
            reportModel2.report_id = 2;
            reportModel2.technician_id = camtUserModel1;
            reportModel2.reporter_id = camtUserModel2;
            reportModel2.item_id = itemModel1;
            reportModel2.report_typeBroken = "Error about Application of Computer";
            reportModel2.report_case = "Cannot open iPhoto";
            reportModel2.report_contact = "0833201787";
            reportModel2.report_repairDetail = "Complete";

            string dateStart3 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart3 = Convert.ToDateTime(dateStart3);
            reportModel2.report_startDate = dateTimeStart3;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            reportModel2.report_endDate = dateTimeEnd3;

            reportModel2.report_statusComplete = 3;
            reportModel2.report_recieveMsg = true;

            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList.Add(reportModel1);
            reportModelList.Add(reportModel2);

            //Act
            var actual = reportModel.viewReportbyReporterId(4);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
          //  Assert.AreEqual(reportModel1, actual);
        }

        [TestMethod]
        public void testViewReportbyReporterId2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();

            //Act
            var actual = reportModel.viewReportbyReporterId(0);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
            //  Assert.AreEqual(reportModel1, actual);
        }



        //-----------------viewReportByStatusAndUserId------------
        [TestMethod]
        public void testVewReportByStatusAndUserId1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //CAMTUSerModel Technician
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 2;
            camtUserModel1.user_username = "staff1";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "staff one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "113";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 2;
            camtUserModel1.user_active = true;

            //CAMTUSerModel Reporter
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 4;
            camtUserModel2.user_username = "reporter1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "reporter one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "114";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 3;
            camtUserModel2.user_active = true;

            //Item
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 1;
            itemModel1.item_brand = "Apple";
            itemModel1.item_name = "iMac";
            itemModel1.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel1.item_startDate = dateTimeStart1;

            string dateEnd1 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);
            itemModel1.item_endDate = dateTimeEnd1;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-1.jpg";
            itemModel1.item_cmuNumber = "CMU01";
            itemModel1.item_camtNumber = "CAMT01";
            itemModel1.item_serialNumber = "";

            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //Report1
            ReportModel reportModel1 = new ReportModel();
            reportModel1.report_id = 1;
            reportModel1.technician_id = camtUserModel1;
            reportModel1.reporter_id = camtUserModel2;
            reportModel1.item_id = itemModel1;
            reportModel1.report_typeBroken = "Error about Application of Computer";
            reportModel1.report_case = "Cannot open Keynote";
            reportModel1.report_contact = "0833201787";
            reportModel1.report_repairDetail = "Complete";

            string dateStart2 = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            reportModel1.report_startDate = dateTimeStart2;

            string dateEnd2 = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            reportModel1.report_endDate = dateTimeEnd2;
            reportModel1.report_statusComplete = 3;
            reportModel1.report_recieveMsg = true;

            //Report2
            ReportModel reportModel2 = new ReportModel();
            reportModel2.report_id = 2;
            reportModel2.technician_id = camtUserModel1;
            reportModel2.reporter_id = camtUserModel2;
            reportModel2.item_id = itemModel1;
            reportModel2.report_typeBroken = "Error about Application of Computer";
            reportModel2.report_case = "Cannot open iPhoto";
            reportModel2.report_contact = "0833201787";
            reportModel2.report_repairDetail = "Complete";

            string dateStart3 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart3 = Convert.ToDateTime(dateStart3);
            reportModel2.report_startDate = dateTimeStart3;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            reportModel2.report_endDate = dateTimeEnd3;

            reportModel2.report_statusComplete = 3;
            reportModel2.report_recieveMsg = true;

            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList.Add(reportModel1);
            reportModelList.Add(reportModel2);

            //Act
            var actual = reportModel.viewReportByStatusAndUserId(2,3);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
            //  Assert.AreEqual(reportModel1, actual);
        }

        [TestMethod]
        public void testVewReportByStatusAndUserId2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();

            //Act
            var actual = reportModel.viewReportByStatusAndUserId(0, 3);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
            //  Assert.AreEqual(reportModel1, actual);
        }

        //-----------------viewReportByTechnicianId------------
        //----- case นี้มี orderby-------
        [TestMethod]
        public void testViewReportByTechnicianId1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //CAMTUSerModel Technician
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 2;
            camtUserModel1.user_username = "staff1";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "staff one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "113";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 2;
            camtUserModel1.user_active = true;

            //CAMTUSerModel Reporter
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 4;
            camtUserModel2.user_username = "reporter1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "reporter one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "114";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 3;
            camtUserModel2.user_active = true;

            //Item
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 1;
            itemModel1.item_brand = "Apple";
            itemModel1.item_name = "iMac";
            itemModel1.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel1.item_startDate = dateTimeStart1;

            string dateEnd1 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);
            itemModel1.item_endDate = dateTimeEnd1;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-1.jpg";
            itemModel1.item_cmuNumber = "CMU01";
            itemModel1.item_camtNumber = "CAMT01";
            itemModel1.item_serialNumber = "";

            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //Report1
            ReportModel reportModel1 = new ReportModel();
            reportModel1.report_id = 1;
            reportModel1.technician_id = camtUserModel1;
            reportModel1.reporter_id = camtUserModel2;
            reportModel1.item_id = itemModel1;
            reportModel1.report_typeBroken = "Error about Application of Computer";
            reportModel1.report_case = "Cannot open Keynote";
            reportModel1.report_contact = "0833201787";
            reportModel1.report_repairDetail = "Complete";

            string dateStart2 = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            reportModel1.report_startDate = dateTimeStart2;

            string dateEnd2 = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            reportModel1.report_endDate = dateTimeEnd2;
            reportModel1.report_statusComplete = 3;
            reportModel1.report_recieveMsg = true;

            //Report2
            ReportModel reportModel2 = new ReportModel();
            reportModel2.report_id = 2;
            reportModel2.technician_id = camtUserModel1;
            reportModel2.reporter_id = camtUserModel2;
            reportModel2.item_id = itemModel1;
            reportModel2.report_typeBroken = "Error about Application of Computer";
            reportModel2.report_case = "Cannot open iPhoto";
            reportModel2.report_contact = "0833201787";
            reportModel2.report_repairDetail = "Complete";

            string dateStart3 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart3 = Convert.ToDateTime(dateStart3);
            reportModel2.report_startDate = dateTimeStart3;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            reportModel2.report_endDate = dateTimeEnd3;

            reportModel2.report_statusComplete = 3;
            reportModel2.report_recieveMsg = true;

            List<ReportModel> reportModelList = new List<ReportModel>();
            reportModelList.Add(reportModel2);
            reportModelList.Add(reportModel1);

            //Act
            var actual = reportModel.viewReportByTechnicianId(2);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
            //  Assert.AreEqual(reportModel1, actual);
        }

        [TestMethod]
        public void testViewReportByTechnicianId2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            List<ReportModel> reportModelList = new List<ReportModel>();

            //Act
            var actual = reportModel.viewReportByTechnicianId(0);

            //Assert
            CollectionAssert.AreEqual(reportModelList, actual);
            //  Assert.AreEqual(reportModel1, actual);
        }

        //-----------------updateRepairingStatus------------
        [TestMethod]
        public void testUpdateRepairingStatus1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.updateRepairingStatus(1,3);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateRepairingStatus2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            var actual = reportModel.updateRepairingStatus(0, 3);

            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------ViewReportByReportId------------
        [TestMethod]
        public void testViewReportByReportId1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //CAMTUSerModel Technician
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 2;
            camtUserModel1.user_username = "staff1";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "staff one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "113";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 2;
            camtUserModel1.user_active = true;

            //CAMTUSerModel Reporter
            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 4;
            camtUserModel2.user_username = "reporter1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "reporter one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "114";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 3;
            camtUserModel2.user_active = true;

            //Item
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 1;
            itemModel1.item_brand = "Apple";
            itemModel1.item_name = "iMac";
            itemModel1.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel1.item_startDate = dateTimeStart1;

            string dateEnd1 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);
            itemModel1.item_endDate = dateTimeEnd1;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-1.jpg";
            itemModel1.item_cmuNumber = "CMU01";
            itemModel1.item_camtNumber = "CAMT01";
            itemModel1.item_serialNumber = "";

            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //Report
            ReportModel reportModel1 = new ReportModel();
            reportModel1.report_id = 2;
            reportModel1.technician_id = camtUserModel1;
            reportModel1.reporter_id = camtUserModel2;
            reportModel1.item_id = itemModel1;
            reportModel1.report_typeBroken = "Error about Application of Computer";
            reportModel1.report_case = "Cannot open iPhoto";
            reportModel1.report_contact = "0833201787";
            reportModel1.report_repairDetail = "Complete";

            string dateStart2 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            reportModel1.report_startDate = dateTimeStart2;

            string dateEnd2 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            reportModel1.report_endDate = dateTimeEnd2;

            reportModel1.report_statusComplete = 3;
            reportModel1.report_recieveMsg = true;

            //Act
            var actual = reportModel.viewReportByReportId(2);

            //Assert
            Assert.AreEqual(reportModel1, actual);
        }

        [TestMethod]
        public void testViewReportByReportId2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();

            //Report
            ReportModel reportModel1 = new ReportModel();
            //Act
            var actual = reportModel.viewReportByReportId(0);

            //Assert
            Assert.AreEqual(reportModel1.report_id, actual.report_id);
        }


       
    }
}
