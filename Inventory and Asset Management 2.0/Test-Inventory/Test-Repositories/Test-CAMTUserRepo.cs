using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0;
namespace Test_Inventory.Test_Repositories
{
    
    [TestClass]
    public class Test_CAMTUserRepo
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void testInsertCAMTUser1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = null;
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser3()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = null;
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser4()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = null;
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser5()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = null;
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser6()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = null;
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser7()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = null;
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertCAMTUser8()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = null;
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.insertCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }


        //-----------------updateCAMTUser------------
        [TestMethod]
        public void testUpdateCAMTUser1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = null;
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser3()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = null;
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser4()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = null;
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser5()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = null;
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser6()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = null;
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser7()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = null;
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateCAMTUser8()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = null;
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.updateCAMTUser(camtUser);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testRemoveCAMTUser1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            //Act
            var actual = camtUserRepo.removeCAMTUser(1);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testRemoveCAMTUser2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            //Act
            var actual = camtUserRepo.removeCAMTUser(2);
            //Assert
            Assert.IsFalse(actual);
        }

        //--------------viewUserByUsernamePassword--------------
        [TestMethod]
        public void testViewUserByUsernamePassword1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.viewUserByUsernamePassword("admin","123456");
            //Assert
            Assert.AreEqual(camtUser, actual);
        }
        [TestMethod]
        public void testViewUserByUsernamePassword2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            //Act
            var actual = camtUserRepo.viewUserByUsernamePassword(null, "123456");
            //Assert
            Assert.AreEqual(camtUser, actual);
        }

        [TestMethod]
        public void testViewUserByUsernamePassword3()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            //Act
            var actual = camtUserRepo.viewUserByUsernamePassword("admin", null);
            //Assert
            Assert.AreEqual(camtUser, actual);
        }

        //----------------viewUserByuserId----------------
        [TestMethod]
        public void testViewUserByuserId1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;
            //Act
            var actual = camtUserRepo.viewUserByuserId(1);
            //Assert
            Assert.AreEqual(camtUser, actual);
        }

        [TestMethod]
        public void testViewUserByuserId2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            //Act
            var actual = camtUserRepo.viewUserByuserId(0);
            //Assert
            Assert.AreEqual(camtUser, actual);
        }

        //----------------viewAllUserByUserType----------------
        [TestMethod]
        public void testViewAllUserByUserType1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;

            List<CAMTUser> camtUserList = new List<CAMTUser>();
            camtUserList.Add(camtUser);
            //Act
            var actual = camtUserRepo.viewAllUserByUserType(1);
            //Assert
            CollectionAssert.AreEqual(camtUserList, actual);
        }

        [TestMethod]
        public void testViewAllUserByUserType2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());

            List<CAMTUser> camtUserList = new List<CAMTUser>();

            //Act
            var actual = camtUserRepo.viewAllUserByUserType(0);
            //Assert
            CollectionAssert.AreEqual(camtUserList, actual);
        }

        //----------------viewAllCAMTUser----------------
        [TestMethod]
        public void testViewAllCAMTUser1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser1 = new CAMTUser();
            camtUser1.user_id = 1;
            camtUser1.user_username = "admin";
            camtUser1.user_password = "123456";
            camtUser1.user_name = "admin one";
            camtUser1.user_department = "CAMT";
            camtUser1.user_room = "512";
            camtUser1.user_address = "Chiang mai, Thailand";
            camtUser1.user_tel = "0833201787";
            camtUser1.user_email = "se542115021.developer@gmail.com";
            camtUser1.user_type = 1;
            camtUser1.user_active = true;

            CAMTUser camtUser2 = new CAMTUser();
            camtUser2.user_id = 2;
            camtUser2.user_username = "staff1";
            camtUser2.user_password = "123456";
            camtUser2.user_name = "staff one";
            camtUser2.user_department = "CAMT";
            camtUser2.user_room = "113";
            camtUser2.user_address = "Chiang mai, Thailand";
            camtUser2.user_tel = "0833201787";
            camtUser2.user_email = "se542115021.developer@gmail.com";
            camtUser2.user_type = 2;
            camtUser2.user_active = true;

            CAMTUser camtUser3 = new CAMTUser();
            camtUser3.user_id = 3;
            camtUser3.user_username = "staff2";
            camtUser3.user_password = "123456";
            camtUser3.user_name = "staff two";
            camtUser3.user_department = "CAMT";
            camtUser3.user_room = "114";
            camtUser3.user_address = "Chiang mai, Thailand";
            camtUser3.user_tel = "0833201787";
            camtUser3.user_email = "se542115021.developer@gmail.com";
            camtUser3.user_type = 2;
            camtUser3.user_active = true;

            CAMTUser camtUser4 = new CAMTUser();
            camtUser4.user_id = 4;
            camtUser4.user_username = "reporter1";
            camtUser4.user_password = "123456";
            camtUser4.user_name = "reporter one";
            camtUser4.user_department = "CAMT";
            camtUser4.user_room = "114";
            camtUser4.user_address = "Chiang mai, Thailand";
            camtUser4.user_tel = "0833201787";
            camtUser4.user_email = "se542115021.developer@gmail.com";
            camtUser4.user_type = 3;
            camtUser4.user_active = true;

            List<CAMTUser> camtUserList = new List<CAMTUser>();
            camtUserList.Add(camtUser1);
            camtUserList.Add(camtUser2);
            camtUserList.Add(camtUser3);
            camtUserList.Add(camtUser4);
            //Act
            var actual = camtUserRepo.viewAllCAMTUser();
            //Assert
            CollectionAssert.AreEqual(camtUserList, actual);
        }

        //----------------viewAllUserByUserTypeActive----------------
        [TestMethod]
        public void testViewAllUserByUserTypeActive1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;

            List<CAMTUser> camtUserList = new List<CAMTUser>();
            camtUserList.Add(camtUser);
            //Act
            var actual = camtUserRepo.viewAllUserByUserTypeActive(1, true);
            //Assert
            CollectionAssert.AreEqual(camtUserList, actual);
        }

        [TestMethod]
        public void testViewAllUserByUserTypeActive2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            List<CAMTUser> camtUserList = new List<CAMTUser>();

            //Act
            var actual = camtUserRepo.viewAllUserByUserTypeActive(0, true);
            //Assert
            CollectionAssert.AreEqual(camtUserList, actual);
        }

        //----------------viewUserByUsername----------------
        [TestMethod]
        public void testViewUserByUsername1()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            camtUser.user_id = 1;
            camtUser.user_username = "admin";
            camtUser.user_password = "123456";
            camtUser.user_name = "admin one";
            camtUser.user_department = "CAMT";
            camtUser.user_room = "512";
            camtUser.user_address = "Chiang mai, Thailand";
            camtUser.user_tel = "0833201787";
            camtUser.user_email = "se542115021.developer@gmail.com";
            camtUser.user_type = 1;
            camtUser.user_active = true;

            //Act
            var actual = camtUserRepo.viewUserByUsername("admin");
            //Assert
            Assert.AreEqual(camtUser, actual);
        }

        [TestMethod]
        public void testViewUserByUsername2()
        {
            // Arrange
            ICAMTUserRepo camtUserRepo = new CAMTUserRepo(new INVENTORY_MANAGEMENT_2Entities());
            CAMTUser camtUser = new CAMTUser();
            //Act
            var actual = camtUserRepo.viewUserByUsername(null);
            //Assert
            Assert.AreEqual(camtUser, actual);
        }


    }
}
