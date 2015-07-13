using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0;
namespace Test_Inventory.Test_Repositories
{
    /// <summary>
    /// Summary description for Test_ItemRepo
    /// </summary>
    [TestClass]
    public class Test_ItemRepo
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

        //---------------------insertItem---------------------
        [TestMethod]
        public void testInsertCAMTUser1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = 1;

            //Act
            var actual = itemRepo.insertItem(item);
            //Assert
            Assert.IsTrue(actual);
        }


        //---------------------updateItem---------------------
        [TestMethod]
        public void testUpdateItem1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;

            //Act
            var actual = itemRepo.updateItem(item);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateItem2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 0;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;

            //Act
            var actual = itemRepo.updateItem(item);
            //Assert
            Assert.IsFalse(actual);
        }

        //---------------------updateItemComponent---------------------
        [TestMethod]
        public void testUpdateItemComponent1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_component = 2;

            //Act
            var actual = itemRepo.updateItemComponent(item);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateItemComponent2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 0;
            item.item_component = 2;

            //Act
            var actual = itemRepo.updateItemComponent(item);
            //Assert
            Assert.IsFalse(actual);
        }

        //---------------------viewItemByitemId---------------------
        [TestMethod]
        public void testViewItemByitemId1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;

            //Act
            var actual = itemRepo.viewItemByitemId(1);
            //Assert
            Assert.AreEqual(item, actual);
        }

        [TestMethod]
        public void testViewItemByitemId2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();

            //Act
            var actual = itemRepo.viewItemByitemId(0);
            //Assert
            Assert.AreEqual(item, actual);
        }

        //---------------------viewPreviousItem---------------------
        [TestMethod]
        public void testViewPreviousItem1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 3;
            item.item_brand = "Intel";
            item.item_name = "CPU Iris";
            item.item_description = "CPU Iris core-i7";

            string dateStart = "2015-06-29 02:21:04.1492112";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-08-20 12:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-3.jpg";
            item.item_cmuNumber = "";
            item.item_camtNumber = "";
            item.item_serialNumber = "Serial03";
            item.item_component = 1;

            //Act
            var actual = itemRepo.viewPreviousItem();
            //Assert
            Assert.AreEqual(item, actual);
        }

        //---------------------viewItemComponentbyItemId---------------------
        [TestMethod]
        public void testViewItemComponentbyItemId1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());

            Item item1 = new Item();
            item1.item_id = 2;
            item1.item_brand = "RAM Thailand";
            item1.item_name = "RAM";
            item1.item_description = "RAM";

            string dateStart1 = "2015-05-07 15:35:51.6317728";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            item1.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-07-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            item1.item_endDate = dateTimeEnd2;

            item1.item_status = 1;
            item1.item_picture = "picItem-2.jpg";
            item1.item_cmuNumber = "";
            item1.item_camtNumber = "";
            item1.item_serialNumber = "Serial02";
            item1.item_component = 1;

            Item item2 = new Item();
            item2.item_id = 3;
            item2.item_brand = "Intel";
            item2.item_name = "CPU Iris";
            item2.item_description = "CPU Iris core-i7";

            string dateStart = "2015-06-29 02:21:04.1492112";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item2.item_startDate = dateTimeStart;

            string dateEnd = "2015-08-20 12:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item2.item_endDate = dateTimeEnd;

            item2.item_status = 1;
            item2.item_picture = "picItem-3.jpg";
            item2.item_cmuNumber = "";
            item2.item_camtNumber = "";
            item2.item_serialNumber = "Serial03";
            item2.item_component = 1;

            List<Item> itemList = new List<Item>();
            itemList.Add(item1);
            itemList.Add(item2);

            //Act
            var actual = itemRepo.viewItemComponentbyItemId(1);
            //Assert
            CollectionAssert.AreEqual(itemList, actual);
        }

        [TestMethod]
        public void testViewItemComponentbyItemId2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<Item> itemList = new List<Item>();

            //Act
            var actual = itemRepo.viewItemComponentbyItemId(0);
            //Assert
            CollectionAssert.AreEqual(itemList, actual);
        }

        //---------------------viewGroupByItemBrand---------------------
        [TestMethod]
        public void testViewGroupByItemBrand1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            List<string> groupList = new List<string>();
            groupList.Add("Apple");
            groupList.Add("Intel");
            groupList.Add("RAM Thailand");
            //Act
            var actual = itemRepo.viewGroupByItemBrand();
            //Assert
            CollectionAssert.AreEqual(groupList, actual);
        }

        //---------------------viewItemModelbySerialNum---------------------
        [TestMethod]
        public void testViewItemModelbySerialNum1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;
            //Act
            var actual = itemRepo.viewItemModelbySerialNum("CMU01");
            //Assert
            Assert.AreEqual(item, actual);
        }

        [TestMethod]
        public void testViewItemModelbySerialNum2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;
            //Act
            var actual = itemRepo.viewItemModelbySerialNum("CAMT01");
            //Assert
            Assert.AreEqual(item, actual);
        }


        [TestMethod]
        public void testViewItemModelbySerialNum3()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item1 = new Item();
            item1.item_id = 2;
            item1.item_brand = "RAM Thailand";
            item1.item_name = "RAM";
            item1.item_description = "RAM";

            string dateStart1 = "2015-05-07 15:35:51.6317728";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);
            item1.item_startDate = dateTimeStart1;

            string dateEnd2 = "2015-07-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            item1.item_endDate = dateTimeEnd2;

            item1.item_status = 1;
            item1.item_picture = "picItem-2.jpg";
            item1.item_cmuNumber = "";
            item1.item_camtNumber = "";
            item1.item_serialNumber = "Serial02";
            item1.item_component = 1;
            //Act
            var actual = itemRepo.viewItemModelbySerialNum("Serial02");
            //Assert
            Assert.AreEqual(item1, actual);
        }

        [TestMethod]
        public void testViewItemModelbySerialNum4()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            //Act
            var actual = itemRepo.viewItemModelbySerialNum(null);
            //Assert
            Assert.AreEqual(item, actual);
        }

        //---------------------viewExpireItem---------------------
        [TestMethod]
        public void testViewExpireItem1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            Item item = new Item();
            item.item_id = 1;
            item.item_brand = "Apple";
            item.item_name = "iMac";
            item.item_description = "iMac 27-inch";

            string dateStart = "2015-05-07 15:35:35.0000000";
            DateTime dateTimeStart = Convert.ToDateTime(dateStart);
            item.item_startDate = dateTimeStart;

            string dateEnd = "2015-06-20 00:00:00.0000000";
            DateTime dateTimeEnd = Convert.ToDateTime(dateEnd);
            item.item_endDate = dateTimeEnd;

            item.item_status = 1;
            item.item_picture = "picItem-1.jpg";
            item.item_cmuNumber = "CMU01";
            item.item_camtNumber = "CAMT01";
            item.item_serialNumber = "";
            item.item_component = null;

            List<Item> itemList = new List<Item>();
            itemList.Add(item);

            //-----------------date time input--------
            string dateStart1 = "2015-06-19 00:00:00.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);

            string dateEnd1 = "2015-06-21 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);

            //Act
            var actual = itemRepo.viewExpireItem(dateTimeStart1, dateTimeEnd1);
            //Assert
            CollectionAssert.AreEqual(itemList, actual);
        }

        [TestMethod]
        public void testViewExpireItem2()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            List<Item> itemList = new List<Item>();

            //-----------------date time input--------
            string dateStart1 = "2015-06-17 00:00:00.0000000";
            DateTime dateTimeStart1 = Convert.ToDateTime(dateStart1);

            string dateEnd1 = "2015-06-18 00:00:00.0000000";
            DateTime dateTimeEnd1 = Convert.ToDateTime(dateEnd1);

            //Act
            var actual = itemRepo.viewExpireItem(dateTimeStart1, dateTimeEnd1);
            //Assert
            CollectionAssert.AreEqual(itemList, actual);
        }


        //---------------------viewOftenBrokenBrand---------------------
        [TestMethod]
        public void testViewOftenBrokenBrand1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            List<List<string>> itemList = new List<List<string>>();
            List<string> item = new List<string>();
            item.Add("Apple");
            item.Add("2");

            itemList.Add(item);
            //Act
            var actual = itemRepo.viewOftenBrokenBrand();
            //Assert
            CollectionAssert.AreEqual(itemList[0], actual[0]);
        }

        //---------------------viewOftenBrokenName---------------------
        [TestMethod]
        public void testViewOftenBrokenName1()
        {
            // Arrange
            IItemRepo itemRepo = new ItemRepo(new INVENTORY_MANAGEMENT_2Entities());
            List<List<string>> itemList = new List<List<string>>();
            List<string> item = new List<string>();
            item.Add("iMac");
            item.Add("2");

            itemList.Add(item);
            //Act
            var actual = itemRepo.viewOftenBrokenName();
            //Assert
            CollectionAssert.AreEqual(itemList[0], actual[0]);
        }


    }
}
