using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0;

namespace Test_Inventory.Test_Repositories
{

    [TestClass]
    public class Test_ReportRepo
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

        //---------------------insertReport---------------------
        [TestMethod]
        public void testInsertReport1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testInsertReport2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = null;
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport3()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = null;
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport4()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = null;
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport5()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = null;


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport6()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 0;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport7()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 0;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertReport8()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 0;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.insertReport(report);
            //Assert
            Assert.IsFalse(actual);
        }



        //---------------------updateReport---------------------
        [TestMethod]
        public void testUpdateReport1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.report_repairDetail = "Complete";
            report.report_statusComplete = 3;

            //Act
            var actual = reportRepo.updateReport(report);
            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void testUpdateReport2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 0;
            report.report_repairDetail = "Complete";
            report.report_statusComplete = 3;

            //Act
            var actual = reportRepo.updateReport(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateReport3()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.report_repairDetail = null;
            report.report_statusComplete = 3;

            //Act
            var actual = reportRepo.updateReport(report);
            //Assert
            Assert.IsFalse(actual);
        }


        //---------------------viewReportByReportId---------------------
        [TestMethod]
        public void testViewReportByReportId1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open Keynote";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.viewReportByReportId(1);
            //Assert
            Assert.AreEqual(report,actual);
        }

        [TestMethod]
        public void testViewReportByReportId2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            //Act
            var actual = reportRepo.viewReportByReportId(0);
            //Assert
            Assert.AreEqual(report, actual);
        }

        //---------------------viewReportbyTechnicianId---------------------
        [TestMethod]
        public void testViewReportbyTechnicianIdd1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report1 = new Report();
            report1.report_id = 1;
            report1.technician_id = 2;
            report1.reporter_id = 4;
            report1.item_id = 1;
            report1.report_typeBroken = "Error about Application of Computer";
            report1.report_case = "Cannot open Keynote";
            report1.report_contact = "0833201787";
            report1.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report1.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report1.report_endDate = dateTimeEnd;

            report1.report_statusComplete = 3;
            report1.report_recieveMsg = true;

            Report report2 = new Report();
            report2.report_id = 2;
            report2.technician_id = 2;
            report2.reporter_id = 4;
            report2.item_id = 1;
            report2.report_typeBroken = "Error about Application of Computer";
            report2.report_case = "Cannot open iPhoto";
            report2.report_contact = "0833201787";
            report2.report_repairDetail = "Complete";


            string dateStart2 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            report2.report_startDate = dateTimeStart2;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            report2.report_endDate = dateTimeEnd3;

            report2.report_statusComplete = 3;
            report2.report_recieveMsg = true;

            List<Report> reportList = new List<Report>();
            reportList.Add(report2);
            reportList.Add(report1);

            //Act
            var actual = reportRepo.viewReportbyTechnicianId(2);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        [TestMethod]
        public void testViewReportbyTechnicianIdd2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<Report> reportList = new List<Report>();


            //Act
            var actual = reportRepo.viewReportbyTechnicianId(0);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        //---------------------viewReportbyReporterId---------------------
        [TestMethod]
        public void testViewReportbyReporterId1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report1 = new Report();
            report1.report_id = 1;
            report1.technician_id = 2;
            report1.reporter_id = 4;
            report1.item_id = 1;
            report1.report_typeBroken = "Error about Application of Computer";
            report1.report_case = "Cannot open Keynote";
            report1.report_contact = "0833201787";
            report1.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report1.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report1.report_endDate = dateTimeEnd;

            report1.report_statusComplete = 3;
            report1.report_recieveMsg = true;

            Report report2 = new Report();
            report2.report_id = 2;
            report2.technician_id = 2;
            report2.reporter_id = 4;
            report2.item_id = 1;
            report2.report_typeBroken = "Error about Application of Computer";
            report2.report_case = "Cannot open iPhoto";
            report2.report_contact = "0833201787";
            report2.report_repairDetail = "Complete";


            string dateStart2 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            report2.report_startDate = dateTimeStart2;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            report2.report_endDate = dateTimeEnd3;

            report2.report_statusComplete = 3;
            report2.report_recieveMsg = true;

            List<Report> reportList = new List<Report>();
            reportList.Add(report1);
            reportList.Add(report2);

            //Act
            var actual = reportRepo.viewReportbyReporterId(4);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        [TestMethod]
        public void testViewReportbyReporterId2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<Report> reportList = new List<Report>();


            //Act
            var actual = reportRepo.viewReportbyReporterId(0);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        //---------------------viewReportByStatusAndUserId---------------------
        [TestMethod]
        public void testViewReportByStatusAndUserId1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report1 = new Report();
            report1.report_id = 1;
            report1.technician_id = 2;
            report1.reporter_id = 4;
            report1.item_id = 1;
            report1.report_typeBroken = "Error about Application of Computer";
            report1.report_case = "Cannot open Keynote";
            report1.report_contact = "0833201787";
            report1.report_repairDetail = "Complete";


            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report1.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-10 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report1.report_endDate = dateTimeEnd;

            report1.report_statusComplete = 3;
            report1.report_recieveMsg = true;

            Report report2 = new Report();
            report2.report_id = 2;
            report2.technician_id = 2;
            report2.reporter_id = 4;
            report2.item_id = 1;
            report2.report_typeBroken = "Error about Application of Computer";
            report2.report_case = "Cannot open iPhoto";
            report2.report_contact = "0833201787";
            report2.report_repairDetail = "Complete";


            string dateStart2 = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            report2.report_startDate = dateTimeStart2;

            string dateEnd3 = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            report2.report_endDate = dateTimeEnd3;

            report2.report_statusComplete = 3;
            report2.report_recieveMsg = true;

            List<Report> reportList = new List<Report>();
            reportList.Add(report1);
            reportList.Add(report2);

            //Act
            var actual = reportRepo.viewReportByStatusAndUserId(2,3);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        [TestMethod]
        public void testViewReportByStatusAndUserId2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<Report> reportList = new List<Report>();

            //Act
            var actual = reportRepo.viewReportByStatusAndUserId(0, 3);
            //Assert
            CollectionAssert.AreEqual(reportList, actual);
        }

        //---------------------viewPreviousReport---------------------
        [TestMethod]
        public void testViewPreviousReport1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            Report report = new Report();
            report.report_id = 2;
            report.technician_id = 2;
            report.reporter_id = 4;
            report.item_id = 1;
            report.report_typeBroken = "Error about Application of Computer";
            report.report_case = "Cannot open iPhoto";
            report.report_contact = "0833201787";
            report.report_repairDetail = "Complete";


            string dateStart = "2015-06-11 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            string dateEnd = "2015-06-12 15:36:48.3488602";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            report.report_endDate = dateTimeEnd;

            report.report_statusComplete = 3;
            report.report_recieveMsg = true;

            //Act
            var actual = reportRepo.viewPreviousReport(4);
            //Assert
            Assert.AreEqual(report, actual);
        }


        //---------------------updateStatus---------------------
        [TestMethod]
        public void testUpdateStatus1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            Report report = new Report();
            report.report_id = 1;
            report.report_statusComplete = 3;

            //Act
            var actual = reportRepo.updateStatus(report);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateStatus2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            Report report = new Report();
            report.report_id = 0;
            report.report_statusComplete = 3;

            //Act
            var actual = reportRepo.updateStatus(report);
            //Assert
            Assert.IsFalse(actual);
        }


        //---------------------updateTypeBroken---------------------
        [TestMethod]
        public void testUpdateTypeBroken1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.technician_id = 2;
            report.report_typeBroken = "Error about Application of Computer";

            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            report.report_statusComplete = 3;


            //Act
            var actual = reportRepo.updateTypeBroken(report);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateTypeBroken2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 0;
            report.technician_id = 2;
            report.report_typeBroken = "Error about Application of Computer";

            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            report.report_statusComplete = 3;


            //Act
            var actual = reportRepo.updateTypeBroken(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateTypeBroken3()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.technician_id = 0;
            report.report_typeBroken = "Error about Application of Computer";

            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            report.report_statusComplete = 3;


            //Act
            var actual = reportRepo.updateTypeBroken(report);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateTypeBroken4()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());
            Report report = new Report();
            report.report_id = 1;
            report.technician_id = 2;
            report.report_typeBroken = null;

            string dateStart = "2015-06-09 15:36:48.3488602";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            report.report_startDate = dateTimeStart;

            report.report_statusComplete = 3;


            //Act
            var actual = reportRepo.updateTypeBroken(report);
            //Assert
            Assert.IsFalse(actual);
        }

        //---------------------viewExperienceTechnician---------------------
        [TestMethod]
        public void testViewExperienceTechnician1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            //Act
            var actual = reportRepo.viewExperienceTechnician(2);
            //Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void testViewExperienceTechnician2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            //Act
            var actual = reportRepo.viewExperienceTechnician(0);
            //Assert
            Assert.AreEqual(0, actual);
        }

        //---------------------viewTechnicianTask---------------------
        [TestMethod]
        public void testViewTechnicianTask1()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<List<int>> technicianTaskList = new List<List<int>>();
            List<int> technicianTask = new List<int> { 2,2};
            technicianTaskList.Add(technicianTask);
            //Act
            var actual = reportRepo.viewTechnicianTask("Error about Application of Computer");
            //Assert
            CollectionAssert.AreEqual(technicianTaskList[0], actual[0]);
        }

        [TestMethod]
        public void testViewTechnicianTask2()
        {
            // Arrange
            IReportRepo reportRepo = new ReportRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<List<int>> technicianTaskList = new List<List<int>>();

            //Act
            var actual = reportRepo.viewTechnicianTask(null);
            //Assert
            Assert.AreEqual(actual.Count, technicianTaskList.Count);
        }

    }
}
