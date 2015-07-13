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
    /// Summary description for Test_ItemModel
    /// </summary>
    [TestClass]
    public class Test_ItemModel
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

        //-----------------insertItem------------
        [TestMethod]
        public void testInsertItem1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);

            //Act
            var actual = itemModel.insertItem("Apple", "iMac", "iMac 27-inch", dateTimeStart, dateTimeEnd, 1, "CMU01", "CAMT01", "",null);
            //Assert
            Assert.IsTrue(actual);
        }

        //-----------------updateItem------------
        [TestMethod]
        public void testUpdateItem1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);

            //Act
            var actual = itemModel.updateItem(1, "Apple", "iMac", "iMac 27-inch", dateTimeStart, dateTimeEnd, 1, "picItem-1.jpg", "CMU01", "CAMT01", "", null);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateItem2()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);

            //Act
            var actual = itemModel.updateItem(0, "Apple", "iMac", "iMac 27-inch", dateTimeStart, dateTimeEnd, 1, "picItem-1.jpg", "CMU01", "CAMT01", "", null);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------removeComponent------------
        [TestMethod]
        public void testRemoveComponent1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            //Act
            var actual = itemModel.removeComponent(1);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testRemoveComponent2()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            //Act
            var actual = itemModel.removeComponent(0);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------viewPreviousItem------------
        [TestMethod]
        public void testViewPreviousItem1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();
            // itemModel1
            ItemModel itemModel1 = new ItemModel();
            itemModel1.item_id = 3;
            itemModel1.item_brand = "Intel";
            itemModel1.item_name = "CPU Iris";
            itemModel1.item_description = "CPU Iris core-i7";

            string dateStart = "2015-06-29 02:21:04.1492112";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            itemModel1.item_startDate = dateTimeStart;

            string dateEnd = "2015-08-20 12:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            itemModel1.item_endDate = dateTimeEnd;

            itemModel1.item_status = 1;
            itemModel1.item_picture = "picItem-3.jpg";
            itemModel1.item_cmuNumber = "";
            itemModel1.item_camtNumber = "";
            itemModel1.item_serialNumber = "Serial03";

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 1;
            itemModel2.item_brand = "Apple";
            itemModel2.item_name = "iMac";
            itemModel2.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel2.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-1.jpg";
            itemModel2.item_cmuNumber = "CMU01";
            itemModel2.item_camtNumber = "CAMT01";
            itemModel2.item_serialNumber = "";
            
            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;
            itemModel1.item_component = itemModel2;


            //Act
            var actual = itemModel.viewPreviousItem();
            //Assert
            Assert.AreEqual(itemModel1, actual);
        }

        //-----------------viewItemModelByItemId------------
        [TestMethod]
        public void testViewItemModelByItemId1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 1;
            itemModel2.item_brand = "Apple";
            itemModel2.item_name = "iMac";
            itemModel2.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel2.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-1.jpg";
            itemModel2.item_cmuNumber = "CMU01";
            itemModel2.item_camtNumber = "CAMT01";
            itemModel2.item_serialNumber = "";

            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;

            //Act
            var actual = itemModel.viewItemModelByItemId(1);
            //Assert
            Assert.AreEqual(itemModel2, actual);
        }

        [TestMethod]
        public void testViewItemModelByItemId2()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;

            //Act
            var actual = itemModel.viewItemModelByItemId(0);
            //Assert
            Assert.AreEqual(itemModel2, actual);
        }

        //-----------------viewItemModelbySerialNum------------
        [TestMethod]
        public void testViewItemModelbySerialNumd1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 1;
            itemModel2.item_brand = "Apple";
            itemModel2.item_name = "iMac";
            itemModel2.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel2.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-1.jpg";
            itemModel2.item_cmuNumber = "CMU01";
            itemModel2.item_camtNumber = "CAMT01";
            itemModel2.item_serialNumber = "";

            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;

            //Act
            var actual = itemModel.viewItemModelbySerialNum("CMU01");
            //Assert
            Assert.AreEqual(itemModel2, actual);
        }

        //-----------------viewItemModelbySerialNum------------
        [TestMethod]
        public void testViewItemModelbySerialNumd2()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;

            //Act
            var actual = itemModel.viewItemModelbySerialNum("CMU02");
            //Assert
            Assert.AreEqual(itemModel2, actual);
        }

        //-----------------viewExpireItem------------
        [TestMethod]
        public void testViewExpireItem1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 1;
            itemModel2.item_brand = "Apple";
            itemModel2.item_name = "iMac";
            itemModel2.item_description = "iMac 27-inch";

            string dateStart1 = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            itemModel2.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-1.jpg";
            itemModel2.item_cmuNumber = "CMU01";
            itemModel2.item_camtNumber = "CAMT01";
            itemModel2.item_serialNumber = "";

            ItemModel itemModel3 = new ItemModel();
            itemModel2.item_component = itemModel3;

            List<ItemModel> itemModelList = new List<ItemModel>();
            itemModelList.Add(itemModel2);
            //-----------------date time input--------
            string dateStart = "2015-06-19 00:00:00.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);

            string dateEnd = "2015-06-21 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);

            //Act
            var actual = itemModel.viewExpireItem(dateTimeStart, dateTimeEnd);
            //Assert
            CollectionAssert.AreEqual(itemModelList, actual);
        }

        [TestMethod]
        public void testViewExpireItem2()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();
            List<ItemModel> itemModelList = new List<ItemModel>();

            //-----------------date time input--------
            string dateStart = "2015-06-17 00:00:00.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);

            string dateEnd = "2015-06-18 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);

            //Act
            var actual = itemModel.viewExpireItem(dateTimeStart, dateTimeEnd);
            //Assert
            CollectionAssert.AreEqual(itemModelList, actual);
        }

        //-----------------viewGroupByItemBrand------------
        [TestMethod]
        public void testViewGroupByItemBrand1()
        {
            // Arrange
            ItemModel itemModel = new ItemModel();

            List<string> groupList = new List<string>();
            groupList.Add("Apple");
            groupList.Add("Intel");
            groupList.Add("RAM Thailand");

            //Act
            var actual = itemModel.viewGroupByItemBrand();
            //Assert
            CollectionAssert.AreEqual(groupList, actual);
        }



         
    }
}
