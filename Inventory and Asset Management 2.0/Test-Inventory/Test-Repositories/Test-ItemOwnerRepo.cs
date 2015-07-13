using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventory_and_Asset_Management_2._0.Repositories;
using Inventory_and_Asset_Management_2._0;

namespace Test_Inventory.Test_Repositories
{
    /// <summary>
    /// Summary description for Test_ItemOwnerRepo
    /// </summary>
    [TestClass]
    public class Test_ItemOwnerRepo
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

        //---------------------insertItemOwner---------------------
        [TestMethod]
        public void testInsertItemOwner1()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.item_id = 1;
            itemOwner.user_id = 4;

            //Act
            var actual = itemOwnerRepo.insertItemOwner(itemOwner);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testInsertItemOwner2()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.item_id = 0;
            itemOwner.user_id = 4;

            //Act
            var actual = itemOwnerRepo.insertItemOwner(itemOwner);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testInsertItemOwner3()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.item_id = 1;
            itemOwner.user_id = 0;

            //Act
            var actual = itemOwnerRepo.insertItemOwner(itemOwner);
            //Assert
            Assert.IsFalse(actual);
        }
        //---------------------updateItemOwner---------------------
        [TestMethod]
        public void testUpdateItemOwner1()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.itemOwner_id = 1;
            itemOwner.user_id = 4;

            //Act
            var actual = itemOwnerRepo.updateItemOwner(itemOwner);
            //Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void testUpdateItemOwner2()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.itemOwner_id = 0;
            itemOwner.user_id = 4;

            //Act
            var actual = itemOwnerRepo.updateItemOwner(itemOwner);
            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void testUpdateItemOwner3()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.itemOwner_id = 1;
            itemOwner.user_id = 0;

            //Act
            var actual = itemOwnerRepo.updateItemOwner(itemOwner);
            //Assert
            Assert.IsFalse(actual);
        }

        //---------------------viewItemOwnerByitemId---------------------
        [TestMethod]
        public void testViewItemOwnerByitemId1()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            itemOwner.itemOwner_id = 1;
            itemOwner.item_id = 1;
            itemOwner.user_id = 4;

            //Act
            var actual = itemOwnerRepo.viewItemOwnerByitemId(1);
            //Assert
            Assert.AreEqual(itemOwner,actual);
        }

        //---------------------viewItemOwnerByitemId---------------------
        [TestMethod]
        public void testViewItemOwnerByitemId2()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner = new ItemOwner();
            //Act
            var actual = itemOwnerRepo.viewItemOwnerByitemId(0);
            //Assert
            Assert.AreEqual(itemOwner, actual);
        }

        //---------------------viewAllItemOwner---------------------
        [TestMethod]
        public void testViewAllItemOwner1()
        {
            // Arrange
            IItemOwnerRepo itemOwnerRepo = new ItemOwnerRepo(new INVENTORY_MANAGEMENT_2Entities());
            ItemOwner itemOwner1 = new ItemOwner();
            itemOwner1.itemOwner_id = 1;
            itemOwner1.item_id = 1;
            itemOwner1.user_id = 4;

            ItemOwner itemOwner2 = new ItemOwner();
            itemOwner2.itemOwner_id = 2;
            itemOwner2.item_id = 2;
            itemOwner2.user_id = 4;

            ItemOwner itemOwner3 = new ItemOwner();
            itemOwner3.itemOwner_id = 3;
            itemOwner3.item_id = 3;
            itemOwner3.user_id = 4;

            List<ItemOwner> itemList = new List<ItemOwner>();
            itemList.Add(itemOwner1);
            itemList.Add(itemOwner2);
            itemList.Add(itemOwner3);

            //Act
            var actual = itemOwnerRepo.viewAllItemOwner();
            //Assert
            CollectionAssert.AreEqual(itemList, actual);
        }
    }
}
