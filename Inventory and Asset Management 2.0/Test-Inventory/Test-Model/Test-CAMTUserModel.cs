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
    /// Summary description for Test_CAMTUserModel
    /// </summary>
    [TestClass]
    public class Test_CAMTUserModel
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

        //-----------------insertCAMTUser------------
        [TestMethod]
        public void testInsertCAMTUser1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin1", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsTrue(actual);
        }


        [TestMethod]
        public void testInsertCAMTUser2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser(null, "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void testInsertCAMTUser3()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", null, "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser4()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", "123456", null, "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void testInsertCAMTUser5()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", "123456", "admin one", null, "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void testInsertCAMTUser6()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", "123456", "admin one", "CAMT", "512", null, "0833201787", "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void testInsertCAMTUser7()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", null, "se542115021.developer@gmail.com", 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser8()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.insertCAMTUser("admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", null, 1, 1);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------updateCAMTUser------------
        [TestMethod]
        public void testUpdateCAMTUser1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, null, "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser3()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", null, "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser4()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", null, "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void testUpdateCAMTUser5()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", "admin one", null, "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser6()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", "admin one", "CAMT", "512", null, "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser7()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", null, "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser8()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(1, "admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", null, 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser9()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUser(0, "admin", "123456", "admin one", "CAMT", "512", "Chiang mai, Thailand", "0833201787", "se542115021.developer@gmail.com", 1, true);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------updateCAMTUserPass------------
        [TestMethod]
        public void testUpdateCAMTUserPass1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUserPass(1, "123456");
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUserPass2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUserPass(0, "123456");
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUserPass3()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            //Act
            var actual = camtUserModel.updateCAMTUserPass(1, null);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------loginUser------------
        [TestMethod]
        public void testLoginUser1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 1;
            camtUserModel.user_username = "admin";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "admin one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "512";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 1;
            camtUserModel.user_active = true;

            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            //Act
            var actual = camtUserModel2.loginUser("admin", "123456");
            //Assert
            Assert.AreEqual(camtUserModel, actual);
        }

        [TestMethod]
        public void testLoginUser2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();

            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            //Act
            var actual = camtUserModel2.loginUser(null, "123456");
            //Assert
            Assert.AreEqual(camtUserModel, actual);
        }

        [TestMethod]
        public void testLoginUser3()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();

            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            //Act
            var actual = camtUserModel2.loginUser("admin", null);
            //Assert
            Assert.AreEqual(camtUserModel, actual);
        }

        //-----------------removeCAMTUser------------
        [TestMethod]
        public void testRemoveCAMTUser1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();

            //Act
            var actual = camtUserModel.removeCAMTUser(1);
            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod]
        public void testRemoveCAMTUser2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();

            //Act
            var actual = camtUserModel.removeCAMTUser(2);
            //Assert
            Assert.IsFalse(actual);
        }

        //-----------------viewAllUserByUserType------------
        [TestMethod]
        public void testViewAllUserByUserType1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 1;
            camtUserModel.user_username = "admin";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "admin one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "512";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 1;
            camtUserModel.user_active = true;
            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList.Add(camtUserModel);

            CAMTUserModel camtUserModel2 = new CAMTUserModel();

            //Act
            var actual = camtUserModel2.viewAllUserByUserType(1);
            //Assert
            CollectionAssert.AreEqual(camtUserModelList, actual);
        }

        [TestMethod]
        public void testViewAllUserByUserType2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();

            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();

            //Act
            var actual = camtUserModel.viewAllUserByUserType(0);
            //Assert
            CollectionAssert.AreEqual(camtUserModelList, actual);
        }

        //-----------------viewAllCAMTUser------------
        [TestMethod]
        public void testViewAllCAMTUser1()
        {
            // Arrange
            CAMTUserModel camtUserModel1 = new CAMTUserModel();
            camtUserModel1.user_id = 1;
            camtUserModel1.user_username = "admin";
            camtUserModel1.user_password = "123456";
            camtUserModel1.user_name = "admin one";
            camtUserModel1.user_department = "CAMT";
            camtUserModel1.user_room = "512";
            camtUserModel1.user_address = "Chiang mai, Thailand";
            camtUserModel1.user_tel = "0833201787";
            camtUserModel1.user_email = "se542115021.developer@gmail.com";
            camtUserModel1.user_type = 1;
            camtUserModel1.user_active = true;

            CAMTUserModel camtUserModel2 = new CAMTUserModel();
            camtUserModel2.user_id = 2;
            camtUserModel2.user_username = "staff1";
            camtUserModel2.user_password = "123456";
            camtUserModel2.user_name = "staff one";
            camtUserModel2.user_department = "CAMT";
            camtUserModel2.user_room = "113";
            camtUserModel2.user_address = "Chiang mai, Thailand";
            camtUserModel2.user_tel = "0833201787";
            camtUserModel2.user_email = "se542115021.developer@gmail.com";
            camtUserModel2.user_type = 2;
            camtUserModel2.user_active = true;

            CAMTUserModel camtUserModel3 = new CAMTUserModel();
            camtUserModel3.user_id = 3;
            camtUserModel3.user_username = "staff2";
            camtUserModel3.user_password = "123456";
            camtUserModel3.user_name = "staff two";
            camtUserModel3.user_department = "CAMT";
            camtUserModel3.user_room = "114";
            camtUserModel3.user_address = "Chiang mai, Thailand";
            camtUserModel3.user_tel = "0833201787";
            camtUserModel3.user_email = "se542115021.developer@gmail.com";
            camtUserModel3.user_type = 2;
            camtUserModel3.user_active = true;

            CAMTUserModel camtUserModel4 = new CAMTUserModel();
            camtUserModel4.user_id = 4;
            camtUserModel4.user_username = "reporter1";
            camtUserModel4.user_password = "123456";
            camtUserModel4.user_name = "reporter one";
            camtUserModel4.user_department = "CAMT";
            camtUserModel4.user_room = "114";
            camtUserModel4.user_address = "Chiang mai, Thailand";
            camtUserModel4.user_tel = "0833201787";
            camtUserModel4.user_email = "se542115021.developer@gmail.com";
            camtUserModel4.user_type = 3;
            camtUserModel4.user_active = true;

            List<CAMTUserModel> camtUserModelList = new List<CAMTUserModel>();
            camtUserModelList.Add(camtUserModel1);
            camtUserModelList.Add(camtUserModel2);
            camtUserModelList.Add(camtUserModel3);
            camtUserModelList.Add(camtUserModel4);

            CAMTUserModel camtUserModel = new CAMTUserModel();

            //Act
            var actual = camtUserModel.viewAllCAMTUser();
            //Assert
            CollectionAssert.AreEqual(camtUserModelList, actual);
        }

        //-----------------viewUserByuserId------------
        [TestMethod]
        public void testViewUserByuserId1()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            camtUserModel.user_id = 1;
            camtUserModel.user_username = "admin";
            camtUserModel.user_password = "123456";
            camtUserModel.user_name = "admin one";
            camtUserModel.user_department = "CAMT";
            camtUserModel.user_room = "512";
            camtUserModel.user_address = "Chiang mai, Thailand";
            camtUserModel.user_tel = "0833201787";
            camtUserModel.user_email = "se542115021.developer@gmail.com";
            camtUserModel.user_type = 1;
            camtUserModel.user_active = true;

            CAMTUserModel camtUserModel2 = new CAMTUserModel();

            //Act
            var actual = camtUserModel2.viewUserByuserId(1);
            //Assert
            Assert.AreEqual(camtUserModel, actual);
        }

        [TestMethod]
        public void testViewUserByuserId2()
        {
            // Arrange
            CAMTUserModel camtUserModel = new CAMTUserModel();
            CAMTUserModel camtUserModel2 = new CAMTUserModel();

            //Act
            var actual = camtUserModel.viewUserByuserId(0);
            //Assert
            Assert.AreEqual(camtUserModel2, actual);
        }



    }
}
