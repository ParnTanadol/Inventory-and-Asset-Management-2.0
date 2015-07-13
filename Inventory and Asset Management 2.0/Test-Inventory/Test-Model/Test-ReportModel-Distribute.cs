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
    /// Summary description for Test_ReportModel_Distribute
    /// </summary>
    [TestClass]
    public class Test_ReportModel_Distribute
    {
        private Appendix appendixA = new Appendix();
        //-----------------distributeWork------------
        [TestMethod]
        public void testDistributeWork1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act

            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.distributeWork(1, "Error about Application of Computer");

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testDistributeWork2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.distributeWork(0, "Error about Application of Computer");

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testDistributeWork3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.distributeWork(1, null);

            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------randomTechnician------------

        // test case ไม่มี technician
        [TestMethod]
        public void testRandomTechnician1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();

            appendixA.addItem();
            appendixA.addItemOwner();

            var actual = reportModel.randomTechnician("Error about Application of Computer");

            //Assert
            Assert.AreEqual(1, actual);
        }

        // test case technician ไม่มีใครเคยทำงานชนิดนั้นเลย
        [TestMethod]
        public void testRandomTechnician2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
           // appendixA.addReport();

            var actual = reportModel.randomTechnician("Error about Application of Computer");

            //Assert
            if (actual == 2)
            {
                Assert.AreEqual(2, actual);
            }
            else
            {
                Assert.AreEqual(3, actual);
            }
        }

        // test case technician มีคนที่บางคนที่ไม่เคยทำงานนั้นเลย
        [TestMethod]
        public void testRandomTechnician3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.randomTechnician("Error about Application of Computer");

            //Assert
            Assert.AreEqual(3, actual);

        }

        // test case technician มีคนเคยทำงานชนินั้น น้อยกว่า 2 ครั้ง
        [TestMethod]
        public void testRandomTechnician4()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport2();

            var actual = reportModel.randomTechnician("Error about Application of Computer");
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            Assert.AreEqual(3, actual);

        }

        // test case technician ทุกคนมีเวลาจบงานท่ากัน
        [TestMethod]
        public void testRandomTechnician5()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport3();

            var actual = reportModel.randomTechnician("Error about Application of Computer");
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            if (actual == 2)
            {
                Assert.AreEqual(2, actual);
            }
            else
            {
                Assert.AreEqual(3, actual);
            }

        }

        // test case มี technician ที่ทำงานน้อยที่สุด
        [TestMethod]
        public void testRandomTechnician6()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport4();

            var actual = reportModel.randomTechnician("Error about Application of Computer");
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            Assert.AreEqual(2, actual);

        }

        //-----------------resetDistributeWork------------
        [TestMethod]
        public void testResetDistributeWork1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act

            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.resetDistributeWork(1, "Error about Application of Computer",2);

            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testResetDistributeWork2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act

            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.resetDistributeWork(0, "Error about Application of Computer", 2);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testResetDistributeWork3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act

            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.resetDistributeWork(1, null, 2);

            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------resetRandomTechnician------------

        // test case ไม่มี technician
        [TestMethod]
        public void testResetRandomTechnician1()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();

            appendixA.addItem();
            appendixA.addItemOwner();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",2);

            //Assert
            Assert.AreEqual(1, actual);
        }

        // test case technician ไม่มีใครเคยทำงานชนิดนั้นเลย
        [TestMethod]
        public void testResetRandomTechnician2()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            // appendixA.addReport();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",2);

            //Assert
            Assert.AreEqual(3, actual);
        }

        // test case technician มีคนที่บางคนที่ไม่เคยทำงานนั้นเลย
        [TestMethod]
        public void testResetRandomTechnician3()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",1);

            //Assert
            Assert.AreEqual(3, actual);

        }

        // test case technician มีคนเคยทำงานชนินั้น น้อยกว่า 2 ครั้ง
        [TestMethod]
        public void testResetRandomTechnician4()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport2();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",1);
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            Assert.AreEqual(3, actual);

        }

        // test case technician ทุกคนมีเวลาจบงานเท่ากัน
        [TestMethod]
        public void testResetRandomTechnician5()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport3();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",1);
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            //Assert
            if (actual == 2)
            {
                Assert.AreEqual(2, actual);
            }
            else
            {
                Assert.AreEqual(3, actual);
            }

        }

        // test case มี technician ที่ทำงานน้อยที่สุด
        [TestMethod]
        public void testResetRandomTechnician6()
        {
            // Arrange
            ReportModel reportModel = new ReportModel();
            //Act
            appendixA.deleteReport();
            appendixA.deleteItemOwner();
            appendixA.deleteItem();
            appendixA.deleteCAMTUser();
            appendixA.addCAMTUser();
            appendixA.addItem();
            appendixA.addItemOwner();
            appendixA.addReport4();

            var actual = reportModel.resetRandomTechnician("Error about Application of Computer",1);
            appendixA.deleteReport();
            appendixA.addReport();
            //Assert
            Assert.AreEqual(2, actual);

        }
    }
}
