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
    /// Summary description for Test_ItemOwnerModel
    /// </summary>
    [TestClass]
    public class Test_ItemOwnerModel
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

        //-----------------insertItemOwner------------
        [TestMethod]
        public void testInsertItemOwner1()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.insertItemOwner(1, 4);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testInsertItemOwner2()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.insertItemOwner(0, 4);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertItemOwner3()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.insertItemOwner(1, 0);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------updateItemOwner------------
        [TestMethod]
        public void testUpdateItemOwner1()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.updateItemOwner(1, 4);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateItemOwner2()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.updateItemOwner(0, 4);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateItemOwner3()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();
            //Act
            var actual = itemOwnerModel.updateItemOwner(1, 0);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------viewAllItemOwner------------
        [TestMethod]
        public void testViewAllItemOwner1()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            // itemModel1
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

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 2;
            itemModel2.item_brand = "RAM Thailand";
            itemModel2.item_name = "RAM";
            itemModel2.item_description = "RAM";

            string dateStart2 = "2015-05-07 15:35:51.6317728";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            itemModel2.item_startDate = dateTimeStart2;

            string dateEnd2 = "2015-07-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-2.jpg";
            itemModel2.item_cmuNumber = "";
            itemModel2.item_camtNumber = "";
            itemModel2.item_serialNumber = "Serial02";
            itemModel2.item_component = itemModel1;

            // itemModel3
            ItemModel itemModel3 = new ItemModel();
            itemModel3.item_id = 3;
            itemModel3.item_brand = "Intel";
            itemModel3.item_name = "CPU Iris";
            itemModel3.item_description = "CPU Iris core-i7";

            string dateStart3 = "2015-06-29 02:21:04.1492112";
            DateTime dateTimeStart3 = Convert.ToDateTime(dateStart3);
            itemModel3.item_startDate = dateTimeStart3;

            string dateEnd3 = "2015-08-20 12:00:00.0000000";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            itemModel3.item_endDate = dateTimeEnd3;

            itemModel3.item_status = 1;
            itemModel3.item_picture = "picItem-3.jpg";
            itemModel3.item_cmuNumber = "";
            itemModel3.item_camtNumber = "";
            itemModel3.item_serialNumber = "Serial03";
            itemModel3.item_component = itemModel1;


            //CAMTUSerModel
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 4;
            camtUserModel.user_username = "reporter1";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "reporter one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "114";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 3;
            camtUserModel.user_active = true;

            //itemOwnerModel
            ItemOwnerModel itemOwnerModel1 = new ItemOwnerModel();
            itemOwnerModel1.itemOwner_id = 1;
            itemOwnerModel1.item_id = itemModel1;
            itemOwnerModel1.user_id = camtUserModel;

            ItemOwnerModel itemOwnerModel2 = new ItemOwnerModel();
            itemOwnerModel2.itemOwner_id = 2;
            itemOwnerModel2.item_id = itemModel2;
            itemOwnerModel2.user_id = camtUserModel;

            ItemOwnerModel itemOwnerModel3 = new ItemOwnerModel();
            itemOwnerModel3.itemOwner_id = 3;
            itemOwnerModel3.item_id = itemModel3;
            itemOwnerModel3.user_id = camtUserModel;

            List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
            itemOwnerModelList.Add(itemOwnerModel1);
            itemOwnerModelList.Add(itemOwnerModel2);
            itemOwnerModelList.Add(itemOwnerModel3);


            //Act
            var actual = itemOwnerModel.viewAllItemOwner();
            //Assert
            CollectionAssert.AreEqual(itemOwnerModelList, actual);
        }

        //-----------------viewItemOwnerByItemId------------
        [TestMethod]
        public void testViewItemOwnerByItemId1()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            // itemModel1
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

             //CAMTUSerModel
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 4;
            camtUserModel.user_username = "reporter1";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "reporter one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "114";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 3;
            camtUserModel.user_active = true;

             //itemOwnerModel
            ItemOwnerModel itemOwnerModel1 = new ItemOwnerModel();
            itemOwnerModel1.itemOwner_id = 1;
            itemOwnerModel1.item_id = itemModel1;
            itemOwnerModel1.user_id = camtUserModel;

            //Act
            var actual = itemOwnerModel.viewItemOwnerByItemId(1);
            //Assert
            Assert.AreEqual(itemOwnerModel1, actual);
        }

        [TestMethod]
        public void testViewItemOwnerByItemId2()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            // itemModel1
            ItemModel itemModel1 = new ItemModel();
            ItemModel itemModel4 = new ItemModel();
            itemModel1.item_component = itemModel4;

            //CAMTUSerModel
            CAMTUserModel camtUserModel = new CAMTUserModel();

            //itemOwnerModel
            ItemOwnerModel itemOwnerModel1 = new ItemOwnerModel();
            itemOwnerModel1.itemOwner_id = 0;
            itemOwnerModel1.item_id = itemModel1;
            itemOwnerModel1.user_id = camtUserModel;

            //Act
            var actual = itemOwnerModel.viewItemOwnerByItemId(0);
            //Assert
            Assert.AreEqual(itemOwnerModel1, actual);
        }


        //-----------------viewItemOwnerInformation------------
        [TestMethod]
        public void testViewItemOwnerInformation1()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            // itemModel1
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

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 2;
            itemModel2.item_brand = "RAM Thailand";
            itemModel2.item_name = "RAM";
            itemModel2.item_description = "RAM";

            string dateStart2 = "2015-05-07 15:35:51.6317728";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            itemModel2.item_startDate = dateTimeStart2;

            string dateEnd2 = "2015-07-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-2.jpg";
            itemModel2.item_cmuNumber = "";
            itemModel2.item_camtNumber = "";
            itemModel2.item_serialNumber = "Serial02";
            itemModel2.item_component = itemModel1;

            // itemModel3
            ItemModel itemModel3 = new ItemModel();
            itemModel3.item_id = 3;
            itemModel3.item_brand = "Intel";
            itemModel3.item_name = "CPU Iris";
            itemModel3.item_description = "CPU Iris core-i7";

            string dateStart3 = "2015-06-29 02:21:04.1492112";
            DateTime dateTimeStart3 = Convert.ToDateTime(dateStart3);
            itemModel3.item_startDate = dateTimeStart3;

            string dateEnd3 = "2015-08-20 12:00:00.0000000";
            DateTime dateTimeEnd3 = Convert.ToDateTime(dateEnd3);
            itemModel3.item_endDate = dateTimeEnd3;

            itemModel3.item_status = 1;
            itemModel3.item_picture = "picItem-3.jpg";
            itemModel3.item_cmuNumber = "";
            itemModel3.item_camtNumber = "";
            itemModel3.item_serialNumber = "Serial03";
            itemModel3.item_component = itemModel1;


            //CAMTUSerModel
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 4;
            camtUserModel.user_username = "reporter1";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "reporter one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "114";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 3;
            camtUserModel.user_active = true;

            //itemOwnerModel
            ItemOwnerModel itemOwnerModel1 = new ItemOwnerModel();
            itemOwnerModel1.itemOwner_id = 1;
            itemOwnerModel1.item_id = itemModel1;
            itemOwnerModel1.user_id = camtUserModel;

            ItemOwnerModel itemOwnerModel2 = new ItemOwnerModel();
            itemOwnerModel2.itemOwner_id = 2;
            itemOwnerModel2.item_id = itemModel2;
            itemOwnerModel2.user_id = camtUserModel;

            ItemOwnerModel itemOwnerModel3 = new ItemOwnerModel();
            itemOwnerModel3.itemOwner_id = 3;
            itemOwnerModel3.item_id = itemModel3;
            itemOwnerModel3.user_id = camtUserModel;

            List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
            itemOwnerModelList.Add(itemOwnerModel1);
            itemOwnerModelList.Add(itemOwnerModel2);
            itemOwnerModelList.Add(itemOwnerModel3);


            //Act
            var actual = itemOwnerModel.viewItemOwnerInformation(1);
            //Assert
            CollectionAssert.AreEqual(itemOwnerModelList, actual);
        }

         [TestMethod]
        public void testViewItemOwnerInformation2()
        {
            // Arrange
            ItemOwnerModel itemOwnerModel = new ItemOwnerModel();

            // itemModel1
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

            // itemModel2
            ItemModel itemModel2 = new ItemModel();
            itemModel2.item_id = 2;
            itemModel2.item_brand = "RAM Thailand";
            itemModel2.item_name = "RAM";
            itemModel2.item_description = "RAM";

            string dateStart2 = "2015-05-07 15:35:51.6317728";
            DateTime dateTimeStart2 = Convert.ToDateTime(dateStart2);
            itemModel2.item_startDate = dateTimeStart2;

            string dateEnd2 = "2015-07-20 00:00:00.0000000";
            DateTime dateTimeEnd2 = Convert.ToDateTime(dateEnd2);
            itemModel2.item_endDate = dateTimeEnd2;

            itemModel2.item_status = 1;
            itemModel2.item_picture = "picItem-2.jpg";
            itemModel2.item_cmuNumber = "";
            itemModel2.item_camtNumber = "";
            itemModel2.item_serialNumber = "Serial02";
            itemModel2.item_component = itemModel1;

            //CAMTUSerModel
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 4;
            camtUserModel.user_username = "reporter1";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "reporter one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "114";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 3;
            camtUserModel.user_active = true;

            //itemOwnerModel
            ItemOwnerModel itemOwnerModel2 = new ItemOwnerModel();
            itemOwnerModel2.itemOwner_id = 2;
            itemOwnerModel2.item_id = itemModel2;
            itemOwnerModel2.user_id = camtUserModel;

            List<ItemOwnerModel> itemOwnerModelList = new List<ItemOwnerModel>();
            itemOwnerModelList.Add(itemOwnerModel2);

            //Act
            var actual = itemOwnerModel.viewItemOwnerInformation(2);
            //Assert
            CollectionAssert.AreEqual(itemOwnerModelList, actual);
        }
    }
}
